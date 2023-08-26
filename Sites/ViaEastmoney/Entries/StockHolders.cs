using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ban3.Sites.ViaEastmoney.Entries;

/// <summary>
/// 
/// </summary>
[Serializable, DataContract]
public class StockHolders
{
    /// <summary>
    /// 
    /// </summary>
    [DataMember(Name = "pages")]
    public int Pages { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DataMember(Name = "data")]
    public List<StockHolder> Data { get; set; } = new List<StockHolder>();
}
