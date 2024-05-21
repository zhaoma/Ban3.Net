//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 汇总数据
/// </summary>
public class Summary : IZero
{
    /// <summary>
    /// 标注时间
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 结果集合
    /// </summary>
    public List<TradeRecord>? Records { get; set; }
}
