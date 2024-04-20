//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino结果
/// </summary>
public interface IResult
{
    /// <summary>
    /// 标的信息
    /// </summary>
    IStock Stock { get; set; }

    /// <summary>
    /// 笔记集合
    /// </summary>
    List<IRemark> Remarks { get; set; }

    /// <summary>
    /// 当前建议
    /// </summary>
    SuggestIs Suggest { get; set; }

    /// <summary>
    /// 笔记文本
    /// </summary>
    string Note { get; set; }
}
