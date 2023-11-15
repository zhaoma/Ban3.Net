// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 
/// </summary>
public class CompiledMethodInfo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="methodInfo"></param>
    /// <param name="type"></param>
    public CompiledMethodInfo( MethodInfo methodInfo, Type type )
    {
        var instanceExpression = Expression.Parameter( typeof( object ), "instance" );
        var argumentsExpression = Expression.Parameter( typeof( object[] ), "arguments" );
        var parameterInfos = methodInfo.GetParameters();

        var argumentExpressions = new Expression[parameterInfos.Length];
        for( var i = 0; i < parameterInfos.Length; ++i )
        {
            var parameterInfo = parameterInfos[ i ];
            argumentExpressions[ i ] =
                Expression.Convert( Expression.ArrayIndex( argumentsExpression, Expression.Constant( i ) ),
                                    parameterInfo.ParameterType );
        }

        var callExpression = Expression.Call( !methodInfo.IsStatic ? Expression.Convert( instanceExpression, type ) : null,
                                              methodInfo, argumentExpressions );
        if( callExpression.Type == typeof( void ) )
        {
            var action = Expression
                        .Lambda<Action<object, object[]>>( callExpression, instanceExpression, argumentsExpression ).Compile();
            _func = ( instance, arguments ) =>
            {
                action( instance, arguments );
                return null!;
            };
        }
        else
        {
            _func = Expression
                   .Lambda<Func<object, object[], object>>( Expression.Convert( callExpression, typeof( object ) ),
                                                            instanceExpression, argumentsExpression ).Compile();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public object Invoke( object instance, params object[] arguments )
    {
        return _func( instance, arguments );
    }

    private readonly Func<object, object[], object> _func;
}