using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 随机震荡指数
    /// </summary>
    public class KD
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refK", NullValueHandling = NullValueHandling.Ignore)]
        public double? RefK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refD", NullValueHandling = NullValueHandling.Ignore)]
        public double? RefD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public double? RefPSV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public double? RefDailyPSV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public double? RefLLV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public double? RefHHV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public KD() {}

        public List<string> Features(KD? pre)
        {
            var result = new List<string> { RefK > RefD ? "KD.PDI" : "KD.MDI" };

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