<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KurtisBridgemanICA09.aspx.cs" Inherits="KurtisBridgemanICA09" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>ICA09 - AspImgur</h1><hr />
        <asp:MultiView ID="MultViewMain" runat="server">
            <asp:View ID="ViewLogin" runat="server">
                <asp:Label ID="v1lblUsername" runat="server" Text="User Name:"></asp:Label>
                <asp:TextBox ID="v1tbxUsername" runat="server"></asp:TextBox>
                <asp:Label ID="v1lblPassword" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="v1tBxPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Button ID="v1btnNext" runat="server" Text="Next" OnClick="v1btnNext_Click" />
            </asp:View>
            <asp:View ID="ViewAddImages" runat="server">
                <asp:Label ID="v2lblMessage" runat="server" Text="Label"></asp:Label>
                <asp:FileUpload ID="v2FileUploadAddImage" runat="server" /><br />
                <asp:Button ID="v2btnNext" runat="server" Text="Next" OnClick="v2btnNext_Click" />
            </asp:View>



        </asp:MultiView>
        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnToAlbum" runat="server" Text="Go To Album" />
    </div>
    </form>
</body>
</html>
