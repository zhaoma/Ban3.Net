using Newtonsoft.Json;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// 参数
/// </summary>
public class AnalyzedArgument
{
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
    /// 声明类型
    /// </summary>
    [JsonProperty("declaredType", NullValueHandling = NullValueHandling.Ignore)]
    public string DeclaredType { get; set; } = string.Empty;


}