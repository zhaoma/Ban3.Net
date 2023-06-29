using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 成交量均线
/// </summary>
public class AMOUNT
    : Record
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("refAmounts", NullValueHandling = NullValueHandling.Ignore)]
    public List<LineWithValue> RefAmounts { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public AMOUNT()
    {
        RefAmounts = new List<LineWithValue>();
    }

    public List<string> Features()
    {
        var result = new List<string>();

        if (RefAmounts.Any() &&
            RefAmounts.OrderBy(o => o.Days)
                .Select(o => o.Ref)
                .ToList()
                .IsAsc(o=>o))
        {
            result.Add("AMOUNT.UP");
        }

        return result;
    }
}