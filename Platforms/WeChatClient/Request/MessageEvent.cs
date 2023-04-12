namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class MessageEvent : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Precision { get; set; }
    }
}