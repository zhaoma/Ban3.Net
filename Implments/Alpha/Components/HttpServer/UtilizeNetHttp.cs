//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components.Entries.HttpServer;
using Ban3.Infrastructures.Components.Services;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Components.HttpServer;

public class UtilizeNetHttp : IHttpServer
{
    private readonly ILoggerServer _logger;
    private HttpClient _client;
    static readonly object ObjectLock = new();

    private HttpClient Client(IHost host)
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

    private HttpRequestMessage Request(IResource resource)
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(resource.Url),
            Method = new HttpMethod(resource.Method)
        };

        if (resource.Bytes != null)
            request.Content= new ByteArrayContent(resource.Bytes);

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

    private async Task<HttpResponseMessage> Request(IHost host, IResource resource)
        =>await Client(host).SendAsync(Request(resource));

    public UtilizeNetHttp(ILoggerServer logger)
    {
        _logger = logger;
    }

    public async Task<T> RequestGeneric<T>(IHost host, IResource resource)
    {
        var content = await RequestString(host, resource);

        if (resource.ResourceIsJsonp)
        {
            content = content.RemoveJsonpTags(resource.JsonpPrefix);
        }

        return content.JsonToObj<T>();
    }

    public async Task<bool> RequestVoid(IHost host, IResource resource)
    {
        try
        {
            using var response = await Request(host,resource);

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }

    public async Task<string> RequestString(IHost host, IResource resource)
    {
        using var response = await Request(host, resource);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<byte[]> RequestBytes(IHost host, IResource resource)
    {
        using var response = await Request(host, resource);
        return await response.Content.ReadAsByteArrayAsync();
    }

    public async Task<bool> Download(IHost host, IResource resource, string savePath)
    {
        try
        {
            using var response = await Request(host, resource);

            var inputStream =await response.Content.ReadAsStreamAsync();

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