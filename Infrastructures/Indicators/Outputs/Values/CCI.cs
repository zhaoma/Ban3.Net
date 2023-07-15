using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 顺势指标
/// </summary>
public class CCI
    : Record
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("refCCI", NullValueHandling = NullValueHandling.Ignore)]
    public double? RefCCI { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("refTYP", NullValueHandling = NullValueHandling.Ignore)]
    public double RefTYP { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public CCI()
    {
    }

    public List<string> Features()
    {
        var result = new List<string>();

        if (RefCCI >= 200)
            result.Add("CCI.200");
        else
        {
            if (RefCCI >= 100)
                result.Add("CCI.100");
            else
            {
                if (RefCCI <= -200)
                    result.Add("CCI.-200");
            }
        }

        return result;
    }
}