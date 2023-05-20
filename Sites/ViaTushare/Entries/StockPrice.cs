using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

public class StockPrice
{
    [JsonIgnore]
    public List<string > RequestFields = new()
    {
        "ts_code", "trade_date", "open", "high", "low", "close", "pre_close", "change","pct_chg","vol","amount"
    };


    public string Code { get; set; }

    public string TradeDate { get; set; }

    public float Open { get; set; }
    public float High { get; set; }
    public float Low { get; set; }
    public float Close { get; set; }
    public float PreClose { get; set; }

    public float Change { get; set; }

    public float ChangePercent { get; set; }
    
    public float Vol { get; set; }
    
    public float Amount { get; set; }

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
}