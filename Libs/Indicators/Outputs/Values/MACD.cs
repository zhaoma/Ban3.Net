using System;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 异同移动平均线
    /// </summary>
    [Serializable, DataContract]
    public class MACD
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal RefEMAShort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal RefEMALong { get; set; }

        /// <summary>
        /// 快线
        /// </summary>
        [DataMember]
        public decimal RefDIF { get; set; }

        /// <summary>
        /// 加权移动均线
        /// </summary>
        [DataMember]
        public decimal RefDEA { get; set; }

        /// <summary>
        /// MACD柱
        /// </summary>
        [DataMember]
        public decimal RefMACD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MACD() {}
    }
}