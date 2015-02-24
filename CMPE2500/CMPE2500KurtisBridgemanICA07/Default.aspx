<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMPE2500 - ICA07</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">

    <div id="header">
    <h1>CMPE2500 - Color Generator</h1>
    </div>
    
    <div id="content">
        <br />
        <table id="mainTable">
            <tr><td class="hRow">Red</td><td class="hRow">Green</td><td class="hRow">Blue</td><td class="hRow">Saved Colors</td></tr>
            <tr>
                <td><asp:TextBox ID="tBxRed" runat="server"></asp:TextBox></td>
                <td>radList</td>
                <td><asp:DropDownList ID="ddlBlue" runat="server">
                    <asp:ListItem Text="Nada" Value="0" />
                    <asp:ListItem Text="Just a bit" Value="64" />
                    <asp:ListItem Text="About half" Value="128" />
                    <asp:ListItem Text="Most of it" Value="192" />
                    <asp:ListItem Text="Every bit" Value="255" />
                    </asp:DropDownList></td>
                <td rowspan="3"><asp:ListBox ID="ListBox1" runat="server"></asp:ListBox></td>
            </tr>

            <tr><td></td><td></td><td></td></tr>
            <tr><td></td><td></td><td></td></tr>
            <tr><td></td><td></td><td></td><td></td></tr>
        </table>

    </div>

    </form>
</body>
</html>
