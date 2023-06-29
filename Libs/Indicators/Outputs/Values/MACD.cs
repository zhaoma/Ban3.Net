using System;
using System.Collections.Generic;
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

        public List<string> Features(MACD? pre)
        {
            var result = new List<string>();

            result.Add(RefDIF > RefDEA ? "MACD.PDI" : "MACD.MDI");
            result.Add(RefDIF >= 0 ? "MACD.P" : "MACD.N");
            //result.Add(RefMACD >= 0 ? "MACD.R" : "MACD.G");

            if (pre != null)
            {
                if(pre.RefDIF<pre.RefDEA&&RefDIF>RefDEA)
                    result.Add("MACD.GC");

                if (pre.RefDIF > pre.RefDEA && RefDIF < RefDEA)
                    result.Add("MACD.DC");

                if(pre.RefDIF<0&&RefDIF>0)
                    result.Add("MACD.C0");
                
                if (pre.RefDIF > 0 && RefDIF < 0)
                    result.Add("MACD.D0");
            }

            return result;
        }
    }
}