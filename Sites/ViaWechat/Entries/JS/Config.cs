using System;
using System.Collections.Generic;

namespace Ban3.Platforms.WeChatClient.Entries.JS
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public bool debug { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string appId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nonceStr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> jsApiList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }

        /// ctor
        public Config()
        {
            appId = "";// Infrastructures.Common.Config.CurrrentEnvironment.Platforms.WeChat.OAuth2Client.AppKey;
            timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            nonceStr = new Guid().ToString("");
            jsApiList = new List<string>
            {
                    "onMenuShareTimeline",
                    "onMenuShareAppMessage",
                    "onMenuShareQQ",
                    "onMenuShareWeibo",
                    "onMenuShareQZone"
            };
        }
    }
}