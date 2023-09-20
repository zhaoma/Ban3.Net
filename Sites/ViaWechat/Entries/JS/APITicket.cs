using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.JS
{
    public class APITicket
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "errcode")]
        public int errcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "errmsg")]
        public string errmsg { get; set; }

        /// <summary>
        /// JS-SDK使用权限
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { get; set; }
    }
}