<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewHolocron.aspx.cs" Inherits="JediLibraryWebApp.AddNewHolocron" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Tytul: "></asp:Label>
        <asp:TextBox ID="TytulBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Author: "></asp:Label>
        <asp:TextBox ID="AuthorBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Year: "></asp:Label>
        <asp:TextBox ID="YearBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Content: "></asp:Label>
        <asp:TextBox ID="ContentBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Permission Level: "></asp:Label>
        <asp:TextBox ID="PozwolenieBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="AddButton" runat="server" Text="Submit" OnClick="AddButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
    </div>

</asp:Content>
