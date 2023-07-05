/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（记录基类）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

/// <summary>
/// 记录基类
/// </summary>
public class Record
{
    /// <summary>
    /// 记录时间
    /// </summary>
    [JsonProperty("tradeDate", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(TradeDateConverter))]
    public DateTime TradeDate { get; set; }
}