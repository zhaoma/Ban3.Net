//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// Casino市场标的信息
/// </summary>
public class Stock : IStock
{
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;
}
