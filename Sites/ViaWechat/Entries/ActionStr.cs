using Ban3.Platforms.WeChatClient.Entries.Entries;
using Newtonsoft.Json;

namespace Ban3.Platforms.WeChatClient.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionStr
    {
        /// <summary>
        /// 场景编码
        /// </summary>
        [JsonProperty("scene")]
        public SceneStr? Scene { get; set; }
    }
}