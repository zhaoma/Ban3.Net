//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
//  WTFPL . DRY . KISS . YAGNI
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 输出值声明
/// </summary>
public interface IStockValue
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

