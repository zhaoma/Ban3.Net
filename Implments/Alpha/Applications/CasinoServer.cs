//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Entries.CasinoServer;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components;
using Ban3.Infrastructures.Contracts.Applications;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Ban3.Sites.ViaSina;
using Ban3.Sites.ViaTushare;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 股市服务
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
    /// 每日任务
    /// </summary>
    public void DailyTask(List<IStock> stocks)
    {
        stocks.ParallelExecute((stock) =>
        {
            OnesTask(stock);
        }, 20);
    }

    /// <summary>
    /// 标的任务
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool OnesTask(IStock stock)
    {
        var now = DateTime.Now;

        var result=CollectOnesPrices(stock);

        result= result&&CalculateOnesSeeds(stock);

        result = result && ReinstateOnesPrices(stock);

        result = result && AnalyzeOne(stock);

        _logger.Debug($"{stock.Code} : {DateTime.Now.Subtract(now).Milliseconds} ms elapsed.");

        return result;
    }

}
