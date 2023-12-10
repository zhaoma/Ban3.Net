// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

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
    /// 成交量均线
    /// </summary>
    [JsonProperty( "values" )]
    IEnumerable<IStockValue> Values { get; set; }

    /// <summary>
    /// 指标类型
    /// </summary>
    [JsonProperty( "indicatorIs" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    IndicatorIs IndicatorIs { get; set; }
}