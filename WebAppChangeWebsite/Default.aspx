<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppChangeWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        1.在web.config中設定DefaultConnection的值，更改Session的mode為Custom<br />
        2.到Azure Web App上加入appSetting的Time Zone設定
    <div>
        UTC TIME：<asp:Label runat="server" ID="lblUtcTime"></asp:Label><br />
        DateTime Now：<asp:Label runat="server" ID="lblDateTimeNow"></asp:Label>

        <p><asp:Button runat="server" ID="btnSetSession" Text="Set Session To Db" OnClick="btnSetSession_Click" /></p>
        <asp:Literal ID="liUser" runat="server"></asp:Literal>
        
    </div>
    </form>
</body>
</html>
