//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IInternetResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonProperty( "statusCode" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    HttpStatus StatusCode { get; set; }

    /// <summary>
    /// 响应体
    /// </summary>
    [JsonProperty( "response" )]
    IInternetData Response { get; set; }
}