namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class MessageText : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}