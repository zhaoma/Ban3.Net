//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 指数平滑异同移动平均线指标值
/// </summary>
public class MACD : IMACD
{
    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; } = IndexIs.MACD;

    /// <summary>
    /// 短期线
    /// </summary>
    [JsonProperty("dif", NullValueHandling = NullValueHandling.Ignore)]
    public decimal DIF { get; set; }

    /// <summary>
    /// 长期线
    /// </summary>
    [JsonProperty("dea", NullValueHandling = NullValueHandling.Ignore)]
    public decimal DEA { get; set; }

    /// <summary>
    /// 柱状体
    /// </summary>
    [JsonProperty("histogram", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Histogram { get; set; }
}
