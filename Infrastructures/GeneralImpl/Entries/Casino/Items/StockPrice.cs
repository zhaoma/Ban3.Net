// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 标的价格数据声明
/// </summary>
public class StockPrice : StockRecord, IStockPrice
{
    /// <summary>
    /// 前收盘价
    /// </summary>
    public decimal PreClose { get; set; }

    /// <summary>
    /// 开盘价
    /// </summary>
    public decimal Open { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    public decimal Close { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    public decimal High { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    public decimal Low { get; set; }

    /// <summary>
    /// 换手率
    /// </summary>
    public decimal Turnover { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    public double Vol { get; set; }

    /// <summary>
    /// 交易额
    /// </summary>
    public double Amount { get; set; }
}