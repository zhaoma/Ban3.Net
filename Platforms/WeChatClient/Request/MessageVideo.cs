namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class MessageVideo : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
}