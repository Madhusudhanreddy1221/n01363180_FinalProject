using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01363180_FinalProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbconnection db = new Dbconnection();
            //showing the base record page information
            ShowPageInfo(db);
        }
        public void ShowPageInfo(Dbconnection db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //We will attempt to get the record we need
            if (valid)
            {

                HttpPage page_record = db.FindHttpPage(Int32.Parse(pageid));
                heading.InnerHtml = page_record.GetPageTitle();
                pagecontent.InnerHtml = page_record.GetPageContent();
                author.InnerHtml = "Author:"+" "+ page_record.GetPageAuthor();
                Publishdate.InnerHtml = "Published on"+" "+page_record.GetPagePublish_Date();
                
            }
            else
            {
                valid = false;
            }


        }
        public void Delete_Page(object sender, EventArgs e)
        {

            string pageid = Request.QueryString["pageid"];


            Dbconnection db = new Dbconnection();

            //deleting the page from the system


            db.DeletePage(pageid);
            Response.Redirect("ListPages.aspx");

        }
        public void Edit_Page(object sender, EventArgs e)
        {
            string pageid = Request.QueryString["pageid"];
            Response.Redirect("");

        }
    }
}