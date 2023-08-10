using Newtonsoft.Json;
using System.Collections.Generic;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

public class AnalyzedMethod
{
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
    /// ����
    /// </summary>
    [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedArgument>? Arguments { get; set; }

    /// <summary>
    /// ����ֵ����
    /// </summary>
    [JsonProperty("returnType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ReturnType { get; set; }
}