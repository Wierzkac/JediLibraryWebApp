<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Holocrons.aspx.cs" Inherits="JediLibraryWebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Holocrons.</h2>

    <div id="addButton">
    <asp:Button ID="AddButton" runat="server" Text="Add New Holocron" Visible="false" OnClick="AddButton_Click" CssClass="button" Width="220px" style=""/>
    </div>
    <asp:Table ID="Table1" runat="server" BorderStyle="Double" GridLines="Both" Width="500px" CellPadding="5" CellSpacing="5">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Title</asp:TableCell>
            <asp:TableCell runat="server">Year</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
