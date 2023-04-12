using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginResult
            : Response
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "openid" )]
        public string OpenID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string unionid { get; set; }
    }
}