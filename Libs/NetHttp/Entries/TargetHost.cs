using System;
using System.Net;
using System.Net.Http;
using Ban3.Infrastructures.NetHttp.Interfaces;

namespace Ban3.Infrastructures.NetHttp.Entries;

public class TargetHost : ITargetHost
{
    public bool Anonymous { get; set; } = false;

    public string BaseUrl { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Domain { get; set; } = string.Empty;

    public string AuthenticationType { get; set; } = "Basic";

    static readonly object ObjectLock = new ();

    public HttpClient Client()
    {
        if (_client != null) return _client;

        lock (ObjectLock)
        {
            _client ??= Anonymous
                ? new HttpClient { Timeout = TimeSpan.FromMinutes(5) }
                : new HttpClient(Handler())
                {
                    BaseAddress = new Uri(BaseUrl),
                    Timeout = TimeSpan.FromMinutes(5)
                };
        }

        return _client;
    }

    private static HttpClient _client;

    private HttpClientHandler Handler()
    {
        var defaultCredential = string.IsNullOrEmpty(Domain)
            ? new NetworkCredential(UserName, Password)
            : new NetworkCredential(UserName, Password, Domain);
        
        return new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            AllowAutoRedirect = true,
            MaxConnectionsPerServer = 100,
            
            Credentials = new CredentialCache
            {
                { new Uri(BaseUrl), AuthenticationType, defaultCredential }
            }
        };
    }
}
