using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 异同移动平均线
    /// </summary>
    public class MACD
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal RefEMAShort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal RefEMALong { get; set; }

        /// <summary>
        /// 快线
        /// </summary>
        [JsonProperty("refDIF", NullValueHandling = NullValueHandling.Ignore)]
        public decimal RefDIF { get; set; }

        /// <summary>
        /// 加权移动均线
        /// </summary>
        [JsonProperty("refDEA", NullValueHandling = NullValueHandling.Ignore)]
        public decimal RefDEA { get; set; }

        /// <summary>
        /// MACD柱
        /// </summary>
        [JsonProperty("refMACD", NullValueHandling = NullValueHandling.Ignore)]
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