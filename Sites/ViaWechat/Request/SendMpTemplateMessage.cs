using System;

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.WeChat
{
    /// <summary>
    /// 发送模版消息（小程序）
    /// </summary>
    public class SendMpTemplateMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "token" )]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 接收人的 open id
        /// </summary>
        [JsonProperty( "toUserOpenId" )]
        public string ToUserOpenId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "formId" )]
        public string FormId { get; set; } = string.Empty;

        /// <summary>
        /// 消息模板
        /// </summary>
        [JsonProperty( "tpltId" )]
        public string TpltId { get; set; } = string.Empty;

        /// <summary>
        /// 小程序跳转的页面路径
        /// </summary>
        [JsonProperty( "pageUrl" )]
        public string PageUrl { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "keyword1" )]
        public string Keyword1 { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "keyword2" )]
        public string Keyword2 { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "keyword3" )]
        public string Keyword3 { get; set; } = string.Empty;
    }
}