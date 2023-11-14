// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 互联网资源声明
/// </summary>
public interface IInternetResource
{
    /// <summary>
    /// 地址
    /// </summary>
    [JsonProperty( "url" )]
    string Url { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    [JsonProperty( "method" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    HttpMethod Method { get; set; }

    /// <summary>
    /// 字符集
    /// </summary>
    [JsonProperty( "charset" )]
    string Charset { get; set; }

    /// <summary>
    /// 资源是jsonp
    /// </summary>
    [JsonProperty( "isJsonp" )]
    bool IsJsonp { get; set; }

    /// <summary>
    /// jsonp前缀
    /// </summary>
    [JsonProperty( "jsonPrefix" )]
    string JsonpPrefix { get; set; }

    /// <summary>
    /// 请求头
    /// </summary>
    [JsonProperty( "headers" )]
    IDictionary<string, string> Headers { get; set; }

    /// <summary>
    /// 请求体
    /// </summary>
    [JsonProperty( "request" )]
    IInternetData Request { get; set; }

    /// <summary>
    /// QueryString dictionary
    /// </summary>
    [JsonProperty( "query" )]
    IDictionary<string, string> Query { get; set; }
}