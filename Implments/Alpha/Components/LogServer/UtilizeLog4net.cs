//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Components;
using log4net;
using System;

namespace Ban3.Implements.Alpha.Components.LogServer;

/// <summary>
/// 用Log4net实现日志组件
/// </summary>
public class UtilizeLog4net:ILoggerServer
{
    private readonly ILog Logger = LogManager.GetLogger(typeof(UtilizeLog4net));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ex"></param>
    public void Error(Exception ex) => Logger.Error(ex);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public void Info(string message) => Logger.Info(message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public void Debug(string message) => Logger.Debug(message);
}
