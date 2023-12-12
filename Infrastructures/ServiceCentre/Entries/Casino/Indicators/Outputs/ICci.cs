// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 顺势指标
/// </summary>
public interface ICci : IEvaluation<ICci>
{
    /// <summary>
    /// CCI
    /// </summary>
    [JsonProperty( "cci" )]
    decimal CCI { get; set; }
}