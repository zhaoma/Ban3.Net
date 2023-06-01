using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 成交量均线
    /// </summary>
    [Serializable, DataContract]
    public class AMOUNT
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<LineWithValue> RefAmounts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AMOUNT() {}
    }
}