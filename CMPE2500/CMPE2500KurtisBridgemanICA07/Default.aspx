﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                <td>
                    <asp:TextBox ID="tBxRed" runat="server" style="width:98%; height:100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblGreed" runat="server" RepeatDirection="Horizontal" style="width:100%; height:100%">
                        <asp:ListItem Value="0">0%</asp:ListItem>
                        <asp:ListItem Value="128">50%</asp:ListItem>
                        <asp:ListItem Value="255">100%</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td><asp:DropDownList ID="ddlBlue" runat="server" style="width:98%; height:100%; font-size:0.9em">
                    <asp:ListItem Text="Nada" Value="0" />
                    <asp:ListItem Text="Just a bit" Value="64" />
                    <asp:ListItem Text="About half" Value="128" />
                    <asp:ListItem Text="Most of it" Value="192" />
                    <asp:ListItem Text="Every bit" Value="255" />
                    </asp:DropDownList></td>
                <td rowspan="3"><asp:ListBox ID="ListBox1" runat="server"></asp:ListBox></td>
            </tr>
            <tr>
                <td colspan="3">Name:<asp:TextBox ID="tBxName" runat="server" style="width:85%; height:100%"></asp:TextBox></td>
            </tr>
            <tr><td></td><td></td><td></td></tr>
            <tr><td></td><td></td><td></td><td></td></tr>
        </table>

    </div>

    </form>
</body>
</html>
