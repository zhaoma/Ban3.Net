using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.WeChatClient.Entries;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUsers
    {
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Users data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string next_openid { get; set; }
    }
}