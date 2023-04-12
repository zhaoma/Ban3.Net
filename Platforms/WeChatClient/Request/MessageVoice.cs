namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class MessageVoice : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Recognition { get; set; }
    }
}