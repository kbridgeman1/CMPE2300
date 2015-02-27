<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ica08_KurtisBridgeman.aspx.cs" Inherits="ica08_KurtisBridgeman" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ICA08:Kurtis' Calendar</h1>
            <hr />
            <asp:AdRotator ID="AdRotator1" runat="server" />
            <hr />
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>  <%--Radio Buttons--%>
                    <asp:TableCell></asp:TableCell> <%-- Blank --%>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell> <%-- Calendar --%>
                    <asp:TableCell></asp:TableCell> <%-- Dates to remember ListBox --%>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"></asp:TableCell>  <%-- status/crosspage post button --%>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
