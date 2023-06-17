using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class DotInfo
{
    [JsonProperty("isDotOfBuying", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsDotOfBuying { get; set; }

    [JsonProperty("cycle", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StockAnalysisCycle Cycle { get; set; }

    [JsonProperty("tradeDate", NullValueHandling = NullValueHandling.Ignore)]
    public string TradeDate { get; set; }

    [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
    public int Days { get; set; }

    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public float ChangePercent { get; set; }

    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }

    [JsonProperty("setKeys", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string>? SetKeys { get; set; }

    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }
    
}