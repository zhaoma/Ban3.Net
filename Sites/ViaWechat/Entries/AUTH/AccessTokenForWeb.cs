/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            Web令牌完整信息
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.AUTH
{
    /// <summary>
    /// Web令牌完整信息
    /// </summary>
    [DataContract]
    public class AccessTokenForWeb
        : AccessToken
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "openid")]
        public string OpenId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "scope")]
        public string Scope { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "unionid")]
        public string UnionId { get; set; } = string.Empty;
    }
}