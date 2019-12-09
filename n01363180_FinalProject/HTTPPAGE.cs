using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace n01363180_FinalProject
{
    public class HttpPage
    {
        private string PageTitle;
        private int PageId;
        private string PageContent;
        private string PageAuthor;
        private string PagePublish_Date;

        //Getting page Details
        public string GetPageTitle()
        {
            return PageTitle;
        }
        public string GetPageContent()
        {
            return PageContent;
        }
        public string GetPageAuthor()
        {
            return PageAuthor;
        }
        public string GetPagePublish_Date()
        {
            return PagePublish_Date;
        }
        public int GetPageId()
        {
            return PageId;
        }


        //Settign Page details
        public void SetPageTitle(string value)
        {
            PageTitle = value;
        }
        public void SetPageContent(string value)
        {
            PageContent = value;
        }
        public void SetPageAuthor(string Value)
        {
            PageAuthor = Value;
        }
        public void SetPagePublish_Date(string value)
        {
            PagePublish_Date = value;
        }
        public void SetPageId(int value)
        {
            PageId = value;
        }
    }
}