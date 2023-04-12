using System;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 乖离率
    /// </summary>
    [Serializable, DataContract]
    public class BIAS
            : Record
    {
        /// <summary>
        /// 乖离
        /// </summary>
        [DataMember]
        public decimal? RefBIAS { get; set; }

        /// <summary>
        /// 平均乖离
        /// </summary>
        [DataMember]
        public decimal? RefBIASMA { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BIAS() {}
    }
}