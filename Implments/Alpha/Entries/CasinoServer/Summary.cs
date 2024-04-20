//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using System;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

public  class Summary:ISummary
{
    public DateTime MarkTime { get; set; }

    public List<IResult> Results { get; set; }
}
