//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 
/// </summary>
public enum BodyType
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("text")]
    Text,

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("html")]
    Html
}
