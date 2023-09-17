using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries;

/// <summary>
/// 
/// </summary>
[Serializable, DataContract]
public class QueryDataPackage<T>
{
    /// <summary>
    /// 
    /// </summary>
    [DataMember(Name = "pages")]
    [JsonProperty("pages")]
    public int Pages { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DataMember(Name = "data")]
    [JsonProperty("data")]
    public List<T> Data { get; set; } = new List<T>();
}
