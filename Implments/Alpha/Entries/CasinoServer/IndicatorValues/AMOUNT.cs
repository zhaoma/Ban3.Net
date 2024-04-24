//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 移动平均线指标值
/// </summary>
public class AMOUNT:IAMOUNT
{
    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; } = IndexIs.AMOUNT;

    /// <summary>
    /// 短期,5日线
    /// </summary>
    [JsonProperty("short", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Short { get; set; }

    /// <summary>
    /// 长期,20日线
    /// </summary>
    [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Long { get; set; }
}
