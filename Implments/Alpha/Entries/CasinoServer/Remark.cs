//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// Casino标的备注(每日行情与指标值)
/// </summary>
public class Remark : IRemark
{
    /// <summary>
    /// 当日价格信息
    /// </summary>
    [JsonProperty("dayPrice", NullValueHandling = NullValueHandling.Ignore)]
    public IPrice DayPrice { get; set; }

    /// <summary>
    /// 各周期指标值
    /// </summary>
    [JsonProperty("outputs", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<CycleIs, IOutput> Outputs { get; set; }

    /// <summary>
    /// 买卖建议
    /// </summary>
    [JsonProperty("suggest", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SuggestIs Suggest { get; set; }

}
