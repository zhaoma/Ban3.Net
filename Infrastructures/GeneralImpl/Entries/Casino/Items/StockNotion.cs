// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 标的题材数据声明
/// </summary>
public class StockNotion : IStockNotion
{
    /// <summary>
    /// 标识
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 题材主题
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 题材分组（地域/行业/热门）
    /// </summary>
    public NotionIs NotionIs { get; set; }

    /// <summary>
    /// 相关标的
    /// </summary>
    public IEnumerable<IStock> Stocks { get; set; }
}