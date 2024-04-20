//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorValues;

public class MX : IMX
{
    public IndexIs Index { get; set; } = IndexIs.MX;



    public decimal Buy { get; set; }


    public decimal Sell { get; set; }
}
