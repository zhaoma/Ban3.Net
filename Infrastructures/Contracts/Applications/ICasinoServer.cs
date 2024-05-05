//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Applications;

/// <summary>
/// Casino服务
/// </summary>
public interface ICasinoServer
{
    /// <summary>
    /// 基础数据准备
    /// </summary>
    void BaseTask();

    /// <summary>
    /// 每日任务
    /// </summary>
    void DailyTask(List<Stock> stocks);

    /// <summary>
    /// 标的任务
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    bool OnesTask(Stock stock);

    /// <summary>
    /// 准备标的
    /// </summary>
    /// <returns></returns>
    bool PrepareStocks();

    /// <summary>
    /// 获取标的
    /// </summary>
    /// <returns></returns>
    List<Stock> LoadStocks();

    /// <summary>
    /// 准备所有标的分红解禁事件信息
    /// </summary>
    void PrepareAllBonus();

    /// <summary>
    /// 准备标的分红解禁事件信息
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    bool PrepareOnesBonus(Stock stock);

    /// <summary>
    /// 获取标的分红解禁事件信息
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    List<Bonus> LoadOnesBonus(Stock stock);

    /// <summary>
    /// 收集所有标的行情数据
    /// </summary>
    /// <returns></returns>
    bool CollectAllPrices();

    /// <summary>
    /// 收集标的行情数据
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    bool CollectOnesPrices(Stock target);

    /// <summary>
    /// 获取价格数据
    /// </summary>
    /// <param name="target"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    List<Price> LoadOnesPrices(Stock target, CycleIs? cycle);

    /// <summary>
    /// 计算所有标的复权因子
    /// </summary>
    /// <returns></returns>
    bool CalculateAllSeeds();

    /// <summary>
    /// 计算标的复权因子
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    bool CalculateOnesSeeds(Stock stock);

    /// <summary>
    /// 获取复权因子
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    List<Reinstate> LoadOnesSeeds(Stock stock);

    /// <summary>
    /// 计算标的复权价格
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    bool ReinstateOnesPrices(Stock stock);

    /// <summary>
    /// 分析标的指标与特征值
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    bool AnalyzeOne(Stock stock);

    /// <summary>
    /// 获取标的指标与特征值
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    Result LoadResult(Stock target);

    /// <summary>
    /// 生成汇总报告
    /// </summary>
    /// <returns></returns>
    bool GenerateSummary(List<Stock> stocks);

    /// <summary>
    /// 获取汇总报告
    /// </summary>
    /// <returns></returns>
    Summary LoadSummary();
}
