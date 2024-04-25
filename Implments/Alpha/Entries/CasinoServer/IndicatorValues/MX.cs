﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 买卖线指标值
/// </summary>
public class MX : IMX
{
    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; } = IndexIs.MX;

    /// <summary>
    /// 买线
    /// </summary>
    [JsonProperty("buy", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Buy { get; set; }

    /// <summary>
    /// 卖线
    /// </summary>
    [JsonProperty("sell", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Sell { get; set; }
}