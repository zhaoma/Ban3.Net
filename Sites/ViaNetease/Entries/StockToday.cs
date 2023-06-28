using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaNetease.Entries;

/// <summary>
/// M1行情
/// </summary>
[Serializable, DataContract]
public class StockToday
{
    /// <summary>
    /// 记录数(242)
    /// </summary>
    [DataMember]
    public int Count { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [DataMember]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 编码
    /// </summary>
    [DataMember]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 数据
    /// </summary>
    [DataMember]
    public List<List<object>> Data { get; set; } = new();

    /// <summary>
    /// 
    /// </summary>
    public List<StockM1> M1S
    {
        get
        {
            return Data.Select(t => new StockM1
            {
                Time = t[0] + "",
                Bid = t[1].ToDecimal(),
                Ask = t[2].ToDecimal(),
                Volume = t[3].ToInt()
            }).ToList();
        }
    }
}