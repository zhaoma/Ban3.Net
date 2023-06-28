using System;
using System.Runtime.Serialization;

namespace Ban3.Sites.ViaNetease.Entries;

/// <summary>
/// 1分钟价
/// </summary>
[Serializable, DataContract]
public class StockM1
{
    /// <summary>
    /// 时间HHmm
    /// </summary>
    [DataMember]
    public string Time { get; set; } = string.Empty;

    /// <summary>
    /// 买盘
    /// </summary>
    [DataMember]
    public decimal Bid { get; set; }

    /// <summary>
    /// 卖盘
    /// </summary>
    [DataMember]
    public decimal Ask { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    [DataMember]
    public int Volume { get; set; }
}