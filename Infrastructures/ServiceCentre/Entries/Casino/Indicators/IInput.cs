using System;
using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 计算输入条件声明
/// </summary>
public interface IInput
{
    /// <summary>
    /// 标的
    /// </summary>
    IStock Stock { get; set; }

    /// <summary>
    /// 价格数据集合
    /// </summary>
    IEnumerable<IStockPrice> StockPrices { get; set; }

    /// <summary>
    /// 公式集合
    /// </summary>
    IFormulas Formulas { get; set; }
}

