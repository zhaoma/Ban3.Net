using Newtonsoft.Json;
using Rougamo;
using Rougamo.Context;
using System;
using System.Diagnostics;
using log4net;

namespace Ban3.Infrastructures.Common.Attributes;

/// <summary>
/// 
/// </summary>
public class TracingItAttribute : MoAttribute
{
    public override AccessFlags Flags { get; } = AccessFlags.All;

    readonly Stopwatch _stopwatch = new Stopwatch();

    /// 
    public override void OnEntry(MethodContext context)
    {
        _stopwatch?.Start();
        Console.WriteLine($"执行方法 { context.Method.Name} () 开始, 参数：{ JsonConvert.SerializeObject(context.Arguments)}.");
    }
    
    /// 
    public override void OnException(MethodContext context)
    {
        Console.WriteLine($"执行方法 {context.Method.Name}() 异常, {context.Exception?.Message}.");
    }
    
    /// 
    public override void OnExit(MethodContext context)
    {
        _stopwatch.Stop();

        
        Console.WriteLine($"执行方法 {context.Method.Name}() 结束.用时{_stopwatch.ElapsedMilliseconds} ms");
    }

    /// 
    public override void OnSuccess(MethodContext context)
    {
        Console.WriteLine($"执行方法 {context.Method.Name}() 成功.");
    }
}