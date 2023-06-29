using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 趋向指标
    /// </summary>
    public class DMI
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal? RefHD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal? RefLD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refPDI", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RefPDI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refMDI", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RefMDI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refADX", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RefADX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refADXR", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RefADXR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal RefMTR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal RefDMP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal RefDMM { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DMI() {}

        public List<string> Features(DMI? pre)
        {
            var result = new List<string>();

            result.Add(RefPDI > RefMDI ? "DMI.PDI" : "DMI.MDI");
            if(RefADX>=80)
                result.Add("DMI.80");

            if (pre != null)
            {
                if (pre.RefPDI < pre.RefMDI && RefPDI > RefMDI)
                    result.Add("DMI.GC");

                if (pre.RefPDI > pre.RefMDI && RefPDI < RefMDI)
                    result.Add("DMI.DC");
            }

            return result;
        }
    }
}