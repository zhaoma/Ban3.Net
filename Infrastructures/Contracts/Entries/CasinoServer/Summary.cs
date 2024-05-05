//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 汇总数据
/// </summary>
public class Summary
{
    /// <summary>
    /// 标注时间
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 结果集合
    /// </summary>
    public List<TradeRecord> Records { get; set; }
}
