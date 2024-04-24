//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino指标值,关键特征
/// </summary>
public interface IOutput
{
    /// <summary>
    /// AMOUNT:M5,M10
    /// </summary>
    IAMOUNT AMOUNT { get; set; }

    /// <summary>
    /// MA:M5,M30
    /// </summary>
    IMA MA { get; set; }

    /// <summary>
    /// MACD:DIF,DEA,MACD
    /// </summary>
    IMACD MACD { get; set; }

    /// <summary>
    /// MX:BUY,SELL
    /// </summary>
    IMX MX { get; set; }

    /// <summary>
    /// 关键特征
    /// </summary>
    List<string> Keys { get; set; }
}
