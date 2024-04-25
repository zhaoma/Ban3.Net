//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Components;

/// <summary>
/// 日志记录服务
/// </summary>
public interface ILoggerServer
{
    /// <summary>
    /// 错误
    /// </summary>
    /// <param name="ex"></param>
    void Error(Exception ex);

    /// <summary>
    /// 信息
    /// </summary>
    /// <param name="message"></param>
    void Info(string message);

    /// <summary>
    /// 调试
    /// </summary>
    /// <param name="message"></param>
    void Debug(string message);
}
