using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

/// <summary>
/// 
/// </summary>
public class ProfileSummary
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty("identity", NullValueHandling = NullValueHandling.Ignore)]
    public string Identity { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("stockCount", NullValueHandling = NullValueHandling.Ignore)]
    public int StockCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("recordCount", NullValueHandling = NullValueHandling.Ignore)]
    public int RecordCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("rightCount", NullValueHandling = NullValueHandling.Ignore)]
    public int RightCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("best", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Best { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("worst", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Worst { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("average", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Average { get; set; }
}