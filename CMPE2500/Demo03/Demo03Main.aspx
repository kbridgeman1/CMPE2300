<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo03Main.aspx.cs" Inherits="Demo03Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMPE2500 - ASP Demo03</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>CMPE2500 - ASP Demo03</h1><hr />
        <asp:HiddenField ID="_hidden" runat="server" />
        <asp:MultiView ID="_multV" runat="server">
            <asp:View ID="_mvFirst" runat="server">
                First Page
                <asp:Button ID="_btnNext" runat="server" Text="Next" OnClick="_btnNext_Click" />
            </asp:View>
            <asp:View ID="_mvSecond" runat="server">
                Second Page
                <asp:FileUpload ID="_fileUpload" runat="server" />
                <asp:Button ID="_btnUpload" runat="server" Text="Upload" OnClick="_btnUpload_Click" />
                <asp:Button ID="_btnCrossPagePost" runat="server" Text="Post to Alternate" PostBackUrl="~/Alternate.aspx"/>
            </asp:View>
        </asp:MultiView>
       
    </div>
    </form>
</body>
</html>
