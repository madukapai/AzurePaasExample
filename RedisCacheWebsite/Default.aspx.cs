using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackExchange.Redis;
using System.Configuration;
using Newtonsoft.Json;

namespace RedisCacheWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// 取得Redis Cache的連線字串
        /// </summary>
        static string strConn = ConfigurationManager.ConnectionStrings["Microsoft.Azure.RedisCache.ConnectionString"].ToString();
        /// <summary>
        /// 定義延遲連線
        /// </summary>
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(strConn);
        });
        /// <summary>
        /// 取得Redis Cache靜態連線物件
        /// </summary>
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        /// <summary>
        /// 頁面讀取的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取得快取的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetCache_Click(object sender, EventArgs e)
        {
            IDatabase cache = Connection.GetDatabase();
            string strValue = cache.StringGet(txtKey.Text);
            txtValue.Text = strValue;
        }

        /// <summary>
        /// 寫入快取的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetCache_Click(object sender, EventArgs e)
        {
            IDatabase cache = Connection.GetDatabase();
            cache.StringSet(txtKey.Text, txtValue.Text);
        }

        /// <summary>
        /// 將物件轉換成JSON格式的字串，並存入Redis Cache之中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetObjectToCache_Click(object sender, EventArgs e)
        {
            var objUser = new User()
            {
                UserId = "maduka",
                UserName = "Chun Yi Pai"
            };

            IDatabase cache = Connection.GetDatabase();
            cache.StringSet("UserObj", JsonConvert.SerializeObject(objUser));

            liObject.Text = cache.StringGet("UserObj");
        }
    }

    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}