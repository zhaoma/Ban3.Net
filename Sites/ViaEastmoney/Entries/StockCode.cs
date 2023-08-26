using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries;

/// <summary>
/// 来自eastmoney的StockCode
/// </summary>
public class StockCode
{
    /// <summary>
    /// 编码
    /// </summary>
    [JsonProperty("f12")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 名称
    /// </summary>
    [JsonProperty("f14")]
    public string Name { get; set; } = string.Empty;
}