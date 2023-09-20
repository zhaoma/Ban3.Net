using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.WeChatClient.Entries.Content;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class BatchgetNews
    {
        /// <summary>
        /// 
        /// </summary>
        public int total_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int item_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<NewsList> item { get; set; }
    }
}