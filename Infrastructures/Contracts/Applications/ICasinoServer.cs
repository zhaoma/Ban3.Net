//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Contracts.Applications;

/// <summary>
/// Casino服务
/// </summary>
public interface ICasinoServer
{
    /// <summary>
    /// 准备标的
    /// </summary>
    /// <param name="withEvents">下载事件数据（周期长）</param>
    /// <returns></returns>
    Task<bool> PrepareAsync(bool withEvents);

    /// <summary>
    /// 获取标的
    /// </summary>
    /// <returns></returns>
    List<IStock> LoadTargets();

    /// <summary>
    /// 收集行情数据
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    Task<bool> CollectPrices(IStock target);

    /// <summary>
    /// 获取价格数据
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    List<IPrice> LoadPrices(IStock target, CycleIs? cycle);

    /// <summary>
    /// 计算指标与特征值
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    Task<IResult> Calculate(IStock target);

    /// <summary>
    /// 获取指标与特征是
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    IResult LoadResult(IStock target);

    /// <summary>
    /// 生成汇总报告
    /// </summary>
    /// <returns></returns>
    Task<bool> GenerateSummary();

    /// <summary>
    /// 获取汇总报告
    /// </summary>
    /// <returns></returns>
    ISummary LoadSummary();
}
