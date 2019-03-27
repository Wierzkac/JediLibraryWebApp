<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectedItem.aspx.cs" Inherits="JediLibraryWebApp.SelectedItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="MyDiv">
    </div>
    <div runat="server" id="wlaczonaEdycja">

    </div>
    <div runat="server" id="edycja">
        <asp:Button ID="Button1" runat="server" Text="Submit" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" />
    </div>
    <div runat="server" id="widok">
        <asp:Button ID="Button3" runat="server" Text="Edit" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Delete" />
    </div>
    <div runat="server" ID="errors"></div>
</asp:Content>
