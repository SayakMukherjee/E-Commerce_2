<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
    &nbsp;<asp:LinkButton ID="btnAdmin" runat="server" style="float:right" 
        PostBackUrl="~/Pages/Account/AdminLogin.aspx">Admin Login</asp:LinkButton>
    <br />
    Username:<br />
    <asp:TextBox ID="txtUsername" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    Password:<br />
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server"  Text="LogIN" 
    onclick="btnLogin_Click" />
    <br />
    <br />
    <asp:LinkButton ID="ForPass" runat="server" 
        PostBackUrl="~/Pages/Account/ForgotPassword.aspx">Forgot Password</asp:LinkButton>
    <br />
    <br />
    <br />
</asp:Content>

