// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Charts.Entries;

/// <summary>
/// Candlestick data define
/// </summary>
public class CandlestickRecord
{
    public DateTime TradeDate { get; set; }
    
    public float Open { get; set; }

    public float Close { get; set; }

    public float Low { get; set; }

    public float High { get; set; }
}