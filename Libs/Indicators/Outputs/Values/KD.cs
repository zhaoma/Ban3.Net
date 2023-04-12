using System;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 随机震荡指数
    /// </summary>
    [Serializable, DataContract]
    public class KD
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefPSV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefDailyPSV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefLLV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefHHV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public KD() {}
    }
}