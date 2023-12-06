//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Request;

/// 
public class SohuRequest
{
    /// 
    public static InternetResource ResourceForNotions( int sohuId )
    {
        return new InternetResource
        {
            Url = $"https://q.stock.sohu.com/pl/pl-{sohuId}.html",
            Charset = "gb2312"
        };
    }

    /// 
    public static InternetResource ResourceForNotionStocks( int notionId )
    {
        return new InternetResource
        {
            Url = $"https://q.stock.sohu.com/cn/bk_{notionId}.shtml",
            Charset = "gb2312"
        };
    }
}