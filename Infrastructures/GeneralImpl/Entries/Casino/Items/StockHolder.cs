// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

/// <summary>
/// 股东信息声明
/// </summary>
public class StockHolder : StockRecord, IStockHolder
{
    /// 
    public string Code { get; set; }

    /// 
    public string Id { get; set; }

    /// <summary>
    /// 股东类型
    /// </summary>
    public HolderIs HolderIs { get; set; }

    /// <summary>
    /// 持股数量
    /// </summary>
    public long HoldNumber { get; set; }

    /// <summary>
    /// 持有比例
    /// </summary>
    public decimal HoldRatio { get; set; }

    /// <summary>
    /// 持仓变化
    /// </summary>
    public HoldChange HoldChange { get; set; }
}