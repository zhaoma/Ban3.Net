using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 轨道线
/// </summary>
[Serializable, DataContract]
public class ENE
    : Record
{
    /// <summary>
    /// 上轨
    /// </summary>
    [JsonProperty("refUPPER", NullValueHandling = NullValueHandling.Ignore)]
    public double? RefUPPER { get; set; }

    /// <summary>
    /// 下轨
    /// </summary>
    [JsonProperty("refLOWER", NullValueHandling = NullValueHandling.Ignore)]
    public double? RefLOWER { get; set; }

    /// <summary>
    /// 中轨
    /// </summary>
    [JsonProperty("refENE", NullValueHandling = NullValueHandling.Ignore)]
    public double? RefENE { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ENE()
    {
    }

    public List<string> Features(double close)
    {
        var result = new List<string>();

        if (close >= RefUPPER) result.Add("ENE.UPPER");
        if (close <= RefLOWER) result.Add("ENE.LOWER");

        return result;
    }
}