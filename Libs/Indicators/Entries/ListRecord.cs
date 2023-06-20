using System;
using Ban3.Infrastructures.Indicators.Outputs;

namespace Ban3.Infrastructures.Indicators.Entries;
#nullable enable

/// <summary>
/// 标的排名
/// </summary>
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

    /// <summary>
    /// TS_CODE
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// 代码
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// 计分
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// 排名
    /// </summary>
    public int Rank { get; set; }

    /// <summary>
    /// 最新收盘价
    /// </summary>
    public decimal Close { get; set; }

    /// <summary>
    /// 标记事件
    /// </summary>
    public DateTime MarkTime { get; set; }
}