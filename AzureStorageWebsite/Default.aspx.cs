using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AzureStorageWebsite.App_Code;
using System.IO;

namespace AzureStorageWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 上傳檔案的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            new AzureStorage().UploadToBlob(txtContainer.Text, txtBlob.Text, fupl.PostedFile.InputStream);
        }

        /// <summary>
        /// 下載檔案的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            MemoryStream filestream = new AzureStorage().DownloadBlob(txtContainer.Text, txtBlob.Text);

            byte[] bytes = new byte[(int)filestream.Length];
            filestream.Read(bytes, 0, bytes.Length);
            filestream.Close();

            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(txtBlob.Text, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        /// <summary>
        /// 刪除Blob
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteBlob_Click(object sender, EventArgs e)
        {
            new AzureStorage().DeleteBlob(txtContainer.Text, txtBlob.Text);
        }

        /// <summary>
        /// 刪除容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteContainer_Click(object sender, EventArgs e)
        {
            new AzureStorage().DeleteContainer(txtContainer.Text);
        }
    }
}