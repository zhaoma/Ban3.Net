//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 指标计算结果
/// </summary>
public class Output : IOutput
{
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public IAMOUNT AMOUNT { get; set; }

    [JsonProperty("ma", NullValueHandling = NullValueHandling.Ignore)]
    public IMA MA { get; set; }

    [JsonProperty("macd", NullValueHandling = NullValueHandling.Ignore)]
    public IMACD MACD { get; set; }

    [JsonProperty("mx", NullValueHandling = NullValueHandling.Ignore)]
    public IMX MX { get; set; }

    [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Keys { get; set; }
}
