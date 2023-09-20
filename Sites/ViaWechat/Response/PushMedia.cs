using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class PushMedia
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> touser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ResponseNews mpnews { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msgtype { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResponseNews
    {
        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }
    }
}