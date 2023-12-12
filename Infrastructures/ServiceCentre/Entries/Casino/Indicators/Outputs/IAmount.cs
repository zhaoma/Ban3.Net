// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 成交额指标
/// </summary>
public interface IAmount : IEvaluation<IAmount>
{
    /// <summary>
    /// 均线集合
    /// </summary>
    [JsonProperty( "lines" )]
    IEnumerable<ILine<double>> Lines { get; set; }
}