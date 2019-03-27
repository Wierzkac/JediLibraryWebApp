<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectedItem.aspx.cs" Inherits="JediLibraryWebApp.SelectedItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="MyDiv">
    </div>
    <div runat="server" id="wlaczonaEdycja">

    </div>
    <div runat="server" id="edycja">
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="Button2_Click" />
    </div>
    <div runat="server" id="widok">
        <asp:Button ID="EditButton" runat="server" Text="Edit" Visible="false" OnClick="Button3_Click" />
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" Visible="False" OnClick="DeleteButton_Click" />
    </div>
    <div runat="server" ID="errors"></div>
</asp:Content>
