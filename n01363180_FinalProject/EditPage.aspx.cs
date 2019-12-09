using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01363180_FinalProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                //this connection instance is for showing data
                
                Dbconnection db = new Dbconnection();
                bool valid = true;
                string pageid = Request.QueryString["pageid"];
                Debug.WriteLine("PageID:" + pageid);
                if (String.IsNullOrEmpty(pageid)) valid = false;

                //We will attempt to get the record we need
                if (valid)
                {

                    HttpPage page_record = db.FindHttpPage(Int32.Parse(pageid));

                    pagetitle.Text = page_record.GetPageTitle();
                    pagecontent.Text = page_record.GetPageContent();
                    pageauthor.Text = page_record.GetPageAuthor();
                }
               
            }
        }
        protected void Update_Page(object sender, EventArgs e)
        {
            

            //this connection instance is for editing data
            Dbconnection db = new Dbconnection();

            bool valid = true;
            string Pageid = Request.QueryString["pageid"];
            if (!String.IsNullOrEmpty(Pageid)) 
            {
                HttpPage new_HttpPage = new HttpPage();
                //set that Page data
                new_HttpPage.SetPageTitle(pagetitle.Text);
                new_HttpPage.SetPageContent(pagecontent.Text);
                new_HttpPage.SetPageAuthor(pageauthor.Text);

                //add the Page data to the database
                try
                {
                    db.UpdatePage(Int32.Parse(Pageid), new_HttpPage);
                    Response.Redirect("ViewPage.aspx?pageid=" + Pageid);
                }
                catch
                {
                    valid = false;
                }

            }
           
        }
        public void Cancelled(object sender, EventArgs e)
        {
            Response.Redirect("ListPages.aspx");
        }


    }
}