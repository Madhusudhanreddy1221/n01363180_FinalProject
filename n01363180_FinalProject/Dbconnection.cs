
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n01363180_FinalProject
{
    public class Dbconnection
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "webapplicationdev"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString to connect to a database
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();
                //for every row in the result set
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }
                    ResultSet.Add(Row);
                }//end row
                resultset.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }
        //Get All Pages From Databas
        public HttpPage FindHttpPage(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            HttpPage result_HttpPage = new HttpPage();
            try
            {
                string query = "select * from pages where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();
                List<HttpPage> Pages = new List<HttpPage>();
                while (resultset.Read())
                {
                    HttpPage currentHttpPage = new HttpPage();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        switch (key)
                        {
                            
                            case "pagetitle":
                                currentHttpPage.SetPageTitle(value);
                                break;
                            case "pagebody":
                                currentHttpPage.SetPageContent(value);
                                break;
                            case "author":
                                currentHttpPage.SetPageAuthor(value);
                                break;
                            case "Publish_Date":
                                currentHttpPage.SetPagePublish_Date(value);
                                break;
                        }

                    }
                  
                    Pages.Add(currentHttpPage);
                }

                result_HttpPage = Pages[0]; 

            }
            catch (Exception ex)
            {  
                Debug.WriteLine("Something went wrong in the find page method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");
            return result_HttpPage;
        }

        //Add  New Page to database
        public void AddPage(HttpPage new_HttpPage)
        {
            string query = "insert into pages (pagetitle, pagebody, author, Publish_Date) values ('{0}','{1}','{2}','{3}')";
            query = String.Format(query, new_HttpPage.GetPageTitle(), new_HttpPage.GetPageContent(), new_HttpPage.GetPageAuthor(), new_HttpPage.GetPagePublish_Date());
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Addpage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        //Delete Page
        public void DeletePage(string pageid)
        {
            string removepage = "delete from pages where pageid = {0}";
            removepage = String.Format(removepage, pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //This command removes the particular page from the table
            MySqlCommand cmd_removepage = new MySqlCommand(removepage, Connect);
            try
            {
                Connect.Open();
                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Something went wrong in the delete page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        // Update page
        public void UpdatePage(int pageid, HttpPage new_HttpPage)
        {
            string query = "update pages set pagetitle='{0}', pagebody='{1}', author='{2}' where pageid={3}";
            query = String.Format(query, new_HttpPage.GetPageTitle(), new_HttpPage.GetPageContent(), new_HttpPage.GetPageAuthor(), pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Updatepage Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
    }
}