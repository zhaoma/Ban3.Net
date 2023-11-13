// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 成交额指标
/// </summary>
public interface IAmount : IStockRecord, IEvaluation<IAmount>
{
    /// <summary>
    /// 均线集合
    /// </summary>
    [JsonProperty("lines")]
    IEnumerable<ILine<double>> Lines { get; set; }
}

