<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Pages_Account_AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Literal ID="litStatus" runat="server"></asp:Literal>
    <br />
    Username:<br />
    <asp:TextBox ID="txtUsername" runat="server" CssClass="inputs"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtUsername" ErrorMessage="Enter username"></asp:RequiredFieldValidator>
    <br />
    <br />
    Password:<br />
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server"  Text="LogIN" 
    onclick="btnLogin_Click" />
</asp:Content>

