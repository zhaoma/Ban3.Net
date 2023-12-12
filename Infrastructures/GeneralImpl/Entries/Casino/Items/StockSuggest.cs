// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 操作建议
/// </summary>
public class StockSuggest : IStockSuggest
{
    public string Code { get; set; }

    /// <summary>
    /// 购买日期
    /// </summary>
    public string BuyDate { get; set; }

    /// <summary>
    /// 购买价格
    /// </summary>
    public decimal BuyPrice { get; set; }

    /// <summary>
    /// 售出日期
    /// </summary>
    public string SellDate { get; set; }

    /// <summary>
    /// 售出价格
    /// </summary>
    public decimal SellPrice { get; set; }

    /// <summary>
    /// 改变比率
    /// </summary>
    public decimal ChangeRatio { get; set; }

    /// <summary>
    /// 建议正确
    /// </summary>
    public bool IsCorrect { get; set; }
}