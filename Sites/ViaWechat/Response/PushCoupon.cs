using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class PushCoupon
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> touser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ResponseCard wxcard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msgtype { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResponseCard
    {
        /// <summary>
        /// 
        /// </summary>
        public string card_id { get; set; } = string.Empty;
    }
}