//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 
/// </summary>
public class Stock : IStock
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}
