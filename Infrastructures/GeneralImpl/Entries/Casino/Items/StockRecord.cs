//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 有日期的记录
/// </summary>
public class StockRecord : IStockRecord
{
    /// <summary>
    /// 日期用yyyyMMdd格式的string
    /// </summary>
    public string RecordDate { get; set; }
}