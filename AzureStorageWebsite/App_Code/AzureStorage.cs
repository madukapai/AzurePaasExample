using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Configuration;

namespace AzureStorageWebsite.App_Code
{
    public class AzureStorage
    {
        string strConn = ConfigurationManager.ConnectionStrings["Microsoft.Azure.Storage.ConnectionString"].ToString();

        CloudStorageAccount storageAccount;
        CloudBlobClient blobClient;
        CloudBlobContainer container;

        /// <summary>
        /// 初始化儲存體物件的動作
        /// </summary>
        public AzureStorage()
        {
            storageAccount = CloudStorageAccount.Parse(strConn);
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// 建立不存在的容器
        /// </summary>
        /// <param name="strContainer"></param>
        /// <param name="objPermissions"></param>
        public CloudBlobContainer CreateContainer(string strContainer, BlobContainerPermissions objPermissions)
        {
            container = blobClient.GetContainerReference(strContainer);

            bool blflag = container.CreateIfNotExists();

            // 如果有建立成功，就設定權威，已存在的容器會回傳false
            if (blflag)
                container.SetPermissions(objPermissions);

            return container;
        }

        /// <summary>
        /// 上傳Blob的動作
        /// </summary>
        /// <param name="strContainer"></param>
        /// <param name="strBlobName"></param>
        /// <param name="fileStream"></param>
        public void UploadToBlob(string strContainer, string strBlobName, Stream fileStream)
        {
            // 確定容器是否存在，不存在就建立新的容器
            CloudBlobContainer container = this.CreateContainer(strContainer, new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            // 上傳Blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(strBlobName);
            blockBlob.UploadFromStream(fileStream);
        }

        /// <summary>
        /// 下載Blob的內容
        /// </summary>
        /// <param name="strContainer"></param>
        /// <param name="strBlobName"></param>
        /// <returns></returns>
        public MemoryStream DownloadBlob(string strContainer, string strBlobName)
        {
            MemoryStream fileStream = new MemoryStream();
            // 確定容器是否存在，不存在就建立新的容器
            CloudBlobContainer container = this.CreateContainer(strContainer, new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            // 下載Blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(strBlobName);

            if (blockBlob != null)
                blockBlob.DownloadToStream(fileStream);

            return fileStream;
        }

        /// <summary>
        /// 刪除Blob的動作
        /// </summary>
        /// <param name="strContainer"></param>
        /// <param name="strBlobName"></param>
        public void DeleteBlob(string strContainer, string strBlobName)
        {
            // 確定容器是否存在，不存在就建立新的容器
            CloudBlobContainer container = this.CreateContainer(strContainer, new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            // 刪除Blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(strBlobName);

            if (blockBlob != null)
                blockBlob.Delete();
        }

        /// <summary>
        /// 刪除容器的動作
        /// </summary>
        /// <param name="strContainer"></param>
        public void DeleteContainer(string strContainer)
        {
            CloudBlobContainer container = this.CreateContainer(strContainer, new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });
            if (container != null)
                container.Delete();
        }
    }
}
