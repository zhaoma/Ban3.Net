/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（带值输出线）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */
using System;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Indicators.Entries
{
    /// <summary>
    /// 带值输出线
    /// </summary>
    [Serializable, DataContract]
    public class LineWithValue : Line
    {
        /// <summary>
        /// 指标值
        /// </summary>
        [DataMember]
        public decimal Ref { get; set; }
    }
}