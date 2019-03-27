<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JediLibraryWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <p>
                &nbsp;</p>
            <p>
            <asp:Label ID="Label3" runat="server" Text="Gratuluje, zostały Ci przyznane prawa dostępu :" Visible="False" Width="700px"></asp:Label>
            <br />
            <asp:Button ID="LogOutLabel" runat="server" Text="Wyloguj się!" Visible="False" Onclick="LogOut_click" ForeColor="#0066FF"></asp:Button>

            </p>
            <div runat="server" ID="MyDiv">
            <p>
                &nbsp;Login:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server">login</asp:TextBox>
            </p>
            <p>
                Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server">password</asp:TextBox>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log in" />
            </p>
            </div>
        </div>
    </div>

    <br />
    Logs:
    <asp:Label ID="Label2" runat="server" Text="No connection to serwer."></asp:Label>

</asp:Content>
