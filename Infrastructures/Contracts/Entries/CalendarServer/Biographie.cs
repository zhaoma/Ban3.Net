//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 传记信息
/// </summary>
public class Biographie : MetaBase
{
    /// <summary>
    /// 简短传记
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; } = string.Empty;
}
