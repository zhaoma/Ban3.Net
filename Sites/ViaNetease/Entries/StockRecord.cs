using System;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Netease
{
    /// <summary>
    /// 即时信息
    /// </summary>
    [Serializable, DataContract]
    public class StockRecord
    {
        /// <summary>
        /// 类型(SZ/SH)
        /// </summary>
        [DataMember( Name = "type" )]
        public string Type { get; set; }

        /// <summary>
        /// 编码
        /// 1/0+代码 1=深圳 0=上海
        /// </summary>
        [DataMember( Name = "code" )]
        public string Code { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [DataMember( Name = "symbol" )]
        public string Symbol { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember( Name = "name" )]
        public string Name { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [DataMember( Name = "arrow" )]
        public string Arrow { get; set; }

        /// <summary>
        /// 涨幅=*100
        /// </summary>
        [DataMember( Name = "percent" )]
        public decimal Percent { get; set; }

        /// <summary>
        /// 最高价
        /// </summary>
        [DataMember( Name = "high" )]
        public decimal High { get; set; }

        /// <summary>
        /// 最低价
        /// </summary>
        [DataMember( Name = "low" )]
        public decimal Low { get; set; }

        /// <summary>
        /// 开盘价
        /// </summary>
        [DataMember( Name = "open" )]
        public decimal Open { get; set; }

        /// <summary>
        /// 现价
        /// </summary>
        [DataMember( Name = "price" )]
        public decimal Price { get; set; }

        /// <summary>
        /// 前收
        /// </summary>
        [DataMember( Name = "yestclose" )]
        public decimal YestClose { get; set; }

        /// <summary>
        /// 涨幅(金额)
        /// </summary>
        [DataMember( Name = "updown" )]
        public decimal UpDown { get; set; }

        /// <summary>
        /// 卖5量
        /// </summary>
        [DataMember( Name = "askvol5" )]
        public int Askvol5 { get; set; }

        /// <summary>
        /// 卖4量
        /// </summary>
        [DataMember( Name = "askvol4" )]
        public int Askvol4 { get; set; }

        /// <summary>
        /// 卖3量
        /// </summary>
        [DataMember( Name = "askvol3" )]
        public int Askvol3 { get; set; }

        /// <summary>
        /// 卖2量
        /// </summary>
        [DataMember( Name = "askvol2" )]
        public int Askvol2 { get; set; }

        /// <summary>
        /// 卖一量
        /// </summary>
        [DataMember( Name = "askvol1" )]
        public int Askvol1 { get; set; }

        /// <summary>
        /// 卖5
        /// </summary>
        [DataMember( Name = "ask5" )]
        public decimal Ask5 { get; set; }

        /// <summary>
        /// 卖4
        /// </summary>
        [DataMember( Name = "ask4" )]
        public decimal Ask4 { get; set; }

        /// <summary>
        /// 卖3
        /// </summary>
        [DataMember( Name = "ask3" )]
        public decimal Ask3 { get; set; }

        /// <summary>
        /// 卖2
        /// </summary>
        [DataMember( Name = "ask2" )]
        public decimal Ask2 { get; set; }

        /// <summary>
        /// 卖1
        /// </summary>
        [DataMember( Name = "ask1" )]
        public decimal Ask1 { get; set; }

        /// <summary>
        /// 买1
        /// </summary>
        [DataMember( Name = "bid1" )]
        public decimal Bid1 { get; set; }

        /// <summary>
        /// 买2
        /// </summary>
        [DataMember( Name = "bid2" )]
        public decimal Bid2 { get; set; }

        /// <summary>
        /// 买3
        /// </summary>
        [DataMember( Name = "bid3" )]
        public decimal Bid3 { get; set; }

        /// <summary>
        /// 买4
        /// </summary>
        [DataMember( Name = "bid4" )]
        public decimal Bid4 { get; set; }

        /// <summary>
        /// 买5
        /// </summary>
        [DataMember( Name = "bid5" )]
        public decimal Bid5 { get; set; }

        /// <summary>
        /// 买1量
        /// </summary>
        [DataMember( Name = "bidvol1" )]
        public int Bidvol1 { get; set; }

        /// <summary>
        /// 买2量
        /// </summary>
        [DataMember( Name = "bidvol2" )]
        public int Bidvol2 { get; set; }

        /// <summary>
        /// 买3量
        /// </summary>
        [DataMember( Name = "bidvol3" )]
        public int Bidvol3 { get; set; }

        /// <summary>
        /// 买4量
        /// </summary>
        [DataMember( Name = "bidvol4" )]
        public int Bidvol4 { get; set; }

        /// <summary>
        /// 买5量
        /// </summary>
        [DataMember( Name = "bidvol5" )]
        public int Bidvol5 { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        [DataMember( Name = "volume" )]
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        [DataMember( Name = "turnover" )]
        public double TurnOver { get; set; }

        /*
        /// <summary>
        /// 最后更新
        /// </summary>
        [DataMember(Name = "update")]
        public DateTime Update { get; set; }
        */
        /// <summary>
        /// 时间
        /// </summary>
        [DataMember( Name = "time" )]
        public DateTime Time { get; set; }
    }
}