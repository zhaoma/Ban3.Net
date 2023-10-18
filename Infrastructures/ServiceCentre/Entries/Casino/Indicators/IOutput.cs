using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

/// <summary>
/// 计算输出结果声明
/// </summary>
public interface IOutput:IStockRecord
{
    /// <summary>
    /// 计算结果：公式结果集合->特征集合+得分（分周期）
    /// </summary>
    IEnumerable<IComputedResult> ComputedResults { get; set; }
}

