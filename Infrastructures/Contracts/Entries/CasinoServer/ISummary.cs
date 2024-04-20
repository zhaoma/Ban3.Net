//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 汇总数据
/// </summary>
public interface ISummary
{
    /// <summary>
    /// 标注时间
    /// </summary>
    DateTime MarkTime { get; set; }

    /// <summary>
    /// 结果集合
    /// </summary>
    List<IResult> Results { get; set; }
}
