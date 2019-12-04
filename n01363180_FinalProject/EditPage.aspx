<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="n01363180_FinalProject.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="sample">
        <h2>Edit Page</h2>
        <div id="row1">
         <label class="control-label col-sm-2">Page Title:</label>
         <asp:TextBox id="pagetitle" TextMode="multiline" Columns="140" Rows="3" runat="server" />
        </div>
        <div id="row2">
            <label class="control-label col-sm-2">Page Content:</label>
            <asp:TextBox id="pagecontent" TextMode="multiline" Columns="140" Rows="5" runat="server" />
        </div>
        <div id="row3">
            <label class="control-label col-sm-2">Author Name:</label>
            <asp:TextBox id="pageauthor"  Columns="70" runat="server" />
        </div>
        <div id="row4">
        <asp:Button class="btn btn-warning" OnClick="Update_Page" Text="UPDATE" runat="server" />
        </div>
    </div>
    <div id="Error_Msg" runat="server"></div>
</asp:Content>
