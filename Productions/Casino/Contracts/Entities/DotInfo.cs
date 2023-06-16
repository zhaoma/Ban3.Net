using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class DotInfo
{
    public bool IsDotOfBuying { get; set; }

    public StockAnalysisCycle Cycle { get; set; }

    public string TradeDate { get; set; }

    public int Days { get; set; }

    public float ChangePercent { get; set; }

    public float Close { get; set; }
}