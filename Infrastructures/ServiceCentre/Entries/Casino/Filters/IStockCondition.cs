// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Filters;

/// <summary>
/// 筛选条件
/// </summary>
public interface IStockCondition
{
    /// <summary>
    /// 周期
    /// </summary>
    [JsonProperty( "analysisCycle" )]
    AnalysisCycle? AnalysisCycle { get; set; }

    /// <summary>
    /// 包含特征
    /// </summary>
    [JsonProperty( "includeKeys" )]
    IEnumerable<string> IncludeKeys { get; set; }

    /// <summary>
    /// 不包含特征
    /// </summary>
    [JsonProperty( "excludeKeys" )]
    IEnumerable<string> ExcludeKeys { get; set; }
}