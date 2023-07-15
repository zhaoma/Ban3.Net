using System;
using System.Net;
using System.Net.Http;
using Ban3.Infrastructures.NetHttp.Interfaces;

namespace Ban3.Infrastructures.NetHttp.Entries;

/// <summary>
/// 目标主机定义
/// </summary>
public class TargetHost : ITargetHost
{
    /// <summary>
    /// 匿名访问
    /// </summary>
    public bool Anonymous { get; set; } = false;

    /// <summary>
    /// 域名根网址
    /// </summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 域
    /// </summary>
    public string Domain { get; set; } = string.Empty;

    /// <summary>
    /// 认证方式
    /// </summary>
    public string AuthenticationType { get; set; } = "Basic";

    static readonly object ObjectLock = new ();

    /// <summary>
    /// 实例化，单例方式创建client
    /// </summary>
    /// <returns></returns>
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
