using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 移动平均线
    /// </summary>
    [Serializable, DataContract]
    public class MA
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<LineWithValue> RefPrices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MA() {}
    }
}