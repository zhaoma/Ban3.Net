//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Enums;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 价格信息
/// </summary>
public class Price : IPrice
{

    [JsonIgnore]
    public List<string> RequestFields = new List<string>
    {
        "ts_code", "trade_date",
        "open", "high", "low", "close", "pre_close",
        "change", "pct_chg", "vol","amount"
    };

    /// <summary>
    /// 股票代码
    /// </summary>
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 行情时间
    /// </summary>
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(YmdConverter))]
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 开盘价
    /// </summary>
    [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Open { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
    public decimal High { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Low { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Close { get; set; }

    /// <summary>
    /// 昨收价(前复权)
    /// </summary>
    [JsonProperty("preClose", NullValueHandling = NullValueHandling.Ignore)]
    public decimal PreClose { get; set; }

    /// <summary>
    /// 涨跌额
    /// </summary>
    [JsonProperty("change", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Change { get; set; }

    /// <summary>
    /// 涨跌幅 （未复权 ）
    /// </summary>
    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public decimal ChangePercent { get; set; }

    /// <summary>
    /// 成交量 （手）
    /// </summary>
    [JsonProperty("volumn", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Volumn { get; set; }

    /// <summary>
    /// 成交额 （万元）
    /// </summary>
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Amount { get; set; }

    /// <summary>
    /// 换手率
    /// </summary>
    [JsonProperty("turnover", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Turnover { get; set; }

    public Price()
    {
    }


    public Price(List<string> row)
    {
        Code = row[0];
        MarkTime = row[1].ToDateTimeEx();
        Open = row[2].ToDecimal();
        High = row[3].ToDecimal();
        Low = row[4].ToDecimal();
        Close = row[5].ToDecimal();
        PreClose = row[6].ToDecimal();
        Change = row[7].ToDecimal();
        ChangePercent = row[8].ToDecimal();
        Volumn = row[9].ToDecimal();
        Amount = row[10].ToDecimal();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="upOrDown"></param>
    /// <param name="closeOrReach"></param>
    /// <returns></returns>
    public bool IsLimit(bool upOrDown, bool closeOrReach)
    {
        var percent = upOrDown ? 10 : -10;

        if (Code.StartsWith("30") || Code.StartsWith("68"))
            percent = upOrDown ? 20 : -20;

        if (Code.StartsWith("4") || Code.StartsWith("8"))
            percent = upOrDown ? 30 : -30;

        var to = closeOrReach ? Close : (upOrDown ? High : Low);

        return Infrastructures.Common.Extensions.Helper
            .IsLimit(to.ToDouble(), PreClose.ToDouble(), percent);
    }
}
