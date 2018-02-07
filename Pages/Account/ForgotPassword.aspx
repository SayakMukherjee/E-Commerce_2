<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Pages_Account_ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Email ID:</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
<p>
    Secret Answer:</p>
<p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="CaptchaLabel" runat="server" AssociatedControlID="CaptchaCode">
			Retype the characters from the picture:
		</asp:Label>
		<BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" />
		<asp:TextBox ID="CaptchaCode" runat="server" />
		<asp:Label ID="CaptchaErrorLabel" runat="server" />
</p>
<p>
    <asp:Button ID="Button1" runat="server" Text="RESET PASSWORD" 
        onclick="Button1_Click" />
</p>
    <p>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</p>
</asp:Content>

