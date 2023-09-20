using System;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
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
        Enums.WeChatResponseMsgType MsgType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool FuncFlag { get; set; }
    }

    /// <summary>
    /// 响应回复消息
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
        public Enums.WeChatResponseMsgType MsgType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FuncFlag { get; set; }
    }
}