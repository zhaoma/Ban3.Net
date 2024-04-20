//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 均线参数
/// </summary>
public class MA : IIndicatorParameter
{
    public IndexIs Index { get; set; } = IndexIs.MA;

    public Dictionary<string, int> Parameters { get; set; }
        = new Dictionary<string, int>
        {
            {"SHORT",5 },
            {"LONG",20 }
        };


}
