using System.Collections.Generic;
using Newtonsoft.Json;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// ����
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
    /// ���η�
    /// </summary>
    [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
    public string Modifier { get; set; } = string.Empty;

    /// <summary>
    /// ���캯��
    /// </summary>
    [JsonProperty("constructors",NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedMethod>? Constructors{ get; set; }

    /// <summary>
    /// ����
    /// </summary>
    [JsonProperty("methods", NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedMethod>? Methods { get; set; }
}