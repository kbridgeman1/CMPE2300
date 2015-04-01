<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica12_BridgemanKurtis.aspx.cs" Inherits="ica12_BridgemanKurtis" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CMPE2500 - ICA12</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblPickSupplier" runat="server" Text="Pick a Supplier:"></asp:Label>
    <asp:DropDownList ID="DropDownListSuppliers" runat="server"></asp:DropDownList>
    <asp:TextBox ID="txBx" runat="server"></asp:TextBox>
    <asp:Button ID="btnFilter" runat="server" Text="Filter" />

</asp:Content>

