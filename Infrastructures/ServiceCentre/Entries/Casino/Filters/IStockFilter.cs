// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Filters;

/// <summary>
/// 筛选策略
/// </summary>
public interface IStockFilter
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty( "id" )]
    string Id { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [JsonProperty( "subject" )]
    string Subject { get; set; }

    /// <summary>
    /// 买入条件集合
    /// </summary>
    [JsonProperty( "buyConditions" )]
    IEnumerable<IStockCondition> BuyConditions { get; set; }

    /// <summary>
    /// 卖出条件集合
    /// </summary>
    [JsonProperty( "sellConditions" )]
    IEnumerable<IStockCondition> SellConditions { get; set; }

    /// <summary>
    /// 所属板块，空则所有
    /// </summary>
    [JsonProperty( "boards" )]
    IEnumerable<BoardIs> Boards { get; set; }

    /// <summary>
    /// 归属题材，空则所有
    /// </summary>
    [JsonProperty( "notions" )]
    IEnumerable<NotionIs> Notions { get; set; }

    /// <summary>
    /// 相关股东，空则所有
    /// </summary>
    [JsonProperty( "holders" )]
    IEnumerable<IStockHolder> Holders { get; set; }
}