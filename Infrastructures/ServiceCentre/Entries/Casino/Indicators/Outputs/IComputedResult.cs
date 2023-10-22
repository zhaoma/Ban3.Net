using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 计算结果声明
/// </summary>
public interface IComputedResult : IStockRecord,IEvaluation<IComputedResult>
{
    /// <summary>
    /// 分析周期
    /// </summary>
    [JsonProperty("analysisCycle")]
    [JsonConverter(typeof(StringEnumConverter))]
    AnalysisCycle AnalysisCycle { get; set; }

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
    /// 异同移动平均线指标
    /// </summary>
    [JsonProperty("macd")]
    IMacd Macd { get; set; }
}

