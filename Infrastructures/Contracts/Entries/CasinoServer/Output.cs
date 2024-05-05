//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino指标值,关键特征
/// </summary>
public class Output
{
    /// <summary>
    /// AMOUNT:M5,M10
    /// </summary>
    public AMOUNT AMOUNT { get; set; }

    /// <summary>
    /// MA:M5,M30
    /// </summary>
    public MA MA { get; set; }

    /// <summary>
    /// MACD:DIF,DEA,MACD
    /// </summary>
    public MACD MACD { get; set; }

    /// <summary>
    /// MX:BUY,SELL
    /// </summary>
    public MX MX { get; set; }

    /// <summary>
    /// 关键特征
    /// </summary>
    public List<string> Keys { get; set; }
}
