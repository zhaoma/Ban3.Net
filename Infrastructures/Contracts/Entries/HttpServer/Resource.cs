//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System.Collections.Generic;
using System.IO;

namespace Ban3.Infrastructures.Components.Entries.HttpServer;

/// <summary>
/// HTTP请求资源
/// </summary>
public class Resource:IZero
{
    /// <summary>
    /// 资源地址
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 请求方法
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// 使用字符集
    /// </summary>
    public string Charset { get; set; } = string.Empty;

    /// <summary>
    /// 资源是jsonp
    /// </summary>
    public bool ResourceIsJsonp { get; set; }

    /// <summary>
    /// jsonp前缀
    /// </summary>
    public string JsonpPrefix { get; set; } = string.Empty;

    /// <summary>
    /// 请求头
    /// </summary>
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// 请求字节组
    /// </summary>
    public byte[]? Bytes { get; set; }

    /// <summary>
    /// 请求流
    /// </summary>
    public Stream? StreamContent { get; set; }

    /// <summary>
    /// 请求文本
    /// </summary>
    public string StringContent { get; set; } = string.Empty;

    /// <summary>
    /// 响应媒体类型
    /// </summary>
    public string ContentMediaType { get; set; } = string.Empty;

    /// <summary>
    /// 响应字符编码
    /// </summary>
    public string ContentEncoding { get; set; } = string.Empty;
}
