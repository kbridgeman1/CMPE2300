﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica14_BridgemanKurtis.aspx.cs" Inherits="ica14_BridgemanKurtis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CMPE2500 - ICA13</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>ICA14 - Modify Order Details</h1><hr />
    <h1>Part I - Delete Order Details</h1><hr />
    <asp:Label ID="lblOrderID" runat="server" Text="OrderID:"></asp:Label>
    <asp:TextBox ID="txbxOrderID" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetOrderDetails" runat="server" Text="Get Order Details" OnClick="btnGetOrderDetails_Click" /><hr />
    <asp:GridView ID="GridViewOrderDetails" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridViewOrderDetails_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView><br />
    <asp:Button ID="btnDeleteSelected" runat="server" Text="Delete Order Detail" OnClick="btnDeleteSelected_Click" /><br />
    <asp:Label ID="lblStatusPartI" runat="server" Text="Status: delete an order"></asp:Label><hr />
    <h1>PartII - Insert Order Details</h1><hr />
    <asp:Label ID="lblInsEntOrdID" runat="server" Text="Enter OrderID:"></asp:Label>
    <asp:TextBox ID="txbxInsOrderID" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblInsEntProdID" runat="server" Text="Select Product:"></asp:Label>
    <asp:DropDownList ID="ddlInseSelectProdID" runat="server"></asp:DropDownList><br />
    <asp:Label ID="lblInsEntQuantity" runat="server" Text="Enter Quantity:"></asp:Label>
    <asp:TextBox ID="txbxInsEntQuantity" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnInsRecord" runat="server" Text="Insert Record" OnClick="btnInsRecord_Click" />
    <asp:Label ID="lblStatusPartII" runat="server" Text="Label"></asp:Label>

</asp:Content>

