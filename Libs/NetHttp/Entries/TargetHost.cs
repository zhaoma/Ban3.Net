using System;
using System.Net;
using System.Net.Http;

namespace Ban3.Infrastructures.NetHttp.Entries
{
    public class TargetHost
    {
        public bool Anonymous { get; set; } = false;

        public string BaseUrl { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public string AuthenticationType { get; set; } = "Basic";

        public HttpClient Client()
        {
            return _client = _client ?? (Anonymous
                ? new HttpClient()
                : new HttpClient(Handler()));
        }

        private HttpClient _client;

        private HttpClientHandler Handler()
        {
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

    }
}
