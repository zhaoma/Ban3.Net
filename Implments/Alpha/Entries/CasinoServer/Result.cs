//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// Casino分析结果
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// 标的信息
    /// </summary>
    public IStock Stock { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<IRemark> Remarks { get; set; }

    /// <summary>
    /// 操作建议
    /// </summary>
    public SuggestIs Suggest { get; set; }

    /// <summary>
    /// 备注笔记
    /// </summary>
    public string Note { get; set; }
}
