//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Request;

/// 
public class EastmoneyRequest
{
    /// 
    public static InternetResource ResourceForHoldersAll( int page = 1, int ps = 500 ) => new()
    {
        IsJsonp = true,
        JsonpPrefix = "eastmoney",
        Method = HttpMethod.Post,
        Url = $"https://datacenter-web.eastmoney.com/api/data/v1/get?callback=eastmoney&sortColumns=RANK&sortTypes=1&pageSize={ps}&pageNumber={page}&reportName=RPT_DMSK_HOLDERS&columns=ALL&source=WEB&client=WEB"
    };

    /// 
    public static InternetResource ResourceForHoldersOne( string code, int page = 1, int ps = 500 ) => new()
    {
        IsJsonp = true,
        JsonpPrefix = "eastmoney",
        Method = HttpMethod.Post,
        Url = $"https://datacenter-web.eastmoney.com/api/data/v1/get?callback=eastmoney&sortColumns=RANK&sortTypes=1&pageSize={ps}&pageNumber={page}&reportName=RPT_DMSK_HOLDERS&columns=ALL&source=WEB&client=WEB&filter=(SECURITY_CODE%3D%22{code}%22)"
    };
}