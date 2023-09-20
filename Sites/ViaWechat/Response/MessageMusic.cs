using Ban3.Platforms.WeChatClient.Entries.Content;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageMusic
            : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>

/* Unmerged change from project 'Common (netstandard2.1)'
Before:
        public Entities.Platforms.WeChat.Music Music { get; set; }
After:
        public Music Music { get; set; }
*/
        public MusicInfo Music { get; set; }
    }
}