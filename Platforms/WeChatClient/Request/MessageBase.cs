using System;

namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string FromUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Enums.WeChatRequestMsgType MsgType { get; set; }
    }

    /// <summary>
    /// 接收到请求的消息
    /// </summary>
    public class MessageBase : IMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Enums.WeChatRequestMsgType MsgType { get; set; }
    }
}