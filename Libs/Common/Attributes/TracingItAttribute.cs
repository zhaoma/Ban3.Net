using Rougamo;
using Rougamo.Context;
using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using log4net;

namespace Ban3.Infrastructures.Common.Attributes;

/// <summary>
/// 
/// </summary>
public class TracingItAttribute : MoAttribute
{
    /// <summary>
    /// 记录所有方法
    /// </summary>
    public override AccessFlags Flags { get; } = AccessFlags.All;
    static readonly ILog Logger = LogManager.GetLogger(typeof(TracingItAttribute));
    readonly Stopwatch _stopwatch = new ();

    /// 
    public override void OnEntry(MethodContext context)
    {
        _stopwatch.Start();
        Logger.Debug($"{ context.Method.Name}:{ context.Arguments.ObjToJson()}.");
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
        _stopwatch.Stop();
        Logger.Debug($"{context.Method.Name}:{_stopwatch.ElapsedMilliseconds} ms");
    }

    /// 
    public override void OnSuccess(MethodContext context)
    {
        Logger.Debug($"{context.Method.Name} success.");
    }
}