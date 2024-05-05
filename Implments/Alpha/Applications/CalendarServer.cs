//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components;
using Ban3.Infrastructures.Contracts.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 日历服务
/// </summary>
public partial class CalendarServer:ICalendarServer
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
    public CalendarServer(
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

}
