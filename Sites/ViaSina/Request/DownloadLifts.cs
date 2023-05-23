//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:12
//  function:	DownloadLifts.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaSina.Request;

public class DownloadLifts
    : TargetResource
{
    public DownloadLifts(string code)
    {
        Code = code;
        Url = $"http://vip.stock.finance.sina.com.cn/q/go.php/vInvestConsult/kind/xsjj/index.phtml?symbol={Code}";
        Charset = "gb2312";
    }

    /// <summary>
    /// 
    /// </summary>
    public string Code { get; set; }
}

