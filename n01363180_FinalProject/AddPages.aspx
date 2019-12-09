<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPages.aspx.cs" Inherits="n01363180_FinalProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ADD NEW PAGE</h2>
    <div id="row1">
         <label class="control-label col-sm-2">Page Title:</label>
         <asp:TextBox id="pagetitle" TextMode="multiline" Columns="70" Rows="3" runat="server" />
    </div>
    <div id="row2">
        <label class="control-label col-sm-2">Page Content:</label>
        <asp:TextBox id="pagecontent" TextMode="multiline" Columns="70" Rows="5" runat="server" />
    </div>
    <div id="row3">
        <label class="control-label col-sm-2">Author Name:</label>
        <asp:TextBox id="pageauthor"  Columns="70" runat="server" />
    </div>
    <div id="row4">
        <asp:Button class="btn btn-success" OnClick="Add_Page" Text="ADD PAGE" runat="server" />
         <asp:Button class="btn btn-danger" OnClick="Cancelled" Text="CANCEL" runat="server" />
    </div>

</asp:Content>
