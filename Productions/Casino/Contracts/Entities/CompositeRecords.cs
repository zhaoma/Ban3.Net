using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 操作记录
/// </summary>
public class CompositeRecords
{
    /// <summary>
    /// 策略
    /// </summary>
    [JsonProperty("profile", NullValueHandling = NullValueHandling.Ignore)]
    public Profile Profile { get; set; }

    /// <summary>
    /// 记录
    /// </summary>
    [JsonProperty("records", NullValueHandling = NullValueHandling.Ignore)]
    public List<StockOperationRecord> Records { get; set; }

    /// <summary>
    /// 正确记录Keys
    /// </summary>
    [JsonProperty("rightKeys", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,int> RightKeys { get; set; }

    /// <summary>
    /// 错误记录Keys
    /// </summary>
    [JsonProperty("wrongKeys", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,int> WrongKeys { get; set; }
}

