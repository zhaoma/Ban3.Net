using System.Collections.Generic;
using Ban3.Platforms.WeChatClient.Entries.Content;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageVideo
            : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>

/* Unmerged change from project 'Common (net5.0)'
Before:
        public Entities.Platforms.WeChat.Video? Video { get; set; }
After:
        public Video? Video { get; set; }
*/

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
        public Entities.Platforms.WeChat.Entries.Video? Video { get; set; }
After:
        public Video? Video { get; set; }
*/
        public Video? Video { get; set; }
    }
}