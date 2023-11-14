// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 标的特征声明
/// </summary>
public interface IStockFeature : IStockRecord
{
    /// <summary>
    /// 评分
    /// </summary>
    [JsonProperty( "score" )]
    int Score { get; set; }

    /// <summary>
    /// 特征集合
    /// </summary>
    [JsonProperty( "keys" )]
    IEnumerable<string> Keys { get; set; }
}