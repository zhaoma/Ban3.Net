// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 有编号的记录
/// </summary>
public class StockCode : IStockCode
{
    public string Code { get; set; }
}