using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Ban3.Infrastructures.NetHttp.Interfaces;
using Ban3.Infrastructures.NetHttp.Request;

namespace Ban3.Infrastructures.NetHttp.Entries;

/// <summary>
/// 目标资源
/// </summary>
public class TargetResource : ITargetResource
{
    /// <summary>
    /// 资源地址
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 请求方式
    /// </summary>
    public string Method { get; set; } = "Get";

    /// <summary>
    /// 字符集
    /// </summary>
    public string Charset { get; set; } 

    /// <summary>
    /// 是否jsonp响应
    /// </summary>
    public bool ResourceIsJsonp { get; set; } = false;

    /// <summary>
    /// jsonp前缀
    /// </summary>
    public string JsonpPrefix { get; set; } = string.Empty;

    /// <summary>
    /// 附加头部信息
    /// </summary>
    public Dictionary<string, string> Headers { get; set; } = null;

    /// <summary>
    /// 请求体
    /// </summary>
    public Body Body { get; set; } = null;

    /// <summary>
    /// 转HttpRequestMessage
    /// </summary>
    /// <returns></returns>
    public HttpRequestMessage Request()
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(Url),
            Method = new HttpMethod(Method),
            Content = Body?.Content()
        };

        if (Headers != null && Headers.Any())
        {
            foreach (var header in Headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        if (!string.IsNullOrEmpty(Charset))
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            request.Headers.Add("Accept-Charset", Charset);
        }

        return request;
    }
}
