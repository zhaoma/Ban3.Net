namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class MessageLink : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }
}