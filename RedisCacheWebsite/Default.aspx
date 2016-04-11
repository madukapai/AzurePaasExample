<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RedisCacheWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        1.請先加入StackExchange.Redis的Nuget套件<br />
        2.修改Web.Config中的連線字串
        <p>Key：<asp:TextBox runat="server" ID="txtKey"></asp:TextBox>
        <asp:Button runat="server" ID="btnGetCache" Text="Get Cache" OnClick="btnGetCache_Click" />
        </p>
        <p>Value：<asp:TextBox runat="server" ID="txtValue"></asp:TextBox>
        <asp:Button runat="server" ID="btnSetCache" Text="Set Cache" OnClick="btnSetCache_Click" />
        </p>
        <asp:Button runat="server" ID="btnSetObjectToCache" Text="Set Object To Cache" OnClick="btnSetObjectToCache_Click" /><br />
        <asp:Literal runat="server" ID="liObject"></asp:Literal>
    </div>
    </form>
</body>
</html>
