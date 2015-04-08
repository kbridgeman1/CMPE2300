<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica11_BridgemanKurtis_NEW.aspx.cs" Inherits="ica11_BridgemanKurtis_NEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CMPE2500 - ICA11</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kbridgeman1_NorthwindConnectionString %>" SelectCommand="SELECT [CustomerID], [CompanyName] FROM [Customers] ORDER BY [CompanyName]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CompanyName" DataValueField="CustomerID"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:kbridgeman1_NorthwindConnectionString2 %>" SelectCommand="SELECT [OrderID], [CustomerID], [OrderDate] FROM [Orders] WHERE ([CustomerID] = @CustomerID) ORDER BY [OrderID]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = @original_OrderID AND (([CustomerID] = @original_CustomerID) OR ([CustomerID] IS NULL AND @original_CustomerID IS NULL)) AND (([OrderDate] = @original_OrderDate) OR ([OrderDate] IS NULL AND @original_OrderDate IS NULL))" InsertCommand="INSERT INTO [Orders] ([CustomerID], [OrderDate]) VALUES (@CustomerID, @OrderDate)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Orders] SET [CustomerID] = @CustomerID, [OrderDate] = @OrderDate WHERE [OrderID] = @original_OrderID AND (([CustomerID] = @original_CustomerID) OR ([CustomerID] IS NULL AND @original_CustomerID IS NULL)) AND (([OrderDate] = @original_OrderDate) OR ([OrderDate] IS NULL AND @original_OrderDate IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_OrderID" Type="Int32" />
            <asp:Parameter Name="original_CustomerID" Type="String" />
            <asp:Parameter Name="original_OrderDate" Type="DateTime" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="String" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="CustomerID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="CustomerID" Type="String" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="original_OrderID" Type="Int32" />
            <asp:Parameter Name="original_CustomerID" Type="String" />
            <asp:Parameter Name="original_OrderDate" Type="DateTime" />
        </UpdateParameters>
</asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="OrderID" DataSourceID="SqlDataSource2" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("OrderDate") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color:#008A8C;color: #FFFFFF;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel1" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="OrderDateTextBox" runat="server" Text='<%# Bind("OrderDate") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="OrderDateTextBox" runat="server" Text='<%# Bind("OrderDate") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("OrderDate") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">OrderID</th>
                                <th runat="server">CustomerID</th>
                                <th runat="server">OrderDate</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("OrderDate") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>


</asp:Content>

