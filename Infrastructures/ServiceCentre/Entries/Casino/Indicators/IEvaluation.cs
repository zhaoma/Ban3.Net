using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

public interface IEvaluation<T>
{
    /// <summary>
    /// 评判指标
    /// </summary>
    /// <param name="score"></param>
    /// <param name="keys"></param>
    /// <returns></returns>
    bool Judge(T previousValue, out int score, out IEnumerable<string> keys);

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

