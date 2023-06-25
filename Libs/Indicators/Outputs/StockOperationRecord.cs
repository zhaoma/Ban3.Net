/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（指标计算结果）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 指标计算结果
    /// </summary>
    [Serializable, DataContract]
    public class StockOperationRecord
    {
        /// <summary>
        /// 股票主键
        /// </summary>
        [DataMember]
        public int StockId { get; set; }

        /// <summary>
        /// 股票编码
        /// </summary>
        [DataMember]
        public string StockCode { get; set; } = string.Empty;

        /// <summary>
        /// 买入时间
        /// </summary>
        [DataMember]
        public DateTime BuyDate { get; set; }

        /// <summary>
        /// 入选时价格
        /// B选择最高价
        /// </summary>
        [DataMember]
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 卖出时间
        /// </summary>
        [DataMember]
        public DateTime SellDate { get; set; }

        /// <summary>
        /// 入选时价格
        /// S选择最低价
        /// </summary>
        [DataMember]
        public decimal SellPrice { get; set; }

        /// <summary>
        /// 交易量
        /// </summary>
        [DataMember]
        public int Volume { get; set; }

        /// <summary>
        /// 涨幅/跌幅
        /// </summary>
        [DataMember]
        public decimal Ratio { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        [DataMember]
        public long Rank { get; set; }
    }
}