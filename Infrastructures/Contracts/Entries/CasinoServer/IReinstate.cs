//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 复权因子
/// </summary>
public interface IReinstate
{
    /// <summary>
    /// 除权日期
    /// </summary>
    DateTime MarkTime { get; set; }

    /// <summary>
    /// 除权因子
    /// </summary>
    decimal Factor { get; set;}
}
