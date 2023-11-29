//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-29
//  ————————————————————————————————————————————————————————————————————————————
using System;
using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;
using static Ban3.Infrastructures.GeneralImpl.Request.TushareRequest;

namespace Ban3.Infrastructures.GeneralImpl.Request;

public class SinaRequest
{
	public SinaRequest()
	{
	}

    public static InternetHost Host()
    => new()
    {
        AuthenticationType = AuthenticationType.None,
        BaseUrl = @"http://money.finance.sina.com.cn"
    };

    public static InternetResource ResourceForEvents(string code)
    {
        return new InternetResource
        {
            Method = HttpMethod.Post,
            Url = $"http://money.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/{code}.phtml",
            Charset="gb2312"
        };
    }
}

