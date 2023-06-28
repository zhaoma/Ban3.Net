using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 移动平均线
/// </summary>
[Serializable, DataContract]
public class MA
    : Record
{
    /// <summary>
    /// 
    /// </summary>
    [DataMember]
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