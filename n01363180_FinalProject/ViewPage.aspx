<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="n01363180_FinalProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="heading" runat="server"></h2>
     <asp:Button ID="Button1" class="btn btn-danger"  runat="server" Text="DELETE" OnClick="Delete_Page" />
    <a href="EditPage.aspx?pageid=<%=Request.QueryString["pageid"] %>" class="btn btn-warning">EDIT</a>
    <p id="pagecontent" runat="server"></p>
    <p id="author" runat="server"></p>
    <p id="Publishdate" runat="server"></p>
</asp:Content>
