// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Netease/GetFinance.cs
// ——————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaNetease.Request;

public class DownloadFinances
    : TargetResource
{
    public DownloadFinances(string code)
    {
        Code = code;
        Charset = "gb2312";
        Url= $"http://quotes.money.163.com/service/zycwzb_{code}.html";
    }
    
    public string Code { get; set; }
}

