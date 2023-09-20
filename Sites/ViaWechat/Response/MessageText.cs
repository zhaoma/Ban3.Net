namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageText
            : MessageBase, IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}