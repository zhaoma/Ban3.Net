using Newtonsoft.Json;

namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class SceneStr
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scene_str")]
        public string SceneString { get; set; } = string.Empty;
    }
}