/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（指标值）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Indicators.Entries
{
    /// <summary>
    /// 指标值
    /// </summary>
    [Serializable, DataContract]
    public class RecordWithValue
            : Record
    {
        /// <summary>
        /// 指标参数
        /// </summary>
        [DataMember(Name = "paramId")]
        public virtual int ParamId { get; set; }

        /// <summary>
        /// 计算获值
        /// </summary>
        [DataMember(Name = "ref")]
        public virtual decimal Ref { get; set; }
    }
}