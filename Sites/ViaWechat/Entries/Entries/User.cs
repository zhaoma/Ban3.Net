using System;
using System.Collections.Generic;

namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public int subscribe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long subscribe_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string unionid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int groupid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> tagid_list { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime SubscribeTime { get; set; }
    }
}