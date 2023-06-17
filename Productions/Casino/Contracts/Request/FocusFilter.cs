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

    public Dictionary<StockAnalysisCycle, float>? BuyingCondition { get; set; }

    public Dictionary<StockAnalysisCycle, float>? SellingCondition { get; set; }

    public bool IsMatch(float changePercent, StockAnalysisCycle cycle, out bool isDotOfBuying)
    {
        isDotOfBuying = false;
        var result = false;

        if (changePercent > 0)
        {
            if (BuyingCondition != null && BuyingCondition.TryGetValue(cycle, out var min))
            {
                result = changePercent >= min;
                isDotOfBuying = true;
            }
        }
        else
        {
            if (SellingCondition != null && SellingCondition.TryGetValue(cycle, out var max))
            {
                result = changePercent <= max;
                isDotOfBuying = false;
            }
        }

        return result;
    }
}