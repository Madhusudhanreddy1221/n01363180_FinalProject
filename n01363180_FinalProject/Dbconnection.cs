
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

            // try{} catch{} will attempt to do everything inside try{}
            // if an error happens inside try{}, then catch{} will execute instead.
            // very useful for debugging without the whole program crashing!
            // this can be easily abused and should be used sparingly.
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


        //The objective of this method in the Dbconnection class is to find a particular page given an integer ID

        public HttpPage FindHttpPage(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a "blank" page so that our method can return something if we're not successful catching page data
            HttpPage result_HttpPage = new HttpPage();

            //we will try to grab page data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            try
            {
                //Build a custom query with the id information provided
                string query = "select * from pages where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of pages (although we're only trying to get 1)
                List<HttpPage> Pages = new List<HttpPage>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single page
                    HttpPage currentHttpPage = new HttpPage();

                    //Look at each column in the result set row, add both the column name and the column value to our page dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        //can't just generically put data into a dictionary anymore
                        //must go through each column one by one to insert data into the right property
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
                    //Add the page to the list of pages
                    Pages.Add(currentHttpPage);
                }

                result_HttpPage = Pages[0]; //get the first page

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find page method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_HttpPage;
        }
        public void AddPage(HttpPage new_HttpPage)
        {
            //slightly better way of injecting data into strings

            string query = "insert into pages (pagetitle, pagebody, author, Publish_Date) values ('{0}','{1}','{2}','{3}')";
            query = String.Format(query, new_HttpPage.GetPageTitle(), new_HttpPage.GetPageContent(), new_HttpPage.GetPageAuthor(), new_HttpPage.GetPagePublish_Date());

            //This technique is still sensitive to SQL injection
            //

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

            //DELETING ON THE PRIMARY KEY OF PAGES
            string removepage = "delete from pages where pageid = {0}";
            removepage = String.Format(removepage, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            
            //This command removes the particular page from the table
            MySqlCommand cmd_removepage = new MySqlCommand(removepage, Connect);
            try
            {
                //try to execute both commands!
                Connect.Open();
               
                //then delete the main record
                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
            }
            catch (Exception ex)
            {
                //if this isn't working as intended, you can check debug>windows>output for the error message.
                Debug.WriteLine("Something went wrong in the delete page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        // Update page
        public void UpdatePage(int pageid, HttpPage new_HttpPage)
        {
            //slightly better way of injecting data into strings
            //the below technique is known as string formatting. It allows us to make strings without "" + ""
            string query = "update pages set pagetitle='{0}', pagebody='{1}', author='{2}' where pageid={3}";
            query = String.Format(query, new_HttpPage.GetPageTitle(), new_HttpPage.GetPageContent(), new_HttpPage.GetPageAuthor(), pageid);
            //The above technique is still sensitive to SQL injection
            //we will learn about parameterized queries in the 2nd semester

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Try to update a page with the information provided to us.
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the Updatepage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

    }
}