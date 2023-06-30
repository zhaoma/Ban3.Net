using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

public class ProfileSummary
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty("identity", NullValueHandling = NullValueHandling.Ignore)]
    public string Identity { get; set; } = string.Empty;

    [JsonProperty("stockCount", NullValueHandling = NullValueHandling.Ignore)]
    public int StockCount { get; set; }

    [JsonProperty("recordCount", NullValueHandling = NullValueHandling.Ignore)]
    public int RecordCount { get; set; }

    [JsonProperty("rightCount", NullValueHandling = NullValueHandling.Ignore)]
    public int RightCount { get; set; }

    [JsonProperty("best", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Best { get; set; }

    [JsonProperty("worst", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Worst { get; set; }

    [JsonProperty("average", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Average { get; set; }
}