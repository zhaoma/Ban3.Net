using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 趋向指标，Directional Movement Index
/// </summary>
public interface IDmi : IStockRecord, IEvaluation<IDmi>
{
    /// <summary>
    /// 多头指标
    /// </summary>
    [JsonProperty("pdi")]
    decimal PDI { get; set; }

    /// <summary>
    /// 空头指标
    /// </summary>
    [JsonProperty("mdi")]
    decimal MDI { get; set; }

    /// <summary>
    /// 平均动向指标
    /// </summary>
    [JsonProperty("adx")]
    decimal ADX { get; set; }

    /// <summary>
    /// 动向评估指标
    /// </summary>
    [JsonProperty("adxr")]
    decimal ADXR { get; set; }
}
