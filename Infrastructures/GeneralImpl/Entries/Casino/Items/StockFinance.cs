// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 标的财务数据声明
/// </summary>
public class StockFinance : StockRecord, IStockFinance
{
    /// <summary>
    /// 每股净资产
    /// </summary>
    public decimal Equity { get; set; }

    /// <summary>
    /// 每股收益
    /// </summary>
    public decimal Earnings { get; set; }

    /// <summary>
    /// 总资产
    /// </summary>
    public decimal Assets { get; set; }

    /// <summary>
    /// 总负债
    /// </summary>
    public decimal Debts { get; set; }

    /// <summary>
    /// 总利润
    /// </summary>
    public decimal Profits { get; set; }

    /// <summary>
    /// 收益率
    /// </summary>
    public decimal RateOfReturn { get; set; }

    /// <summary>
    /// 原始股本
    /// </summary>
    public long CapitalOriginal { get; set; }

    /// <summary>
    /// 流通股本
    /// </summary>
    public long NegotiableCapital { get; set; }

    /// <summary>
    /// 总股本
    /// </summary>
    public long Capital { get; set; }

    /// <summary>
    /// 流通股本
    /// </summary>
    public long Tradable { get; set; }
}