using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries;

/// <summary>
/// 
/// </summary>
public class QueryDataPackage<T>
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("pages")]
    public int Pages { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("data")]
    public List<T> Data { get; set; } = new List<T>();
}
