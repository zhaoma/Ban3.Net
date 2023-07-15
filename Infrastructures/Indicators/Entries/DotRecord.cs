using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

public class DotRecord
{
    public DotRecord() { }

    public DotRecord(DotInfo info) {
        Code = info.Code;
        ChangePercent = info.ChangePercent;
        TradeDate = info.TradeDate;
        SetKeys = info.SetKeys?.ToList();
    }

    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code
    {
        get; set;
    } = string.Empty;

    [JsonProperty("tradeDate", NullValueHandling = NullValueHandling.Ignore)]
    public string TradeDate { get; set; } = string.Empty;

    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public double? ChangePercent { get; set; }


    [JsonProperty("setKeys", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? SetKeys { get; set; }
}
