using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values
{
    /// <summary>
    /// 趋向指标
    /// </summary>
    [Serializable, DataContract]
    public class DMI
            : Record
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefHD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefLD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefPDI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefMDI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefADX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? RefADXR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal RefMTR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal RefDMP { get; set; }

        /// <summary>
        /// 
        /// </summary>
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