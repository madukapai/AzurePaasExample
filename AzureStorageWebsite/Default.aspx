<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AzureStorageWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        1.在Web.Config加上儲存體的連線字串<br />
        2.容器的名稱必須都是小寫
    <div>
        容器：<asp:TextBox runat="server" ID="txtContainer" Text="mycontainer"></asp:TextBox><br />
        Blob：<asp:TextBox runat="server" ID="txtBlob" Text="myBlob"></asp:TextBox>
        <p>上傳檔案：<asp:FileUpload runat="server" ID="fupl" /><asp:Button runat="server" ID="btnUpload" Text="Upload File" OnClick="btnUpload_Click" /></p>
        <p>下載檔案：<asp:Button runat="server" ID="btnDownload" Text="Download File" OnClick="btnDownload_Click" /></p>
        <asp:Button runat="server" ID="btnDeleteBlob" Text="Delete Blob" OnClick="btnDeleteBlob_Click" />
        <asp:Button runat="server" ID="btnDeleteContainer" Text="Delete Container" OnClick="btnDeleteContainer_Click" />
    </div>
    </form>
</body>
</html>
