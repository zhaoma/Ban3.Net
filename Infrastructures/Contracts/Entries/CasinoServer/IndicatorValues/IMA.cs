﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 移动平均线,Moving Average
/// 5日线和20日线
/// </summary>
public interface IMA:IIndicatorValue
{
    decimal Short { get; set; }

    decimal Long { get; set; }
}