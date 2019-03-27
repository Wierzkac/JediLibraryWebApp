<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Holocrons.aspx.cs" Inherits="JediLibraryWebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Holocrons.</h2>

    <asp:Button ID="AddButton" runat="server" Text="Add New Holocron" Visible="false" OnClick="AddButton_Click" />

    <asp:Table ID="Table1" runat="server" BorderStyle="Double" GridLines="Both" Width="500px" CellPadding="5" CellSpacing="5">
    </asp:Table>
</asp:Content>
