<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KurtisBridgemanICA09.aspx.cs" Inherits="KurtisBridgemanICA09" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ICA09 - AspImgur</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hiddenFileSavedName" runat="server" />
            <h1>ICA09 - Aspimgur</h1>
            <hr />
            <asp:MultiView ID="MultViewMain" runat="server">
                <asp:View ID="ViewLogin" runat="server">
                    <table>
                        <tr>
                            <td><asp:Label ID="v1lblUsername" runat="server" Text="User Name:"></asp:Label></td>
                            <td><asp:TextBox ID="v1tbxUsername" runat="server"></asp:TextBox></td>
                            <td><asp:Label ID="v1lblPassword" runat="server" Text="Password:"></asp:Label></td>
                            <td><asp:TextBox ID="v1tBxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4"><asp:Button ID="v1btnNext" runat="server" Text="Next" OnClick="v1btnNext_Click" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="ViewAddImages" runat="server">
                    <asp:Label ID="v2lblMessage" runat="server" Text="Label"></asp:Label>
                    <table>
                        <tr>
                            <td colspan="2"><asp:FileUpload ID="v2FileUploadAddImage" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="v2btnNext" runat="server" Text="Next" OnClick="v2btnNext_Click" /></td>
                            <td><asp:Button ID="v2btnLogout" runat="server" Text="Logout" OnClick="v2btnLogout_Click" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="ViewAddedImage" runat="server"></asp:View>
            </asp:MultiView>
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label><br />
            <br />
            <asp:Button ID="btnToAlbum" runat="server" Text="Go To Album" PostBackUrl="~/AlbumCrossPage.aspx" />
        </div>
    </form>
</body>
</html>
