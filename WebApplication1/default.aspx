<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Push Text Message" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Push Sticker Message" />
    
    </div>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Push Tempalte Message" />
        </p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Confirm" />
        <p>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Carousel" />
        </p>
    </form>
</body>
</html>
