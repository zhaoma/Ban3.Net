using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

/// <summary>
/// A股日线行情
/// https://tushare.pro/document/2?doc_id=27
/// </summary>
public class StockPrice
{
    [JsonIgnore]
    public List<string > RequestFields = new()
    {
        "ts_code", "trade_date", "open", "high", "low", "close", "pre_close", "change","pct_chg","vol","amount"
    };

    /// <summary>
    /// 股票代码
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 交易日期
    /// </summary>
    public string TradeDate { get; set; } = string.Empty;

    /// <summary>
    /// 开盘价
    /// </summary>
    public float Open { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    public float High { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    public float Low { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    public float Close { get; set; }

    /// <summary>
    /// 昨收价(前复权)
    /// </summary>
    public float PreClose { get; set; }

    /// <summary>
    /// 涨跌额
    /// </summary>
    public float Change { get; set; }

    /// <summary>
    /// 涨跌幅 （未复权 ）
    /// </summary>
    public float ChangePercent { get; set; }

    /// <summary>
    /// 成交量 （手）
    /// </summary>
    public float Vol { get; set; }

    /// <summary>
    /// 成交额 （千元）
    /// </summary>
    public float Amount { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public StockPrice(){}

    public StockPrice(List<string> row)
    {
        Code = row[0];
        TradeDate = row[1];
        Open = row[2].ToFloat();
        High = row[3].ToFloat();
        Low= row[4].ToFloat();
        Close = row[5].ToFloat();
        PreClose= row[6].ToFloat();
        Change= row[7].ToFloat();
        ChangePercent= row[8].ToFloat();
        Vol= row[9].ToFloat();
        Amount= row[10].ToFloat();
    }

    public bool IsLimitUp()
    {
        if (Code.StartsWith("30")||Code.StartsWith("68"))
            return ((double)Close).IsLimit((double)PreClose, 20);

        return ((double)Close).IsLimit((double)PreClose, 10);
    }

    public bool IsLimitDown()
    {
        if (Code.StartsWith("30") || Code.StartsWith("68"))
            return ((double)Close).IsLimit((double)PreClose, -20);

        return ((double)Close).IsLimit((double)PreClose, -10);
    }
}