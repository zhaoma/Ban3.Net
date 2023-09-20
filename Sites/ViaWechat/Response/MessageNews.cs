using System.Collections.Generic;
using Ban3.Platforms.WeChatClient.Entries.Content;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageNews
            : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int ArticleCount
        {
            get
            {

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
                return (Articles ?? new List<Entities.Platforms.WeChat.Article>()).Count;
After:
                return (Articles ?? new List<Article>()).Count;
*/
                return (Articles ?? new List<ArticleInfo>()).Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
        public List<Entities.Platforms.WeChat.Article> Articles { get; set; }
After:
        public List<Article> Articles { get; set; }
*/
        public List<ArticleInfo> Articles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageNews()
        {

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
            Articles = new List<Entities.Platforms.WeChat.Article>();
After:
            Articles = new List<Article>();
*/
            Articles = new List<ArticleInfo>();
        }
    }
}