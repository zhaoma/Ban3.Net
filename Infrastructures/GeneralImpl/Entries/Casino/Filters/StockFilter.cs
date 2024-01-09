//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Filters;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Filters;

/// <summary>
/// 筛选策略
/// </summary>
public class StockFilter : IStockFilter
{
    /// 
    public string Id { get; set; }

    /// 
    public string Subject { get; set; }

    /// 
    public IEnumerable<IStockCondition> BuyConditions { get; set; }

    /// 
    public IEnumerable<IStockCondition> SellConditions { get; set; }

    /// 
    public IEnumerable<BoardIs> Boards { get; set; }

    /// 
    public IEnumerable<NotionIs> Notions { get; set; }

    /// 
    public IEnumerable<IStockHolder> Holders { get; set; }
}