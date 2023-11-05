using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 公式声明
/// </summary>
public interface IFormulas
{
    /// <summary>
    /// 参数集合
    /// </summary>
    [JsonProperty("parameters")]
    IEnumerable<IParameter> Parameters { get; set; }

    /// <summary>
    /// 最高分统计
    /// </summary>
    [JsonProperty("maxScore")]
    int MaxScore { get; set; }
}
