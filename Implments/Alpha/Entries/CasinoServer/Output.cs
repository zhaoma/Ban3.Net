//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

public class Output : IOutput
{
    public Output()
    {

    }

    public IMA MA { get; set; }

    public IMACD MACD { get; set; }

    public IMX MX { get; set; }

    public List<string> Keys { get; set; }
}
