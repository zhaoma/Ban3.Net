/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            多媒体项
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace Ban3.Platforms.WeChatClient.Entries.Content
{
    /// <summary>
    /// 多媒体项
    /// </summary>
    public class MediaItem
    {
        /// <summary>
        /// 多媒体标识
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}