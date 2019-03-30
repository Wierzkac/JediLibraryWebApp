<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JediLibraryWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="div" runat="server">
    <div class="row">
        <div class="col-md-4">
            <p>
                &nbsp;</p>
            <p>
            <br />
            <asp:Button ID="LogOutLabel" runat="server" Text="Wyloguj się!" Visible="False" Onclick="LogOut_click" CssClass="button"></asp:Button>

            </p>
            <div runat="server" ID="MyDiv">
            <p>
                &nbsp;Login:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox">login</asp:TextBox>
            </p>
            <p>
                Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" TextMode="Password">password</asp:TextBox>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log in" CssClass="button" />
            </p>
            </div>
        </div>
    </div>
            <asp:Label ID="Label3" runat="server" Text="Gratuluje, zostały Ci przyznane prawa dostępu :" Visible="False" Width="700px" style="margin-top: 0px"></asp:Label>
        </div>

    <br />
    Logs:
    <asp:Label ID="Label2" runat="server" Text="No connection to serwer."></asp:Label>

</asp:Content>
