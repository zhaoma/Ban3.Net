/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出时间点）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Outputs.Values;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 某个时间点的索引值组
/// </summary>
public class PointOfTime
        : Record
{
    /// <summary>
    /// 成交额
    /// </summary>
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public AMOUNT? Amount { get; set; }

    /// <summary>
    /// 乖离
    /// </summary>
    [JsonProperty("bias", NullValueHandling = NullValueHandling.Ignore)]
    public BIAS? Bias { get; set; }

    /// <summary>
    /// 顺势指标(唐纳德·蓝伯特)
    /// </summary>
    [JsonProperty("cci", NullValueHandling = NullValueHandling.Ignore)]
    public CCI? Cci { get; set; }

    /// <summary>
    /// 趋向指标(威尔斯·威尔德)
    /// </summary>
    [JsonProperty("dmi", NullValueHandling = NullValueHandling.Ignore)]
    public DMI? Dmi { get; set; }

    /// <summary>
    /// 轨道线
    /// </summary>
    [JsonProperty("ene", NullValueHandling = NullValueHandling.Ignore)]
    public ENE? Ene { get; set; }

    /// <summary>
    /// 慢速随机指标(乔治·莱恩)
    /// </summary>
    [JsonProperty("kd", NullValueHandling = NullValueHandling.Ignore)]
    public KD? Kd { get; set; }

    /// <summary>
    /// 均线
    /// </summary>
    [JsonProperty("ma", NullValueHandling = NullValueHandling.Ignore)]
    public MA? Ma { get; set; }

    /// <summary>
    /// 指数平滑移动平均线(查拉尔德·阿佩尔)
    /// </summary>
    [JsonProperty("macd", NullValueHandling = NullValueHandling.Ignore)]
    public MACD? Macd { get; set; }

    /// <summary>
    /// 当期收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Close { get; set; }
}