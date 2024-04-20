//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorValues;

public class MA:IMA
{
    public IndexIs Index { get; set; } = IndexIs.MA;

    public decimal Short { get; set; }


    public decimal Long { get; set; }
}
