/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * 跟踪拦截器
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

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using Castle.DynamicProxy;
using log4net;

namespace Ban3.Infrastructures.DependecyInjection.Interceptors
{
    /// <summary>
    /// 跟踪拦截器
    /// </summary>
    public class TraceInterceptor
            : IInterceptor
    {
        static ILog _logger = LogManager.GetLogger(typeof(TraceInterceptor));
        
	    /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _logger.Debug($"calling : '{invocation.Method.Name}' arguments : {invocation.Arguments.ObjToJson()}...");

            invocation.Proceed();

            var returnType = invocation.Method.ReturnType;

            if (invocation.Method.IsAsyncMethod())
            {
                if (returnType != null && returnType == typeof(Task))
                {
                    Func<Task> res = async () => await (Task)invocation.ReturnValue;

                    invocation.ReturnValue = res();
                }
                else
                {
                    var reflectedType = invocation.Method.ReflectedType;//获取返回类型

                    if (reflectedType != null)
                    {
                        var resultType = returnType!.GetGenericArguments()[0];

                        var methodInfo = typeof(TraceInterceptor)
                            .GetMethod("HandleAsync", BindingFlags.Instance | BindingFlags.Public);

                        var mi = methodInfo.MakeGenericMethod(resultType);
                        invocation.ReturnValue = mi.Invoke(this, new[] { invocation.ReturnValue });
                    }
                }
            }

            stopwatch.Stop();
            _logger.Debug($"execute finished {stopwatch.ElapsedMilliseconds} ms , return ：{invocation.ReturnValue.ObjToJson()}");
        }

        async Task<T> HandleAsync<T>(Task<T> task)
        {
            var t = await task;

            return t;
        }
    }
}