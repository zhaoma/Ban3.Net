//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components;
using Ban3.Infrastructures.Contracts.Applications;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 股市服务，批处理部分
/// </summary>
public partial class CasinoServer : ICasinoServer
{
    private readonly ICacheServer _cacheServer;
    private readonly IChartServer _chartServer;
    private readonly IDatabaseServer _databaseServer;
    private readonly IHttpServer _httpServer;
    private readonly ILoggerServer _logger;
    private readonly IMailServer _mailServer;
    private readonly IMessageServer _messageServer;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="cacheServer"></param>
    /// <param name="chartServer"></param>
    /// <param name="databaseServer"></param>
    /// <param name="httpServer"></param>
    /// <param name="logger"></param>
    /// <param name="mailServer"></param>
    /// <param name="messageServer"></param>
    public CasinoServer(
        ICacheServer cacheServer,
        IChartServer chartServer,
        IDatabaseServer databaseServer,
        IHttpServer httpServer,
        ILoggerServer logger,
        IMailServer mailServer,
        IMessageServer messageServer)
    {
        _cacheServer = cacheServer;
        _chartServer = chartServer;
        _databaseServer = databaseServer;
        _httpServer = httpServer;
        _logger = logger;
        _mailServer = mailServer;
        _messageServer = messageServer;
    }

    /// <summary>
    /// 基础数据准备
    /// </summary>
    public void BaseTask()
    {
        PrepareStocks();

        PrepareAllBonus();

        CalculateAllSeeds();
    }

    /// <summary>
    /// 每日任务
    /// </summary>
    public void DailyTask(List<Stock> stocks)
    {
        stocks.Where(o => o.Suggest != SuggestIs.Ignore).ParallelExecute((stock) =>
        {
            OnesTask(stock);
        }, 20);
    }

    /// <summary>
    /// 标的任务
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool OnesTask(Stock stock)
    {
        var now = DateTime.Now;

        var result = CollectOnesPrices(stock);

        result = result && ReinstateOnesPrices(stock);

        result = result && AnalyzeOne(stock);

        _logger.Debug($"{stock.Code} : {DateTime.Now.Subtract(now).Milliseconds} ms elapsed.");

        return result;
    }

}
