<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Missions.aspx.cs" Inherits="JediLibraryWebApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Missions:</h2>

    <asp:Table ID="Table1" runat="server" BorderStyle="Double" GridLines="Both" Width="500px" CellPadding="5" CellSpacing="5">
    </asp:Table>

    <div runat="server" ID="errors"></div>
</asp:Content>
