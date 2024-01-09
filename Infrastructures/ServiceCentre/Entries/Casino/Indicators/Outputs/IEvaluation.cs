//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

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
    /// <param name="price">行情值</param>
    /// <returns></returns>
    bool Judge( T previousValue, IStockPrice price );
}