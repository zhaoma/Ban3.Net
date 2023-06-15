using Ban3.Sites.ViaTushare.Entries;
using System.Collections.Generic;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class FocusRecord
{
    public FocusRecord(){}

    public FocusRecord(StockPrice price)
    {
        TradeDate = price.TradeDate;
        Open=price.Open;
        High=price.High;
        Low=price.Low;
        Close=price.Close;
        PreClose=price.PreClose;
        ChangePercent=price.ChangePercent;
    }

    public string TradeDate { get; set; }

    public float Open { get; set; }

    public float High { get; set; }

    public float Low { get; set; }

    public float Close { get; set; }

    public float PreClose { get; set; }
    
    public float ChangePercent { get; set; }

    public List<string> SetKeys { get; set; }

    public string SellDate { get; set; }

    public float SellPrice { get; set; }

    public float Gains { get; set; }
}