/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输入价格）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Inputs
{
    /// <summary>
    /// 股票价格扩展
    /// </summary>
    public class Price
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal? CloseBefore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CurrentOpen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CurrentClose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CurrentHigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CurrentLow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TurnoverRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? Volume { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TradableValue { get; set; }

        /// <summary>
        /// 涨幅
        /// </summary>
        [DataMember]
        public decimal Increase { get; set; }

        /// <summary>
        /// 振幅
        /// </summary>
        [DataMember]
        public decimal Amplitude { get; set; }
    }
}