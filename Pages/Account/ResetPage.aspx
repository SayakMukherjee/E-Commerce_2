<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPage.aspx.cs" Inherits="Pages_Account_ResetPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    New Password:</p>
<p>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    Confirm Password:</p>
<p>
    <asp:TextBox ID="txtConfrmPass" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btn_Reset" runat="server" Text="SUBMIT" 
        onclick="btn_Reset_Click" />
</p>
<p>
    <asp:Literal ID="litResult" runat="server"></asp:Literal>
</p>
</asp:Content>

