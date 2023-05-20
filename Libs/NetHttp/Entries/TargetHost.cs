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

    public HttpClient Client()
    {
        return _client = _client ?? (Anonymous
            ? new HttpClient { Timeout = TimeSpan.FromMinutes(1) }
            : new HttpClient(Handler())
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromMinutes(1)
            });
    }

    private HttpClient _client;

    private HttpClientHandler Handler()
    {
        Console.WriteLine("Create Client");
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
