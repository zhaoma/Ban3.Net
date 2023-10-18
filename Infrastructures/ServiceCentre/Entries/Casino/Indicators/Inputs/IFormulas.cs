using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

/// <summary>
/// 公式声明
/// </summary>
public interface IFormulas
{
    /// <summary>
    /// 成交量均线
    /// </summary>
    [JsonProperty("amount")]
    IAmount Amount { get; set; }

    /// <summary>
    /// 乖离率
    /// </summary>
    [JsonProperty("bias")]
    IBias Bias { get; set; }

    /// <summary>
    /// 顺势指标
    /// </summary>
    [JsonProperty("cci")]
    ICci Cci { get; set; }

    /// <summary>
    /// 趋向指标
    /// </summary>
    [JsonProperty("dmi")]
    IDmi Dmi { get; set; }

    /// <summary>
    /// 能量包指标
    /// </summary>
    [JsonProperty("ene")]
    IEne Ene { get; set; }

    /// <summary>
    /// 随机震荡指数
    /// </summary>
    [JsonProperty("kd")]
    IKd Kd { get; set; }

    /// <summary>
    /// 价格均线
    /// </summary>
    [JsonProperty("ma")]
    IMa Ma { get; set; }

    /// <summary>
    /// 评分
    /// </summary>
    [JsonProperty("score")]
    IMacd Macd { get; set; }
}

