<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Pages_Management_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Literal ID="litStatus" runat="server"></asp:Literal>
        <br />
        <br />
    
        Username:<br/>
    
        <asp:TextBox ID="txtUsername" runat="server" CssClass="inputs"></asp:TextBox>
    
    
        <br/>Password:<br/>
    
        <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    
        
        <br />
    
        
        First Name:<br />
        <asp:TextBox ID="txtFirstname" runat="server" CssClass="inputs"></asp:TextBox>
        <br />
        <br />
        LastName:<br />
        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputs"></asp:TextBox>
        <br />
        <br />
        Email ID:<br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs"></asp:TextBox>
        <br />
        <br />
        Phone:<br />
        <asp:TextBox ID="txtPhone" runat="server" CssClass="inputs"></asp:TextBox>
        <br />
        <br />
        Address:<br />
        <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" Height="70px" TextMode="MultiLine" Width="265px"></asp:TextBox>
        <br />
        <br />
        Postal Code:<br />
        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs"></asp:TextBox>
    
        <br/><br/><asp:Button ID="Button1" runat="server"  Text="Verify User" 
        onclick="Button1_Click" />
</asp:Content>

