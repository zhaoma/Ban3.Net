#nullable enable
using System;
using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Request;

public class FocusFilter
{
    public string Identity { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public Dictionary<StockAnalysisCycle, float>? MinChangePercent { get; set; }

    public Dictionary<StockAnalysisCycle, float>? MaxChangePercent { get; set; }

    public bool IsMatch(StockPrice price, StockAnalysisCycle cycle)
    {
        var result = Math.Abs(price.Open - price.Close) > 0.01F;

        if (MinChangePercent != null&&MinChangePercent.TryGetValue(cycle, out var min))
        {
            result = price.ChangePercent >= min;
        }

        if (MaxChangePercent != null&& MaxChangePercent.TryGetValue(cycle, out var max))
        {
            result = result && price.ChangePercent <= MaxChangePercent[cycle];
        }
        
        return result;
    }
}