using System.Collections.Generic;
using Newtonsoft.Json;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// 程序集信息
/// </summary>
public class AssemblyFile
{
    /// <summary>
    /// 文件名
    /// </summary>
    [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 文件类型
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string FileType { get; set; } = string.Empty;

    /// <summary>
    /// 完整路径
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string FullPath { get; set; } = string.Empty;

    /// <summary>
    /// 是否托管库
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsManaged { get; set; }

    /// <summary>
    /// 引用或依赖集
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public List<ReferencedAssembly>? ReferencesOrDependencies { get; set; }

    /// <summary>
    /// 被引用路径
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public List<string[]>? HighLevels { get; set; }

    /// <summary>
    /// 引用路径
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public List<string[]>? LowLevels { get; set; }
}