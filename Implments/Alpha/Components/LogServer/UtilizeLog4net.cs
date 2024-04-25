//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components;
using log4net;
using System;

namespace Ban3.Implements.Alpha.Components.LogServer;

/// <summary>
/// 用Log4net实现日志组件
/// </summary>
public class UtilizeLog4net:ILoggerServer
{
    private readonly ILog Logger = LogManager.GetLogger(typeof(UtilizeLog4net));

    public void Error(Exception ex) => Logger.Error(ex);

    public void Info(string message) => Logger.Info(message);

    public void Debug(string message) => Logger.Debug(message);
}
