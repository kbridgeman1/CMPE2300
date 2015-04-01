<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>CMPE2500 - DEMO05</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kbridgeman1_pubsConnectionString %>" SelectCommand="SELECT [pub_name], [pub_id] FROM [publishers] ORDER BY [pub_name]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="pub_name" DataValueField="pub_id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:kbridgeman1_pubsConnectionString %>" DeleteCommand="DELETE FROM [titles] WHERE [title_id] = @original_title_id AND [title] = @original_title AND [type] = @original_type AND (([pub_id] = @original_pub_id) OR ([pub_id] IS NULL AND @original_pub_id IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL))" InsertCommand="INSERT INTO [titles] ([title_id], [title], [type], [pub_id], [price]) VALUES (@title_id, @title, @type, @pub_id, @price)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [title_id], [title], [type], [pub_id], [price] FROM [titles] WHERE ([pub_id] = @pub_id) ORDER BY [title_id]" UpdateCommand="UPDATE [titles] SET [title] = @title, [type] = @type, [pub_id] = @pub_id, [price] = @price WHERE [title_id] = @original_title_id AND [title] = @original_title AND [type] = @original_type AND (([pub_id] = @original_pub_id) OR ([pub_id] IS NULL AND @original_pub_id IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_title_id" Type="String" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_type" Type="String" />
            <asp:Parameter Name="original_pub_id" Type="String" />
            <asp:Parameter Name="original_price" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="title_id" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="pub_id" Type="String" />
            <asp:Parameter Name="price" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="pub_id" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="pub_id" Type="String" />
            <asp:Parameter Name="price" Type="Decimal" />
            <asp:Parameter Name="original_title_id" Type="String" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_type" Type="String" />
            <asp:Parameter Name="original_pub_id" Type="String" />
            <asp:Parameter Name="original_price" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="title_id" DataSourceID="SqlDataSource2" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="SelectButton" runat="server" CommandName="Select" Text="Select" />
                </td>
                <td>
                    <asp:Label ID="title_idLabel" runat="server" Text='<%# Eval("title_id") %>' />
                </td>
                <td>
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                </td>
                <td>
                    <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                </td>
                <td>
                    <asp:Label ID="pub_idLabel" runat="server" Text='<%# Eval("pub_id") %>' />
                </td>
                <td>
                    <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
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
                    <asp:Label ID="title_idLabel1" runat="server" Text='<%# Eval("title_id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="typeTextBox" runat="server" Text='<%# Bind("type") %>' />
                </td>
                <td>
                   <%-- <asp:TextBox ID="pub_idTextBox" runat="server" Text='<%# Bind("pub_id") %>' />--%>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="pub_name" DataValueField="pub_id" SelectedValue='<%# Bind("pub_id") %>'></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="priceTextBox" runat="server" Text='<%# Bind("price") %>' />
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
                <td>
                    <asp:TextBox ID="title_idTextBox" runat="server" Text='<%# Bind("title_id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="typeTextBox" runat="server" Text='<%# Bind("type") %>' />
                </td>
                <td>
                    <asp:TextBox ID="pub_idTextBox" runat="server" Text='<%# Bind("pub_id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="priceTextBox" runat="server" Text='<%# Bind("price") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td style="white-space:nowrap">
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="SelectButton" runat="server" CommandName="Select" Text="Select" />
                </td>
                <td>
                    <asp:Label ID="title_idLabel" runat="server" Text='<%# Eval("title_id") %>' />
                </td>
                <td>
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                </td>
                <td>
                    <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                </td>
                <td>
                    <asp:Label ID="pub_idLabel" runat="server" Text='<%# Eval("pub_id") %>' />
                </td>
                <td>
                    <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
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
                                <th runat="server">title_id</th>
                                <th runat="server">title</th>
                                <th runat="server">type</th>
                                <th runat="server">pub_id</th>
                                <th runat="server">price</th>
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
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
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
                    <asp:Label ID="title_idLabel" runat="server" Text='<%# Eval("title_id") %>' />
                </td>
                <td>
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                </td>
                <td>
                    <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                </td>
                <td>
                    <asp:Label ID="pub_idLabel" runat="server" Text='<%# Eval("pub_id") %>' />
                </td>
                <td>
                    <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:kbridgeman1_pubsConnectionString2 %>" SelectCommand="SELECT stores.stor_name, sum(sales.qty) as 'Sum'
FROM sales INNER JOIN stores on sales.stor_id = stores.stor_id
WHERE sales.title_id = @title_id
GROUP BY stores.stor_name
ORDER BY Sum desc
">
        <SelectParameters>
            <asp:ControlParameter ControlID="ListView1" DefaultValue="BU1032" Name="title_id" PropertyName="SelectedValue" />
        </SelectParameters>
</asp:SqlDataSource>
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Vertical">
        <EditItemTemplate>
            stor_name:
            <asp:TextBox ID="stor_nameTextBox" runat="server" Text='<%# Bind("stor_name") %>' />
            <br />
            Sum:
            <asp:TextBox ID="SumTextBox" runat="server" Text='<%# Bind("Sum") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
            stor_name:
            <asp:TextBox ID="stor_nameTextBox" runat="server" Text='<%# Bind("stor_name") %>' />
            <br />
            Sum:
            <asp:TextBox ID="SumTextBox" runat="server" Text='<%# Bind("Sum") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            stor_name:
            <asp:Label ID="stor_nameLabel" runat="server" Text='<%# Bind("stor_name") %>' />
            <br />
            Sum:
            <asp:Label ID="SumLabel" runat="server" Text='<%# Bind("Sum") %>' />
            <br />
        </ItemTemplate>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
    </asp:FormView>
</asp:Content>

