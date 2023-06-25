/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 标的
    /// </summary>
    public class StockInfo
    {
        public StockInfo() {}

        /// <summary>
        /// 代码
        /// </summary>
        public string StockCode { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        public string StockName { get; set; } = string.Empty;

        /// <summary>
        /// 图标
        /// </summary>
        public string StockIcon { get; set; } = string.Empty;

        /// <summary>
        /// 板块
        /// </summary>
        public int StockGroup { get; set; }

        /// <summary>
        /// 当前价
        /// </summary>
        public decimal CurrentClose { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 总股本
        /// </summary>
        public long GeneralCapital { get; set; }

        /// <summary>
        /// 流通股本
        /// </summary>
        public long NegotiableCapital { get; set; }

        /// <summary>
        /// 净资产
        /// </summary>
        public decimal Equity { get; set; }

        /// <summary>
        /// 市净率
        /// </summary>
        public decimal EquityRatio { get; set; }

        /// <summary>
        /// 市盈率
        /// </summary>
        public decimal EarningsRatio { get; set; }

        /// <summary>
        /// 负债率
        /// </summary>
        public decimal DebtsRatio { get; set; }
    }
}