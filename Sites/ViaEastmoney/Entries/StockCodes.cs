/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            来自eastmoney的StockCode数据体
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Ban3.Sites.ViaEastmoney.Entries;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries
{
    /// <summary>
    /// 来自eastmoney的StockCode结构体
    /// </summary>
    public class StockCodes
    {
        /// <summary>
        /// 条目数量
        /// </summary>
        [JsonProperty( "total" )]
        public int Total { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        [JsonProperty( "diff" )]
        public List<StockCode> Diff { get; set; }
    }
}