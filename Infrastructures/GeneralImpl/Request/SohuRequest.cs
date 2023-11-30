//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Request;

public class SohuRequest
{
    /// 
    public static InternetResource ResourceForNotions( int sohuId )
    {
        return new InternetResource
        {
            Url = $"http://hq.stock.sohu.com/pl/pl-{sohuId}.html",
            Charset = "gb2312"
        };
    }

    public static InternetResource ResourceForNotionStocks( int notionId )
    {
        return new InternetResource
        {
            Url = $"http://q.stock.sohu.com/cn/bk_{notionId}.shtml",
            Charset = "gb2312"
        };
    }
}