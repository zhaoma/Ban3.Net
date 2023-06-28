// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Netease/GetRealTime.cs
// ——————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Sites.ViaNetease.Request;

public class ReadRealTime
    : TargetResource
{
    public ReadRealTime(List<(string, string)> prefixesAndCodes)
    {
        PrefixesAndCodes = prefixesAndCodes;

        ResourceIsJsonp = true;
        JsonpPrefix = "_ntes_quote_callback";

        var ss = prefixesAndCodes.Aggregate("", (current, pc) => current + $"{pc.Item1}{pc.Item2}" + ",");
        Url = $"http://api.money.126.net/data/feed/{ss}money.api";
    }

    /// <summary>
    /// 
    /// </summary>
    public List<(string, string)> PrefixesAndCodes { get; set; }
}
