<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica13_BridgemanKurtis.aspx.cs" Inherits="ica13_BridgemanKurtis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CMPE2500 - ICA13</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>ICA13 - Stored Procedures & ASP.NET</h2><hr />
    <asp:Label ID="lblpickCust" runat="server" Text="Pick a Customer:"></asp:Label>
    <asp:DropDownList ID="ddlCustomers" runat="server" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged"></asp:DropDownList>
    <asp:TextBox ID="txbxFilter" runat="server"></asp:TextBox>
    <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" /><br />
    <asp:GridView ID="gridViewCategories" runat="server" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Black" HeaderStyle-BorderColor="Black" CellPadding="5" OnRowDataBound="gridViewCategories_RowDataBound" ></asp:GridView>
</asp:Content>

