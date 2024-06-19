//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components.Entries.HttpServer;
using Ban3.Infrastructures.Contracts.Components;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Components.HttpServer;

/// <summary>
/// 使用Net.Http实现数据爬虫服务
/// </summary>
public class UtilizeNetHttp : IHttpServer
{
    private readonly ILoggerServer _logger;
    private HttpClient _client;
    static readonly object ObjectLock = new();

    private HttpClient Client(Host host)
    {
        if (_client != null) return _client;

        lock (ObjectLock)
        {
            if (host.Anonymous)
            {
                _client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };
            }
            else
            {
                var defaultCredential = string.IsNullOrEmpty(host.Domain)
                    ? new NetworkCredential(host.UserName, host.Password)
                    : new NetworkCredential(host.UserName, host.Password, host.Domain);

                var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    AllowAutoRedirect = true,
                    MaxConnectionsPerServer = 100,

                    Credentials = new CredentialCache
                    {
                        { new Uri(host.BaseUrl), host.AuthenticationType, defaultCredential }
                    }
                };

                _client ??= host.Anonymous
                    ? new HttpClient { Timeout = TimeSpan.FromMinutes(5) }
                    : new HttpClient(handler)
                    {
                        BaseAddress = new Uri(host.BaseUrl),
                        Timeout = TimeSpan.FromMinutes(5)
                    };
            }
        }

        return _client;
    }

    private HttpRequestMessage Request(Resource resource)
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(resource.Url),
            Method = new HttpMethod(resource.Method)
        };

        if (resource.Bytes != null)
            request.Content = new ByteArrayContent(resource.Bytes);

        if (resource.StreamContent != null)
            request.Content = new StreamContent(resource.StreamContent);

        if (!string.IsNullOrEmpty(resource.StringContent))
            request.Content = new StringContent(
                resource.StringContent,
                Encoding.GetEncoding(resource.ContentEncoding),
                resource.ContentMediaType);

        if (resource.Headers != null && resource.Headers.Any())
        {
            foreach (var header in resource.Headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        if (!string.IsNullOrEmpty(resource.Charset))
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            request.Headers.Add("Accept-Charset", resource.Charset);
        }

        return request;

    }

    private async Task<HttpResponseMessage> Request(Host host, Resource resource)
        => await Client(host).SendAsync(Request(resource));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public UtilizeNetHttp(ILoggerServer logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    public async Task<T> RequestGeneric<T>(Host host, Resource resource)
    {
        var content = await RequestString(host, resource);

        if (resource.ResourceIsJsonp)
        {
            content = content.RemoveJsonpTags(resource.JsonpPrefix);
        }

        return content.JsonToObj<T>()!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    public async Task<bool> RequestVoid(Host host, Resource resource)
    {
        try
        {
            using var response = await Request(host, resource);

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    public async Task<string> RequestString(Host host, Resource resource)
    {
        using var response = await Request(host, resource);
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    public async Task<byte[]> RequestBytes(Host host, Resource resource)
    {
        using var response = await Request(host, resource);
        return await response.Content.ReadAsByteArrayAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <param name="savePath"></param>
    /// <returns></returns>
    public async Task<bool> Download(Host host, Resource resource, string savePath)
    {
        try
        {
            using var response = await Request(host, resource);

            var inputStream = await response.Content.ReadAsStreamAsync();

            using var fileStream = File.Create(savePath);

            inputStream.CopyToAsync(fileStream);

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }
}