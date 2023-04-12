using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class AddMaterial
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}