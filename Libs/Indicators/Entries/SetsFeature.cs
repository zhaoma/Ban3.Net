using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

/// <summary>
/// 特征定义
/// </summary>
public class SetsFeature
{
    public SetsFeature(string key, string subject,  int value)
    {
        Key = key;
        Subject = subject;
        Value = value;
    }

    /// <summary>
    /// 特征值
    /// </summary>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string Key { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    public string Subject { get; set; }

    /// <summary>
    /// 评分
    /// </summary>
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public int Value { get; set; } 
}
