using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    private const BindingFlags BindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;

    private static volatile Dictionary<int, CompiledMethodInfo> _cachedMembers =
        new Dictionary<int, CompiledMethodInfo>();

    public static object? Invoke<T>(this T obj, string methodName, params object[] args)
    {
        var type = obj.GetType();
        var hash = Hash(type, methodName, args);
        var exists = _cachedMembers.TryGetValue(hash, out var method);
        if (exists) return method?.Invoke(obj, args);
        lock (ObjLock)
        {
            //Recheck if exist inside lock in case another thread has added it.
            exists = _cachedMembers.TryGetValue(hash, out method);
            if (exists) return method?.Invoke(obj, args);

            var argTypes = args.Select(o => o.GetType()).ToArray();
            var m = GetMember(type, methodName, argTypes);
            method = m == null ? null : new CompiledMethodInfo(m, type);

            var dict = new Dictionary<int, CompiledMethodInfo>(_cachedMembers) { { hash, method } };

            _cachedMembers = dict;
            return method.Invoke(obj, args);
        }
    }

    public static string GetImplementationNameOfInterfaceMethod(this Type implementation, Type @interface,
        string methodName, params Type[] argTypes)
    {
        var map = implementation.GetInterfaceMap(@interface);
        var method = map.InterfaceMethods.Single(x =>
            x.Name == methodName && x.GetParameters().Select(p => p.ParameterType).SequenceEqual(argTypes));
        var index = Array.IndexOf(map.InterfaceMethods, method);
        return map.TargetMethods[index].Name;
    }

    private static int Hash(Type type, string methodName, object[] args)
    {
        var hash = 23;
        hash = hash * 31 + type.GetHashCode();
        hash = hash * 31 + methodName.GetHashCode();

        return args.Select(t => t.GetType()).Aggregate(hash, (current, argType) => current * 31 + argType.GetHashCode());
    }
    
    private static MethodInfo? GetMember(Type type, string name, Type[] argTypes)
    {
        while (true)
        {
            var methods = type.GetMethods(BindingFlags).Where(m => m.Name == name).ToArray();
            var member =
                methods.FirstOrDefault(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(argTypes)) ??
                methods.FirstOrDefault(m => m.GetParameters().Select(p => p.ParameterType).ToArray().Matches(argTypes));

            if (member != null)
            {
                return member;
            }

            var t = type.GetTypeInfo().BaseType;
            if (t == null)
            {
                return null;
            }

            type = t;
        }
    }

}

internal class CompiledMethodInfo
{
    private readonly Func<object, object[], object> _func;

    public CompiledMethodInfo(MethodInfo methodInfo, Type type)
    {
        var instanceExpression = Expression.Parameter(typeof(object), "instance");
        var argumentsExpression = Expression.Parameter(typeof(object[]), "arguments");
        var parameterInfos = methodInfo.GetParameters();

        var argumentExpressions = new Expression[parameterInfos.Length];
        for (var i = 0; i < parameterInfos.Length; ++i)
        {
            var parameterInfo = parameterInfos[i];
            argumentExpressions[i] =
                Expression.Convert(Expression.ArrayIndex(argumentsExpression, Expression.Constant(i)),
                    parameterInfo.ParameterType);
        }

        var callExpression = Expression.Call(!methodInfo.IsStatic ? Expression.Convert(instanceExpression, type) : null,
            methodInfo, argumentExpressions);
        if (callExpression.Type == typeof(void))
        {
            var action = Expression
                .Lambda<Action<object, object[]>>(callExpression, instanceExpression, argumentsExpression).Compile();
            _func = (instance, arguments) =>
            {
                action(instance, arguments);
                return null;
            };
        }
        else
        {
            _func = Expression
                .Lambda<Func<object, object[], object>>(Expression.Convert(callExpression, typeof(object)),
                    instanceExpression, argumentsExpression).Compile();
        }
    }

    public object Invoke(object instance, params object[] arguments)
    {
        return _func(instance, arguments);
    }
}
