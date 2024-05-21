//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 复权因子
/// </summary>
public class Reinstate : IZero
{
    /// <summary>
    /// 除权日期
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 除权因子
    /// </summary>
    public decimal Factor { get; set; }
}
