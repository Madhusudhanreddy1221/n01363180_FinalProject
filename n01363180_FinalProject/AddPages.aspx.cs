using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01363180_FinalProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add_Page(object sender, EventArgs e)
        {
            //create connection
            Dbconnection db = new Dbconnection();

            //create a new particular student
            HttpPage new_HttpPage = new HttpPage();
            //set that student data
            new_HttpPage.SetPageTitle(pagetitle.Text);
            new_HttpPage.SetPageContent(pagecontent.Text);
            new_HttpPage.SetPageAuthor(pageauthor.Text);

            DateTime dateTimeVariable = DateTime.Now;
            string date = dateTimeVariable.ToString("yyyy-MM-dd H:mm:ss");


            new_HttpPage.SetPagePublish_Date(date);

            //add the student to the database
            db.AddPage(new_HttpPage);


            Response.Redirect("ListPages.aspx");
        }
        public void Cancelled(object sender, EventArgs e)
        {
            Response.Redirect("ListPages.aspx");
        }

    }
    
}