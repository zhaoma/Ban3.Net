using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

/// <summary>
/// 接口返回的结果
/// </summary>
public class ApiResponseData
{
    /// <summary>
    /// 索取的字段
    /// </summary>
    [JsonProperty("fields")] public List<string> Fields { get; set; } = new();

    /// <summary>
    /// 索取结果数组的集合
    /// </summary>
    [JsonProperty("items")] public List<List<string>> Items { get; set; } = new();
}