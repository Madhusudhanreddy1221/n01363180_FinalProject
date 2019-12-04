using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace n01363180_FinalProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
            //resets the result set window
            string query = "select * from pages";
            var db = new Dbconnection();

            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {

                string pageid = row["pageid"];
                string pagetitle = row["pagetitle"];
                string pagecontent = row["pagebody"];
                string pageauthor = row["author"];
                string publish_date_time = row["Publish_Date"];
                HtmlTableRow trow = new HtmlTableRow();
                Dynamic_navbar.InnerHtml = "<a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a>";

                //1st column
                HtmlTableCell Cell1 = new HtmlTableCell();
                Cell1.InnerText = pageid;
                trow.Controls.Add(Cell1);

                //2nd column
                HtmlTableCell Cell2 = new HtmlTableCell();
                Cell2.InnerHtml = "<a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a>";
                trow.Controls.Add(Cell2);
                
                //3nd column
                HtmlTableCell Cell3 = new HtmlTableCell();
                Cell3.InnerText = pagecontent;
                trow.Controls.Add(Cell3);

                //4th column
                HtmlTableCell Cell4= new HtmlTableCell();
                Cell4.InnerText = pageauthor;
                trow.Controls.Add(Cell4);

                //5th column
                LinkButton EditButton = new LinkButton();
                EditButton.Text = "EDIT";
                EditButton.ID = "Edit_btn";
                EditButton.PostBackUrl = "EditPage.aspx?pageid="+pageid;
                HtmlTableCell cell5 = new HtmlTableCell();
                cell5.Controls.Add(EditButton);
                trow.Cells.Add(cell5);

                ////6th column
                //LinkButton DeleteButton = new LinkButton();
                //DeleteButton.Text = "DELETE";
                //DeleteButton.Click += new EventHandler(D);

                //HtmlTableCell cell6 = new HtmlTableCell();
                
                //cell6.Controls.Add(DeleteButton);
                //trow.Cells.Add(cell6);

                Table1.Rows.Add(trow);
            }
        }
        protected void Add_Page(object sender, EventArgs e)
        {
            Response.Redirect("AddPages.aspx");
        }
 

    }
}