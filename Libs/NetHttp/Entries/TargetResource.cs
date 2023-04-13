using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Ban3.Infrastructures.NetHttp.Request;

namespace Ban3.Infrastructures.NetHttp.Entries
{
    public class TargetResource
    {
        public string Url { get; set; } = string.Empty;

        public string Method { get; set; } = "Get";

        public Dictionary<string, string>? Headers { get; set; } = null;

        public Body? Body { get; set; } = null;
        
        public HttpRequestMessage Request()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(Url),
                Method =new HttpMethod( Method),
                Content = Body?.Content()
            };

            if (Headers != null && Headers.Any())
            {
                foreach (var header in Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            return request;
        }
    }
}
