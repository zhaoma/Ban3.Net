using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 移动平均线
/// </summary>
public class MA
    : Record
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("refPrices", NullValueHandling = NullValueHandling.Ignore)]
    public List<LineWithValue> RefPrices { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public MA()
    {
        RefPrices = new List<LineWithValue>();
    }

    public List<string> Features()
    {
        var result = new List<string>();

        if (RefPrices.Any() &&
            RefPrices.OrderBy(o => o.Days)
                .Select(o => o.Ref)
                .ToList()
                .IsAsc(o=>o))
        {
            result.Add("MA.UP");
        }

        return result;
    }
}