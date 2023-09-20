/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            授权令牌
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Ban3.Platforms.WeChatClient.Entries.AUTH
{
    /// <summary>
    /// 授权令牌
    /// </summary>
    [DataContract]
    public class AccessToken
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("access_token")]
        public string AcessToken { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}