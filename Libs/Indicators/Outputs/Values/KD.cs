using System;
using System.Collections.Generic;
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

        public List<string> Features(KD? pre)
        {
            var result = new List<string>();

            result.Add(RefK > RefD ? "KD.PDI" : "KD.MDI");
            if (RefK >= 80)
                result.Add("KD.80");
            if(RefK<10)
                result.Add("KD.10");

            if (pre != null)
            {
                if (pre.RefK < pre.RefD && RefK > RefD)
                    result.Add("KD.GC");

                if (pre.RefK > pre.RefD && RefK < RefD)
                    result.Add("KD.DC");
            }

            return result;
        }
    }
}