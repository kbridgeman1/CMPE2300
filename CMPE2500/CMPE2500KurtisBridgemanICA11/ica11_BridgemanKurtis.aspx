<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica11_BridgemanKurtis.aspx.cs" Inherits="ica11_BridgemanKurtis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kbridgeman1_NorthwindCustomersConnectionString %>" SelectCommand="SELECT [CustomerID], [ContactName] FROM [Customers] ORDER BY [CustomerID]"></asp:SqlDataSource>
    <asp:DropDownList ID="dropDownListCustomers" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ContactName" DataValueField="CustomerID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:kbridgeman1_NorthwindOrdersConnectionString %>" SelectCommand="SELECT [OrderID], [CustomerID], [OrderDate] FROM [Orders] WHERE ([CustomerID] = @CustomerID) ORDER BY [OrderID]">
        <SelectParameters>
            <asp:ControlParameter ControlID="dropDownListCustomers" DefaultValue="ALFKI" Name="CustomerID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:ListView ID="listViewOrders" runat="server"></asp:ListView>
</asp:Content>

