using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.SignalRClient;

/// <summary>
/// 
/// </summary>
public class Notify
{
    /// <summary>
    /// 来源
    /// </summary>
    [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
    public string From { get; set; } = string.Empty;

    /// <summary>
    /// 目的地
    /// </summary>
    [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
    public string To { get; set; } = string.Empty;

    /// <summary>
    /// 关键字
    /// </summary>
    [JsonProperty("controlCode", NullValueHandling = NullValueHandling.Ignore)]
    public string ControlCode { get; set; } = string.Empty;

    /// <summary>
    /// 消息
    /// </summary>
    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string Content { get; set; } = string.Empty;

}
