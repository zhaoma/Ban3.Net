using Rougamo;
using Rougamo.Context;
using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using log4net;

namespace Ban3.Infrastructures.Common.Attributes;

/// <summary>
/// 用Rougamo 记录方法(方法的执行耗时)
/// 配置在appsettings.json: TraceSetting:BindFlags/Timing/LoggingArguments
/// 默认(未设置) public/true/false
/// </summary>
public class TracingItAttribute : MoAttribute
{
    /// <summary>
    /// 记录所有方法
    /// </summary>
    public override AccessFlags Flags { get; } = Config.TraceSetting.BindFlags;
    static readonly ILog Logger = LogManager.GetLogger(typeof(TracingItAttribute));
    readonly Stopwatch _stopwatch = new ();
    
    /// 
    public override void OnEntry(MethodContext context)
    {
        if (Config.TraceSetting.Timing)
            _stopwatch.Start();

        var debugInfo =$"ENTRY:{context.Method.DeclaringType}.{context.Method.Name}";

        if (Config.TraceSetting.LoggingArguments)
            debugInfo += $"{context.Arguments.ObjToJson()}.";

        Logger.Debug(debugInfo);
    }

    /// 
    public override void OnException(MethodContext context)
    {
        Logger.Error($"{context.Method.Name} exception.");
        Logger.Error(context.Exception);
    }

    /// 
    public override void OnExit(MethodContext context)
    {
        if (Config.TraceSetting.Timing)
        {
            _stopwatch.Stop();
            Logger.Debug($"EXIT: {context.Method.DeclaringType}.{context.Method.Name}:{_stopwatch.ElapsedMilliseconds} ms");
        }
    }

    /// 
    public override void OnSuccess(MethodContext context)
    {
        Logger.Debug($"{context.Method.DeclaringType}.{context.Method.Name} success.");
    }
}