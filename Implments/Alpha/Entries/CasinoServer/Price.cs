//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

public class Price:IPrice
{

    [JsonIgnore]
    public List<string> RequestFields = new List<string>
    {
        "ts_code", "trade_date", 
        "open", "high", "low", "close", "pre_close", 
        "change", "pct_chg", "vol","amount"
    };

    //
    // 摘要:
    //     股票代码
    public string Code { get; set; } = string.Empty;

    public DateTime MarkTime { get; set; }

    //
    // 摘要:
    //     开盘价
    public decimal   Open { get; set; }

    //
    // 摘要:
    //     最高价
    public decimal High { get; set; }

    //
    // 摘要:
    //     最低价
    public decimal Low { get; set; }

    //
    // 摘要:
    //     收盘价
    public decimal Close { get; set; }

    //
    // 摘要:
    //     昨收价(前复权)
    public decimal PreClose { get; set; }

    //
    // 摘要:
    //     涨跌额
    public decimal Change { get; set; }

    //
    // 摘要:
    //     涨跌幅 （未复权 ）
    public decimal ChangePercent { get; set; }

    //
    // 摘要:
    //     成交量 （手）
    public decimal Volumn { get; set; }

    //
    // 摘要:
    //     成交额 （千元）
    public decimal Amount { get; set; }

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

    public bool IsLimitUp()
    {
        if (Code.StartsWith("30") || Code.StartsWith("68"))
        {
            return IsLimit(Close, PreClose, 20m);
        }

        if (Code.StartsWith("4") || Code.StartsWith("8"))
        {
            return IsLimit(Close, PreClose, 30m);
        }

        return IsLimit(Close, PreClose, 10m);
    }

    public bool IsLimitDown()
    {
        if (Code.StartsWith("30") || Code.StartsWith("68"))
        {
            return IsLimit(Close, PreClose, -20m);
        }

        if (Code.StartsWith("4") || Code.StartsWith("8"))
        {
            return IsLimit(Close, PreClose, -30m);
        }

        return IsLimit(Close, PreClose, -10m);
    }

    private bool IsLimit(decimal close, decimal preClose,decimal percent) 
        => Helper.IsLimit(Close.ToDouble(), PreClose.ToDouble(), percent);
}
