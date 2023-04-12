using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class GetOpenId
            : ErrorInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string unionid { get; set; }
    }
}