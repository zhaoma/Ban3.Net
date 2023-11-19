// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 计算结果声明
/// </summary>
public interface IComputedResult : IStockRecord, IEvaluation<IComputedResult>
{
    /// <summary>
    /// 分析周期
    /// </summary>
    [JsonProperty( "analysisCycle" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    AnalysisCycle AnalysisCycle { get; set; }

    /// <summary>
    /// 成交量均线
    /// </summary>
    [JsonProperty( "results" )]
    IEnumerable<IEvaluation<IParameter>> Results { get; set; }

    IndicatorIs IndicatorIs { get; set; }
}