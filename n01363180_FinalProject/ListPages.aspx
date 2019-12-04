<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="n01363180_FinalProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>List of all Webpages</h2>
    <div id="Dynamic_navbar" runat="server"></div>
    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="ADD PAGE" OnClick="Add_Page" />
    <div id="Search_bar">
        <asp:TextBox ID="Search_txt" runat="server"></asp:TextBox><asp:Button ID="search_btn"  class="btn btn-primary" runat="server" Text="SEARCH"/></div>
    <div id="Page_List" runat="server"></div>
    <table id="Table1" runat="server">
        <thead>
            <tr>
                <th> PAGE ID</th>
                <th>PAGE TITLE</th>
                <th>PAGE CONTENT</th>
                <th>AUTHOR</th>
                <th>ACTIONS</th>
            </tr>
        </thead>

    </table>
</asp:Content>
