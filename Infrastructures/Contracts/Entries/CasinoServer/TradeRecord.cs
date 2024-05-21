//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 
/// </summary>
public class TradeRecord : IZero
{
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 最新价格
    /// </summary>
    public decimal LatestClose { get; set; }

    /// <summary>
    /// 推测买卖记录集合
    /// </summary>
    public List<TradeDetail>? Details { get; set; }
}
