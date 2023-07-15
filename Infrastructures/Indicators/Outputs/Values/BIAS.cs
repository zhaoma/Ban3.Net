using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 乖离率
/// </summary>
public class BIAS
        : Record
{
    /// <summary>
    /// 乖离
    /// </summary>
    [JsonProperty("refBIAS", NullValueHandling = NullValueHandling.Ignore)]
    public double? RefBIAS { get; set; }

    /// <summary>
    /// 平均乖离
    /// </summary>
    [JsonProperty("refBIASMA", NullValueHandling = NullValueHandling.Ignore)]
    public double? RefBIASMA { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public BIAS()
    {

    }

    public List<string> Features(BIAS? pre)
    {
        var result = new List<string> { RefBIAS > RefBIASMA ? "BIAS.GE" : "BIAS.LT" };

        if (pre != null)
        {
            if (pre.RefBIAS < pre.RefBIASMA && RefBIAS > RefBIASMA)
                result.Add("BIAS.GC");

            if (pre.RefBIAS > pre.RefBIASMA && RefBIAS < RefBIASMA)
                result.Add("BIAS.DC");
        }

        return result;
    }
}