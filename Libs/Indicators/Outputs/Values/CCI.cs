using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators.Outputs.Values;

/// <summary>
/// 顺势指标
/// </summary>
[Serializable, DataContract]
public class CCI
    : Record
{
    /// <summary>
    /// 
    /// </summary>
    [DataMember]
    public decimal? RefCCI { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DataMember]
    public decimal RefTYP { get; set; }

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