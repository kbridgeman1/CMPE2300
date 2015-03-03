<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ica08_KurtisBridgeman.aspx.cs" Inherits="ica08_KurtisBridgeman" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMPE2500 - ICA08</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ICA08:Kurtis' Calendar</h1>
            <hr />
            <asp:AdRotator ID="AdRotator1" runat="server" Target="self" AdvertisementFile="~/Images/ads.xml" />
            <hr />
            <table id="Table1" runat="server">
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rBtns" Text="Red" BackColor="Red" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rBtns" Text="Blue" BackColor="Blue" />
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="rBtns" Text="Yellow" BackColor="Yellow" />
                    </td>
                    <td></td> <%-- Blank --%>
                </tr>
                <tr>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" ></asp:Calendar>
                    </td>
                    <td>
                        <asp:ListBox ID="ListBox1" runat="server" Rows="15"></asp:ListBox>
                    </td> <%-- Dates to remember ListBox --%>
                </tr>
                <tr>
                    <td id="botCell" colspan="2">
                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label><br />
                        <asp:Button ID="btnCrossPagePrint" runat="server" Text="Button" PostBackUrl="~/ica08_PostBackPage.aspx" />
                    </td>  <%-- status/crosspage post button --%>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
