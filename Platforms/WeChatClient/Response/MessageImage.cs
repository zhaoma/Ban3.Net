using System.Collections.Generic;
using Ban3.Platforms.WeChatClient.Entries.Content;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageImage
            : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
        public Entities.Platforms.WeChat.Media Image { get; set; }
After:
        public Media Image { get; set; }
*/

/* Unmerged change from project 'Common (net5.0)'
Before:
        public Entities.Platforms.WeChat.Entries.Media Image { get; set; }
After:
        public Media Image { get; set; }
*/
        public MediaItem Image { get; set; }
    }
}