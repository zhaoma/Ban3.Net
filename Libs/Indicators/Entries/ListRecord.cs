using System;
using Ban3.Infrastructures.Indicators.Outputs;

namespace Ban3.Infrastructures.Indicators.Entries;
#nullable enable
public class ListRecord
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

    public string Code { get; set; }
    
    public string Symbol { get; set; }

    public int Value { get; set; }

    public int Rank { get; set; }

    public decimal Close { get; set; }

    public DateTime MarkTime { get; set; }
}