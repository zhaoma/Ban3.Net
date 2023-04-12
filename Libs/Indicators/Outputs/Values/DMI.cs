using System;
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
    }
}