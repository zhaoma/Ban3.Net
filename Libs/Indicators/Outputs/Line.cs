/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出线）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 输出线
    /// </summary>
    [Serializable, DataContract]
    public class Line
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Days { get; set; }
    }
}