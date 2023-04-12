using Ban3.Platforms.WeChatClient.Entries.Entries;
using Newtonsoft.Json;

namespace Ban3.Platforms.WeChatClient.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionInt
    {
        /// <summary>
        /// 场景编号
        /// </summary>
        [JsonProperty("scene")]
        public SceneInt? Scene { get; set; }
    }
}