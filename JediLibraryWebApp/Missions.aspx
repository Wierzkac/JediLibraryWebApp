<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Missions.aspx.cs" Inherits="JediLibraryWebApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Missions:</h2>

    <asp:Table ID="Table1" runat="server" BorderStyle="Double" GridLines="Both" CellPadding="5" CellSpacing="5">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Year</asp:TableCell>
            <asp:TableCell runat="server">Title</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div runat="server" ID="errors"></div>
</asp:Content>
