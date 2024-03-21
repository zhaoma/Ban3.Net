﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 计算输出结果声明
/// </summary>
public interface IOutput : IStockCode
{
    int Score { get; set; }

    IEnumerable<string> Keys { get; set; }

    /// <summary>
    /// 计算结果：公式结果集合->特征集合+得分（分周期）
    /// </summary>
    IDictionary<AnalysisCycle, IEnumerable<IComputedResult>> ComputedResults { get; set; }
}