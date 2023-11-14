// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 计算输出结果声明
/// </summary>
public interface IOutput : IStockCode
{
    /// <summary>
    /// 计算结果：公式结果集合->特征集合+得分（分周期）
    /// </summary>
    IStockData<IComputedResult> ComputedResults { get; set; }
}