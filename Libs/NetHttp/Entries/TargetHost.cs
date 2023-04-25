using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Ban3.Infrastructures.NetHttp.Entries
{
    public class TargetHost
    {
        public bool Anonymous = false;

        public string BaseUrl { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public string AuthenticationType { get; set; } = "Basic";

        public HttpClientHandler Handler()
        {
            Console.WriteLine("prepare new client handler.");
            var defaultCredential = string.IsNullOrEmpty(Domain)
                ? new NetworkCredential(UserName, Password)
                : new NetworkCredential(UserName, Password, Domain);

            return new HttpClientHandler
            {
                AllowAutoRedirect = true,
                MaxConnectionsPerServer = 10,
                Credentials = new CredentialCache
                {
                    { new Uri(BaseUrl), AuthenticationType, defaultCredential }
                }
            };
        }

        private HttpClient? _client ;

        public HttpClient Client()
        {
            if (_client == null)
            {
                Console.WriteLine("prepare client");
            }

            return _client ??= Anonymous
                ? new HttpClient()
                : new HttpClient(Handler());
        }
    }
}
