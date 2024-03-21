//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    private const BindingFlags BindingFlags = System.Reflection.BindingFlags.Instance
                                            | System.Reflection.BindingFlags.Public
                                            | System.Reflection.BindingFlags.NonPublic;

    private static volatile Dictionary<int, CompiledMethodInfo> _cachedMembers = new();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">
    /// 
    /// </typeparam>
    /// <param name="obj">
    /// assembly / module
    /// </param>
    /// <param name="methodName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static object? Invoke<T>( this T obj, string methodName, params object[] args )
    {
        if( obj == null )
        {
            return null;
        }

        var type = obj.GetType();
        var hash = Hash( type, methodName, args );
        var exists = _cachedMembers.TryGetValue( hash, out var method );
        if( exists )
        {
            return method?.Invoke( obj, args );
        }
        lock( ObjLock )
        {
            //Recheck if exist inside lock in case another thread has added it.
            exists = _cachedMembers.TryGetValue( hash, out method );
            if( exists )
            {
                return method?.Invoke( obj, args );
            }

            var argTypes = args.Select( o => o.GetType() ).ToArray();
            var m = GetMember( type, methodName, argTypes );
            method = m == null ? null : new CompiledMethodInfo( m, type );

            if( method != null )
            {
                var dict = new Dictionary<int, CompiledMethodInfo>( _cachedMembers ) { { hash, method } };

                _cachedMembers = dict;
                return method.Invoke( obj, args );
            }
        }

        return null;
    }

    /// <summary>
    /// 获取接口的实现方法
    /// </summary>
    /// <param name="implementation"></param>
    /// <param name="interface"></param>
    /// <param name="methodName"></param>
    /// <param name="argTypes"></param>
    /// <returns></returns>
    public static string GetImplementationNameOfInterfaceMethod(
        this Type implementation,
        Type @interface,
        string methodName,
        params Type[] argTypes )
    {
        var map = implementation.GetInterfaceMap( @interface );
        var method = map.InterfaceMethods.Single( x =>
                                                      x.Name == methodName && x.GetParameters().Select( p => p.ParameterType ).SequenceEqual( argTypes ) );
        var index = Array.IndexOf( map.InterfaceMethods, method );
        return map.TargetMethods[ index ].Name;
    }

    private static int Hash( Type type, string methodName, object[] args )
    {
        var hash = 23;
        hash = hash * 31 + type.GetHashCode();
        hash = hash * 31 + methodName.GetHashCode();

        return args.Select( t => t.GetType() ).Aggregate( hash, ( current, argType ) => current * 31 + argType.GetHashCode() );
    }

    private static MethodInfo? GetMember( Type type, string name, Type[] argTypes )
    {
        while( true )
        {
            var methods = type.GetMethods( BindingFlags ).Where( m => m.Name == name ).ToArray();
            var member =
                methods.FirstOrDefault( m => m.GetParameters().Select( p => p.ParameterType ).SequenceEqual( argTypes ) ) ??
                methods.FirstOrDefault( m => m.GetParameters().Select( p => p.ParameterType ).ToArray().Matches( argTypes ) );

            if( member != null )
            {
                return member;
            }

            var t = type.GetTypeInfo().BaseType;
            if( t == null )
            {
                return null;
            }

            type = t;
        }
    }
}