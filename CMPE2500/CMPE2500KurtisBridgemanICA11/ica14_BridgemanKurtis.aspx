<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica14_BridgemanKurtis.aspx.cs" Inherits="ica14_BridgemanKurtis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CMPE2500 - ICA13</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>ICA14 - Modify Order Details</h1><hr />
    <h1>Part I - Delete Order Details</h1><hr />
    <asp:Label ID="lblOrderID" runat="server" Text="OrderID:"></asp:Label>
    <asp:TextBox ID="txbxOrderID" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetOrderDetails" runat="server" Text="Get Order Details" OnClick="btnGetOrderDetails_Click" /><hr />
    <asp:GridView ID="GridViewOrderDetails" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
</asp:Content>

