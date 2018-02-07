<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDisp.aspx.cs" Inherits="Pages_ProductDisp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage"/></td>
            <td><h2>
                <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                <hr />
                </h2></td>
        </tr>
        <tr>
            <td>
                Price:
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label><br/>
                Manufactured Date:
                <asp:Label ID="lblManufac" runat="server" CssClass="detailsPrice"></asp:Label>
            </td>
            <td>
                
                Quantity:
                <asp:dropdownlist ID="ddlAmount" runat="server"></asp:dropdownlist>
                <br />
                <asp:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" Text="Add Product" />
                <br/>
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Product Number: <asp:Label ID="lblItemNr" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Available" CssClass="productPrice"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

