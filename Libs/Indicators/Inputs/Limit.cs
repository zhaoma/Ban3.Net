/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（交易限制）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

using Enums = Ban3.Infrastructures.Indicators.Enums;

namespace  Ban3.Infrastructures.Indicators.Inputs
{
    /// <summary>
    /// 交易限制
    /// </summary>
    public class Limit
    {
        /// <summary>
        /// 总额度
        /// </summary>
        public decimal MaxTotal { get; set; }

        /// <summary>
        /// 标的数量
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// 单个约束
        /// </summary>
        public Stake? RowStake { get; set; }

        /// <summary>
        /// 标的范围（市场）
        /// </summary>
        public List<Enums.StockGroup>? Groups { get; set; }

        /// <summary>
        /// 标的范围（题材）
        /// </summary>
        public List<int>? NotionIds { get; set; }

        /// <summary>
        /// 标的范围（票）
        /// </summary>
        public List<string>? Codes { get; set; }
    }
}