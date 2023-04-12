using System;
using System.Runtime.Serialization;

namespace Ban3.Sites.ViaEastmoney.Entries
{
    /// <summary>
    /// 股东数据
    /// </summary>
    [Serializable, DataContract]
    public class StockHolder
    {
        /// <summary>
        /// 票编码
        /// </summary>
        [DataMember(Name = "COMPANYCODE")]
        public string CompanyCode { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        [DataMember(Name = "SHAREHDNAME")]
        public string ShareHDName { get; set; }

        /// <summary>
        /// 股东类型
        /// </summary>
        [DataMember(Name = "SHAREHDTYPE")]
        public string ShareHDType { get; set; }

        /// <summary>
        /// 持股类型
        /// </summary>
        [DataMember(Name = "SHARESTYPE")]
        public string SharesType { get; set; }

        /// <summary>
        /// 持股排名
        /// </summary>
        [DataMember(Name = "RANK")]
        public decimal Rank { get; set; }

        /// <summary>
        /// 股票编码
        /// </summary>
        [DataMember(Name = "SCODE")]
        public string Scode { get; set; }

        /// <summary>
        /// 股票名称
        /// </summary>
        [DataMember(Name = "SNAME")]
        public string Sname { get; set; }

        /// <summary>
        /// 报告日期
        /// </summary>
        [DataMember(Name = "RDATE")]
        public DateTime Rdate { get; set; }

        /// <summary>
        /// 持股数量
        /// </summary>
        [DataMember(Name = "SHAREHDNUM")]
        public double ShareHDNum { get; set; }

        /// <summary>
        /// 持股市值
        /// </summary>
        [DataMember(Name = "LTAG")]
        public double Ltag { get; set; }

        /// <summary>
        /// 占比
        /// </summary>
        [DataMember(Name = "ZB")]
        public string Zb { get; set; }

        /// <summary>
        /// 公告日期
        /// </summary>
        [DataMember(Name = "NDATE")]
        public DateTime Ndata { get; set; }

        /// <summary>
        /// 变动状态
        /// </summary>
        [DataMember(Name = "BZ")]
        public string Bz { get; set; }

        /// <summary>
        /// 变动比例
        /// </summary>
        [DataMember(Name = "BDBL")]
        public string BdBl { get; set; }

        /// <summary>
        /// 股东编号
        /// </summary>
        [DataMember(Name = "SHAREHDCODE")]
        public string ShareHDCode { get; set; }

        /// <summary>
        /// 总股本占比
        /// </summary>
        [DataMember(Name = "SHAREHDRATIO")]
        public string ShareHDRatio { get; set; }

        /// <summary>
        /// 变动总额
        /// </summary>
        [DataMember(Name = "BDSUM")]
        public string BdSum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Ratio")]
        public decimal Ratio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "StockId")]
        public int StockId { get; set; }
    }
}
