// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 可实现评估的声明
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEvaluation<in T> : IStockValue
{
    /// <summary>
    /// 评判指标
    /// </summary>
    /// <param name="previousValue">上期值</param>
    /// <returns></returns>
    bool Judge( T previousValue );
}