//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

/// <summary>
/// 公式声明
/// </summary>
public interface IFormulas
{
    /// <summary>
    /// 参数集合
    /// </summary>
    [JsonProperty( "parameters" )]
    IEnumerable<IParameter> Parameters { get; set; }

    /// <summary>
    /// 最高分统计
    /// </summary>
    [JsonProperty( "maxScore" )]
    int MaxScore { get; set; }
}