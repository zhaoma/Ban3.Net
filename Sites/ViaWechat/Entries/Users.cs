using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "openid")]
        public List<string>? OpenId { get; set; }
    }
}