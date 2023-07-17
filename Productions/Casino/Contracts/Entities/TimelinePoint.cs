using System;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Outputs;
using System.Linq;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class TimelinePoint
{
    public TimelinePoint() { }

    public TimelinePoint(StockSets sets)
    {
        Date = sets.MarkTime.ToYmd();
        Close = sets.Close;
        SetKeys = sets.SetKeys!.ToList();
    }

    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    public string Date { get; set; } = string.Empty;

    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public double Close { get; set; }

    [JsonIgnore]
    public List<string>? SetKeys { get; set; }

    public string Html(double? preClose)
    {
        var result = "";
        var d = Date.FromYmd().ToString("yyMMdd");
        if (preClose != null)
        {
            var className = Close > preClose ? "red" : "green";
            var ratio = Math.Round((Close - preClose.Value) / preClose.Value * 100D, 2);
            result += $"<span class='{className}'>{d} {Close} <span class='badge'>{ratio} %</span></span>";
        }
        else
        {
            result = $" <span>{d} {Close}</span>";
        }

        return result;
    }
}
