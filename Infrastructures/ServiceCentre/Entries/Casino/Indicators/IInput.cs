﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 计算输入条件声明
/// </summary>
public interface IInput
{
    /// <summary>
    /// 价格数据集合
    /// </summary>
    [JsonProperty("stockPrices")]
    IStockData<IStockPrice> StockPrices { get; set; }

    /// <summary>
    /// 公式集合
    /// </summary>
    [JsonProperty("formulas")]
    IFormulas Formulas { get; set; }
}

