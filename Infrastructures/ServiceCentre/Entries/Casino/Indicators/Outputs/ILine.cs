﻿using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 指标线
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ILine<T>
{
    /// <summary>
    /// 周期
    /// </summary>
    [JsonProperty("duration")]
    int Duration { get; set; }

    /// <summary>
    /// 取值
    /// </summary>
    [JsonProperty("value")]
    T Value { get; set; }
}
