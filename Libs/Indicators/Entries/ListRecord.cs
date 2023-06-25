using System;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;
#nullable enable

/// <summary>
/// 标的排名
/// </summary>
public class ListRecord:Record
{
    public ListRecord(){}

    public ListRecord(StockSets sets)
    {
        Code = sets.Code;
        Symbol = sets.Symbol;
        Close = sets.Close;
        MarkTime = sets.MarkTime;

        if (sets.Evaluation(out var _, out int value))
        {
            Value = value;
        }
    }

    /// <summary>
    /// TS_CODE
    /// </summary>
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }

    /// <summary>
    /// 代码
    /// </summary>
    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    /// <summary>
    /// 计分
    /// </summary>
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public int Value { get; set; }

    /// <summary>
    /// 排名
    /// </summary>
    [JsonProperty("rank", NullValueHandling = NullValueHandling.Ignore)]
    public int Rank { get; set; }

    /// <summary>
    /// 最新收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Close { get; set; }

}