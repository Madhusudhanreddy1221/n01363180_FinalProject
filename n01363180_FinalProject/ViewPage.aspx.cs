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
            ShowPageInfo(db);
        }
        public void ShowPageInfo(Dbconnection db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            if (valid)
            {
                //finding  the page we requested by refering the function FindHttpPage in Dbconnection.cs and gets the records to display on html page
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
        //function to delete the page on button click
        public void Delete_Page(object sender, EventArgs e)
        {
            string pageid = Request.QueryString["pageid"];
            Dbconnection db = new Dbconnection();
            db.DeletePage(pageid);
            Response.Redirect("ListPages.aspx");
        }
    }
}