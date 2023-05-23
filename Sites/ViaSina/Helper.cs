using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp;
using Ban3.Sites.ViaSina.Entries;
using Ban3.Sites.ViaSina.Request;
using Ban3.Sites.ViaSina.Response;

namespace Ban3.Sites.ViaSina;

public static class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Sina ShareBonus List</returns>
    public static DownloadEventsResult GetResult(this DownloadEvents request)
    {
        var bytes = new Infrastructures.NetHttp.Entries.TargetHost
        {
            Anonymous = true
        }.ReadBytes(request).Result;

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var html = Encoding.GetEncoding(request.Charset).GetString(bytes);

        return new DownloadEventsResult { Data = ParseEvents(html) };
    }

    static List<ShareBonus> ParseEvents(string html)
    {
        var result = new List<ShareBonus>();
        var sb1 = html.Substr("<!--分红 begin-->", "<!--分红 end-->");

        if (!string.IsNullOrEmpty(sb1))
        {
            var atrs = sb1.SplitTbody();

            foreach (var atr in atrs)
            {
                if (atr != null && atr.Count() > 4)
                {
                    if (atr[1].ToDecimal() != 0 || atr[2].ToDecimal() != 0 || atr[3].ToDecimal() != 0)
                    {
                        result.Add(new ShareBonus
                        {
                            EventType = 1,
                            EventSubject = "分红",
                            MarkTime = atr[5].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime(),
                            Sbonus = atr[1].ToDecimal(),
                            Zbonus = atr[2].ToDecimal(),
                            Xmoney = atr[3].ToDecimal()
                        });
                    }
                }
            }
        }

        var sb2 = html.Substr("<!--配股 begin-->", "<!--配股 end-->");
        if (!string.IsNullOrEmpty(sb2))
        {
            var btrs = sb2.SplitTbody();

            foreach (var atr in btrs)
            {
                if (atr != null && atr.Count() > 4)
                {
                    if (atr[1].ToDecimal() != 0 || atr[2].ToDecimal() != 0 || atr[3].ToDecimal() != 0)
                    {
                        result.Add(new ShareBonus
                        {
                            EventType = 2,
                            EventSubject = "配股",
                            MarkTime = atr[4].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime(),
                            Pbonus = atr[1].ToDecimal(),
                            Pprice = atr[2].ToDecimal(),
                            Pcapital = atr[3].ToDecimal()
                        });
                    }
                }
            }
        }

        return result;
    }

    public static DownloadLiftsResult GetResult(this DownloadLifts request)
    {
        var bytes = new Infrastructures.NetHttp.Entries.TargetHost
        {
            Anonymous = true
        }.ReadBytes(request).Result;

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var html = Encoding.GetEncoding(request.Charset).GetString(bytes);

        return new DownloadLiftsResult { Data = ParseLifts(html) };
    }

    static List<ShareBonus> ParseLifts(string html)
    {
        var result = new List<ShareBonus>();
        var sl = html.Substr("<div id=\"divContainer\">", "</table>");
        var trs = sl.SplitTbody();
        foreach (var atr in trs)
        {
            if (atr != null && atr.Count() > 3)
                if (atr[3].ToDecimal() != 0)
                {
                    result.Add(new ShareBonus
                    {
                        EventType = 4,
                        EventSubject = "解禁",
                        MarkTime = atr[2].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime(),
                        Lifted = atr[3].ToDecimal() * 10000M
                    });
                }
        }

        return result;
    }
}