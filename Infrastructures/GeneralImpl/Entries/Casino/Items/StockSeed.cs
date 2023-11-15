// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 复权因子
/// </summary>
public class StockSeed : StockRecord, IStockSeed
{
    /// <summary>
    /// 复权系数
    /// </summary>
    public decimal Factor { get; set; }
}