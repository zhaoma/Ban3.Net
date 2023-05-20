// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Netease/GetPrices.cs
// ——————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;
using System;

namespace Ban3.Sites.ViaNetease.Request;

public class DownloadDailyPrices
    : TargetResource
{
    public DownloadDailyPrices(string prefix, string code)
    {
        Prefix = prefix;
        Code = code;

        Url =
             $"http://quotes.money.163.com/service/chddata.html?code={prefix}{code}&end={DateTime.Now.ToString("yyyyMMdd")}&fields=TCLOSE;HIGH;LOW;TOPEN;LCLOSE;CHG;PCHG;TURNOVER;VOTURNOVER;VATURNOVER;TCAP;MCAP";
    }

    public string Prefix { get; set; }
    public string Code { get; set; }

}
