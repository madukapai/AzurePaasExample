using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationInsightsWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 刻意製造例外狀態並回傳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnException_Click(object sender, EventArgs e)
        {
            try
            {
                // 在這裡刻意製造錯誤
                string strValue = "abc";
                int intValue = int.Parse(strValue);
            }
            catch (Exception ex)
            {
                // Note: A single instance of telemetry client is sufficient to track multiple telemetry items.
                var ai = new TelemetryClient();
                ai.TrackException(ex);
            }
        }

        /// <summary>
        /// 建立自訂的回傳事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateCustomEvent_Click(object sender, EventArgs e)
        {
            var tc = new TelemetryClient();
            // Set up some properties:
            var properties = new Dictionary<string, string> { { "Time", DateTime.UtcNow.ToString() }, { "Game", "GameName" }, { "Difficulty", "Hard" } };
            var measurements = new Dictionary<string, double> { { "GameScore", 20 }, { "Opponents", 1 } };
            // 傳送自訂事件
            tc.TrackEvent("WinGame", properties, measurements);
            // 傳送自訂資料與度量值
            tc.TrackMetric("GameScore", 20, properties);
        }
    }
}