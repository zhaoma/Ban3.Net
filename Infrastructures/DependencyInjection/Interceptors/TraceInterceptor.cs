// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Castle.DynamicProxy;

using log4net;

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.DependencyInjection.Interceptors;

/* —————————————————————————————————————————————————————————————————————————————
 * https://github.com/castleproject/Core
 * public interface IInvocation
    {
        object[] Arguments { get; }
        Type[] GenericArguments { get; }
        MethodInfo Method { get; }
        MethodInfo MethodInvocationTarget { get; }
        object Proxy { get; }
        object ReturnValue { get; set; }
        Type TargetType { get; }

        IInvocationProceedInfo CaptureProceedInfo();
        object GetArgumentValue(int index);
        MethodInfo GetConcreteMethod();
        MethodInfo GetConcreteMethodInvocationTarget();
        void Proceed();
        void SetArgumentValue(int index, object value);
    }

 * —————————————————————————————————————————————————————————————————————————————
 */

/// <summary>
/// 跟踪拦截器
/// </summary>
public class TraceInterceptor
    : IInterceptor
{
    static ILog _logger = LogManager.GetLogger( typeof( TraceInterceptor ) );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="invocation"></param>
    public void Intercept( IInvocation invocation )
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        _logger.Debug( $"calling : '{invocation.Method.Name}'..." );

        invocation.Proceed();

        var returnType = invocation.Method.ReturnType;

        if( returnType != null && returnType == typeof( Task ) )
        {
            Func<Task> res = async () => await (Task)invocation.ReturnValue;

            invocation.ReturnValue = res();
        }
        else
        {
            var reflectedType = invocation.Method.ReflectedType; //获取返回类型

            if( reflectedType != null )
            {
                var resultType = returnType!.GetGenericArguments()[ 0 ];

                var methodInfo = typeof( TraceInterceptor )
                   .GetMethod( "HandleAsync", BindingFlags.Instance | BindingFlags.Public );

                var mi = methodInfo.MakeGenericMethod( resultType );
                invocation.ReturnValue = mi.Invoke( this, new[] { invocation.ReturnValue } );
            }
        }

        stopwatch.Stop();
        _logger.Debug(
            $"execute elapsed {stopwatch.ElapsedMilliseconds} ms." );
    }

    async Task<T> HandleAsync<T>( Task<T> task )
    {
        var t = await task;

        return t;
    }
}