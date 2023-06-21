using Ban3.Infrastructures.Common.Extensions;
using Ban3.Sites.ViaNetease.Entries;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class StockRuntimeRecord
{
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("tradeDate", NullValueHandling = NullValueHandling.Ignore)]
    public string TradeDate { get; set; }

    [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
    public float Open { get; set; }

    [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
    public float High { get; set; }

    [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
    public float Low { get; set; }

    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }

    [JsonProperty("preClose", NullValueHandling = NullValueHandling.Ignore)]
    public float PreClose { get; set; }

    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public float ChangePercent { get; set; }

    [JsonProperty("vol", NullValueHandling = NullValueHandling.Ignore)]
    public float Vol { get; set; }

    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public float Amount { get; set; }

    public StockRuntimeRecord() { }

    public StockRuntimeRecord(StockRecord o)
    {
        Code = o.Symbol;
        TradeDate = o.Time.ToYmd();
        Open = (float)o.Open;
        High = (float)o.High;
        Low = (float)o.Low;
        Close = (float)o.Price;
        PreClose = (float)o.YestClose;
        ChangePercent = (float)o.Percent * 100;
        Vol = (float)o.Volume;
        Amount = (float)o.TurnOver;
    }
}