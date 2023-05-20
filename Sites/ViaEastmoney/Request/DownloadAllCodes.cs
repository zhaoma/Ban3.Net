/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            请求eastmoney的StockCodes
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaEastmoney.Request;

/// <summary>
/// 请求eastmoney的StockCodes
/// </summary>
public class DownloadAllCodes
    : TargetResource
{
    ///
    public DownloadAllCodes()
    {
        Url = Constant.UrlForGetCodes;
        ResourceIsJsonp = true;
        JsonpPrefix = "eastmoney";
    }
}