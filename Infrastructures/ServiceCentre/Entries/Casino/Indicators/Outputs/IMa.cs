//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 价格均线指标
/// </summary>
public interface IMa : IEvaluation<IMa>
{
    /// <summary>
    /// 价格均线集合
    /// </summary>
    [JsonProperty( "lines" )]
    IEnumerable<ILine<decimal>> Lines { get; set; }
}