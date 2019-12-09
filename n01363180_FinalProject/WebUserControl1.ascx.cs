using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01363180_FinalProject
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbconnection db = new Dbconnection();
            searchpage(db);
        }
        void searchpage(Dbconnection db)
        {
            string query = "select * from pages order by pageid";
            List<Dictionary<string, string>> rs = db.List_Query(query);
            Dynamic_Menu.InnerHtml = "<ul class=\"nav navbar-nav\">";
            foreach(Dictionary<string,string>row in rs)
            {
                string pageid = row["pageid"];
                string pagetitle = row["pagetitle"];

                Dynamic_Menu.InnerHtml += "<li><a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></li>";

            }
            Dynamic_Menu.InnerHtml += "</ul>";
        }
    }
}
