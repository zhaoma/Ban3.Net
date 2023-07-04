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
        public double? CloseBefore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? CurrentOpen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? CurrentClose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? CurrentHigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? CurrentLow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? TurnoverRate { get; set; }

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
        public double? TotalValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? TradableValue { get; set; }

        /// <summary>
        /// 涨幅
        /// </summary>
        [DataMember]
        public double Increase { get; set; }

        /// <summary>
        /// 振幅
        /// </summary>
        [DataMember]
        public double Amplitude { get; set; }
    }
}