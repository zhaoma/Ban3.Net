//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino笔记
/// </summary>
public class Remark
{
    /// <summary>
    /// 参考价格
    /// </summary> 
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Price DayPrice { get; set; }

    /// <summary>
    /// 日线价格，指标值,关键特征
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Output DayOutput { get; set; }

    /// <summary>
    /// 周线价格，指标值,关键特征
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Output WeekOutput { get; set; }

    /// <summary>
    /// 月线价格，指标值,关键特征
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Output MonthOutput { get; set; }

    /// <summary>
    /// 买卖建议
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public SuggestIs Suggest { get; set; }
}
