//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino结果
/// </summary>
public class Result
{
    /// <summary>
    /// 标的信息
    /// </summary>
    public Stock Stock { get; set; }

    /// <summary>
    /// 笔记集合
    /// </summary>
    public List<Remark>? Remarks { get; set; }

    /// <summary>
    /// 当前建议
    /// </summary>
    public SuggestIs Suggest { get; set; }

    /// <summary>
    /// 笔记文本
    /// </summary>
    public List<Notice>? Notices { get; set; }
}
