namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageLocation : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Location_X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Location_Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Label { get; set; }
    }
}