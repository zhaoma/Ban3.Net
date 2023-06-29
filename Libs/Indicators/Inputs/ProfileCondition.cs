using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Inputs;

public class ProfileCondition
{
    public ProfileCondition() { }

    public ProfileCondition(List<string> include,List<string> exclude) {
        Include = include;
        Exclude = exclude;
    }

    /// <summary>
    /// 包含特征
    /// </summary>
    [JsonProperty("include")]
    public List<string> Include { get; set; } = new();

    /// <summary>
    /// 不包含特征
    /// </summary>
    [JsonProperty("exclude")]
    public List<string> Exclude { get; set; } = new();

    public bool Match(StockSets qs)
        => qs.SetKeys != null
           && (!Include.Any() || Include.AllFoundInComplex(qs.SetKeys.ToList()))
           && (!Exclude.Any() || Exclude.NotFoundIn(qs.SetKeys));
}