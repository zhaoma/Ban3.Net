//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 计算结果声明
/// </summary>
public interface IComputedResult
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

/// <summary>
/// 指标值
/// </summary>
public interface IStockValue : IStockRecord
{
    /// <summary>
    /// 评分
    /// </summary>
    [JsonProperty( "score" )]
    int Score { get; set; }

    /// <summary>
    /// 特征值
    /// </summary>
    [JsonProperty( "keys" )]
    IEnumerable<string> Keys { get; set; }
}