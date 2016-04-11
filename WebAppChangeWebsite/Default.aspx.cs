using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace WebAppChangeWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDateTimeNow.Text = DateTime.Now.ToString();
            lblUtcTime.Text = DateTime.UtcNow.ToString();
        }

        /// <summary>
        /// 寫入Session到資料庫的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetSession_Click(object sender, EventArgs e)
        {
            // 基本上Session寫法不用改，需要注意的就是要放入Session的物件需要序列化
            User objUser = new User() { UserId = "maduka", UserName = "Chun Yi Pai" };
            Session["objUser"] = objUser;

            // 取得Session的值
            liUser.Text = JsonConvert.SerializeObject(Session["objUser"]);
        }
    }

    [Serializable]
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}