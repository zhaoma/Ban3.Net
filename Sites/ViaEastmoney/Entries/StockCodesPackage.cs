/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            来自eastmoney的StockCode数据包
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries
{
    /// <summary>
    /// 来自eastmoney的StockCode数据包
    /// </summary>
    public class StockCodesPackage
    {
        /// <summary>
        /// StockCodes外一层
        /// </summary>
        [JsonProperty( "data" )]
        public StockCodes Data { get; set; }
    }
}