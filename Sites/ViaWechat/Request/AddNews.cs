using System.Collections.Generic;
using Ban3.Platforms.WeChatClient.Entries.Content;

namespace Ban3.Platforms.WeChatClient.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class AddNews
    {
        /// <summary>
        /// 
        /// </summary>

/* Unmerged change from project 'Common (net5.0)'
Before:
        public List<Entities.Platforms.WeChat.News> articles { get; set; }
After:
        public List<News> articles { get; set; }
*/
        public List<NewsDetail> articles { get; set; }
    }
}