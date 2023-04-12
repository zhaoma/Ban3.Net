using System;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 顺势指标
    /// </summary>
    [Serializable, DataContract]
    public class CCI
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefCCI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal RefTYP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CCI() {}
    }
}