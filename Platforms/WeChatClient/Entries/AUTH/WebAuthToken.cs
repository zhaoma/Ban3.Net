/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            令牌(Code换取令牌)
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace Ban3.Platforms.WeChatClient.Entries.AUTH
{
    /// <summary>
    /// 令牌
    /// </summary>
    public class WebAuthToken
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("access_token")]
        public AccessTokenForWeb? AcessToken { get; set; }
    }
}