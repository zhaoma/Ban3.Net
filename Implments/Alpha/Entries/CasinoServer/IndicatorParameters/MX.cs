//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 捕捞线
/// </summary>
public class MX : IIndicatorParameter
{
    public IndexIs Index { get; set; } = IndexIs.MX;

    public Dictionary<string, int> Parameters { get; set; }
        = new Dictionary<string, int>
        {
            {"N",2 },
            {"M",4 }
        };


}
