/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            请求eastmoney的StockCodes
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Sites.ViaEastmoney.Request
{
    /// <summary>
    /// 请求eastmoney的StockCodes
    /// </summary>
    public class DownloadAllCodes
            : NormalRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Servers.NetResource NetResource()
        {
            return new Servers.NetResource
            {
                Url = Servers.Eastmoney.UrlForGetCodes,
                ResourceIsJsonp = ResourceIsJsonp,
                JsonpPrefix = JsonpPrefix
            };
        }

        /// inherit,override for new value
        public override bool ResourceIsJsonp { get; set; } = true;

        /// inherit,override for new value
        public override string JsonpPrefix { get; set; } = "eastmoney";
    }
}