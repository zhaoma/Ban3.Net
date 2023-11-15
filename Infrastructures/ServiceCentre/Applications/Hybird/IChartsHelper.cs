// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 图表生成接口声明
/// </summary>
public interface IChartsHelper
{
    /// <summary>
    /// 创建图表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryCreate<T>( T data, Action<string, IChartsDiagram> action );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<IChartsDiagram> TryLoad( string key );
}