using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.SignalRClient
{
    /// <summary>
    /// 
    /// </summary>
	public class Notify
    {
        [JsonProperty("from")]
        public string From { get; set; } = string.Empty;

        [JsonProperty("to")]
        public string To { get; set; } = string.Empty;

        /// <summary>
        /// 关键字
        /// </summary>
        [JsonProperty("key")]
        public string ControlCode { get; set; } = string.Empty;

        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("message")]
        public string Content { get; set; } = string.Empty;
        
    }
}

