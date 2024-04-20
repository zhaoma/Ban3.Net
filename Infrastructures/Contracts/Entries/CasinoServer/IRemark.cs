//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino笔记
/// </summary>
public interface IRemark
{
    /// <summary>
    /// 参考价格
    /// </summary>
    IPrice DayPrice { get; set; }

    /// <summary>
    /// 周期与价格，指标值,关键特征
    /// </summary>
    Dictionary<CycleIs, IOutput> Outputs { get; set; }

    /// <summary>
    /// 买卖建议
    /// </summary>
    SuggestIs Suggest { get; set; }
}
