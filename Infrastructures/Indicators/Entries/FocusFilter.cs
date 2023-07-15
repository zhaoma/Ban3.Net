using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Enums;

namespace Ban3.Infrastructures.Indicators.Entries;

public class FocusFilter
{
    public string Identity { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public Dictionary<StockAnalysisCycle, float>? BuyingCondition { get; set; }

    public Dictionary<StockAnalysisCycle, float>? SellingCondition { get; set; }

    public bool IsMatch(
        double? changePercent, 
        StockAnalysisCycle cycle, 
        out bool isDotOfBuying)
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