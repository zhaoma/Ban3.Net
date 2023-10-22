using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 顺势指标
/// </summary>
public interface ICci : IStockRecord, IEvaluation<ICci>
{
    /// <summary>
    /// CCI
    /// </summary>
    [JsonProperty("cci")]
    decimal CCI { get; set; }
}

