using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

/// <summary>
/// 标的特征声明
/// </summary>
public interface IStockFeature : IStock
{
    /// <summary>
    /// 评分
    /// </summary>
    [JsonProperty("score")]
    int Score { get; set; }

    /// <summary>
    /// 特质集合
    /// </summary>
    [JsonProperty("keys")]
    IEnumerable<string> Keys { get; set; }
}

