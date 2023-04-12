using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.WeChatClient.Entries.Entries;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserTags
    {
        /// <summary>
        /// 
        /// </summary>

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
        public List<Entities.Platforms.WeChat.UserTags> tags { get; set; }
After:
        public List<UserTags> tags { get; set; }
*/
        public List<UserTags> tags { get; set; }
    }
}