using System;
using System.Collections.Generic;
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

        public List<string> Features(BIAS? pre)
        {
            var result = new List<string>();

            result.Add(RefBIAS > RefBIASMA ? "BIAS.GE" : "BIAS.LT");

            if (pre != null)
            {
                if (pre.RefBIAS < pre.RefBIASMA && RefBIAS > RefBIASMA)
                    result.Add("BIAS.GC");

                if (pre.RefBIAS > pre.RefBIASMA && RefBIAS < RefBIASMA)
                    result.Add("BIAS.DC");
            }

            return result;
        }
    }
}