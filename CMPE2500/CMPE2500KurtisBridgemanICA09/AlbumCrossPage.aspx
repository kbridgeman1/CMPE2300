<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlbumCrossPage.aspx.cs" Inherits="AlbumCrossPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMPE2500 - ICA09 Album</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="_hiddenFieldUName" runat="server" />
        <asp:PlaceHolder ID="_placeholderAlbum" runat="server"></asp:PlaceHolder><hr />
        <asp:Button ID="_btnAddAgain" runat="server" Text="Add Again" OnClick="_btnAddAgain_Click" PostBackUrl="~/KurtisBridgemanICA09.aspx"/>
    </div>
    </form>
</body>
</html>
