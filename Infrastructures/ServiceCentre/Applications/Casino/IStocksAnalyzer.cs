﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 标的数据分析
/// </summary>
public interface IStocksAnalyzer
{
    /// <summary>
    /// 用指标生成特征值
    /// </summary>
    /// <param name="output"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryGenerateFeatures(
        IOutput output,
        Action<IStockData<IStockFeature>> action
    );

    /// <summary>
    /// 提供(个股)特征值
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IStockData<IStockFeature>> TryLoadFeatures( IStock stock );

    /// <summary>
    /// 用特征值生成建议
    /// </summary>
    /// <param name="stockFilter"></param>
    /// <param name="stockFeatures"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryGenerateSuggests(
        IStockFilter stockFilter,
        IStockData<IStockFeature> stockFeatures,
        Action<IStockData<IStockSuggest>> action
    );

    /// <summary>
    /// 提供(个股)建议
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IStockData<IStockSuggest>> TryLoadSuggests( IStock stock );
}