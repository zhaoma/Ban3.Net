using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Servers
{
    /// <summary>
    /// 网络资源
    /// </summary>
    public class NetResource
    {
        /// <summary>
        /// 
        /// </summary>
        public NetResource() { }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Authenticators.BasicAuthentication BasicAuthentication { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Clients.OAuth1 OAuth1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OAuth1Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OAuth2Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JWTToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Method { get; set; } = "Get";

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> QueryParameters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> HeaderParameters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        ///
        /// application/json
        /// application/xml
        /// multipart/form-data
        /// text/javascript
        /// text/json
        /// text/x-json
        /// *+json
        /// </summary>
        public string ContentType { get; set; } = "application/json";

        /// <summary>
        /// 
        /// </summary>
        public string Charset = "UTF-8";

        /// <summary>
        /// 资源是jsonp
        /// </summary>
        public virtual bool ResourceIsJsonp { get; set; } = false;

        /// <summary>
        /// jsonp前缀
        /// </summary>
        public virtual string JsonpPrefix { get; set; } = string.Empty;
    }
}