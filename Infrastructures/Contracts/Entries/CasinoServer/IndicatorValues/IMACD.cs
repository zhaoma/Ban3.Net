//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 指数平滑异同移动平均线,Moving Average Convergence Divergence
/// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
/// DEA:EMA(DIF,MID);
/// Histogram(MACD):(DIF-DEA)*2,COLORSTICK;
/// </summary>
public interface IMACD : IIndicatorValue
{
    /// <summary>
    /// 收市价SHORT日异同移动平均线与LONG日异同移动平均线
    /// </summary>
    decimal DIF { get; set; }

    /// <summary>
    /// DIF的M日的平均的异同移动平均线
    /// </summary>
    decimal DEA { get; set; }

    /// <summary>
    /// 用DIF减DEA
    /// </summary>
    decimal Histogram { get; set; }
}
