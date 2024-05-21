//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino推测买卖记录
/// </summary>
public class TradeDetail : IZero
{
    /// <summary>
    /// 购买时间
    /// </summary>
    public DateTime BuyTime { get; set; }

    /// <summary>
    /// 购买价格
    /// </summary>
    public decimal BuyPrice { get; set; }

    /// <summary>
    /// 售出时间
    /// </summary>
    public DateTime SellTime { get; set; }

    /// <summary>
    /// 售出价格
    /// </summary>
    public decimal SellPrice { get; set; }
}
