/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            收藏对象
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 收藏对象
/// </summary>
public enum StockFavoriteModules
{
    /// <summary>
    /// 股票
    /// </summary>
    [Description("股票")]
    Stock = 1,

    /// <summary>
    /// 股东
    /// </summary>
    [Description("股东")]
    StockHolder = 2,

    /// <summary>
    /// 概念
    /// </summary>
    [Description("概念")]
    StockNotion = 3
}
