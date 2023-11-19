// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
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
    /// <param name="score">得分</param>
    /// <param name="keys">输出特征</param>
    /// <returns></returns>
    bool Judge( T previousValue, out int score, out IEnumerable<string> keys );

}