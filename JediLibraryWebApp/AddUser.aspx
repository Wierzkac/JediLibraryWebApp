<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="JediLibraryWebApp.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="div">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Permissoins(LVL): "></asp:Label>
        <asp:TextBox ID="PermissionsBox" runat="server"></asp:TextBox>
        
        <br />
        <br />
        <asp:Button ID="AddButton" runat="server" Text="Submit" OnClick="AddButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
    </div>
    <div>
        <asp:Label ID="LogLabel" runat="server" Text=" "></asp:Label>
    </div>
</asp:Content>
