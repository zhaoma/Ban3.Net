using System.Collections.Generic;
using Newtonsoft.Json;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// 对象
/// </summary>
public class AnalyzedClass
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("fullName", NullValueHandling = NullValueHandling.Ignore)]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 修饰符
    /// </summary>
    [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
    public string Modifier { get; set; } = string.Empty;

    /// <summary>
    /// 构造函数
    /// </summary>
    [JsonProperty("constructors",NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedMethod>? Constructors{ get; set; }

    /// <summary>
    /// 方法
    /// </summary>
    [JsonProperty("methods", NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedMethod>? Methods { get; set; }
}