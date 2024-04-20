//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// Casino标的备注(每日行情与指标值)
/// </summary>
public class Remark : IRemark
{
    /// <summary>
    /// 当日价格信息
    /// </summary>
    public IPrice DayPrice { get; set; }

    /// <summary>
    /// 各周期指标值
    /// </summary>
    public Dictionary<CycleIs, IOutput> Outputs { get; set; }

    /// <summary>
    /// 买卖建议
    /// </summary>
    public SuggestIs Suggest { get; set; }

}
