﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（对对象异步调用）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 对对象异步调用
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object InvokeMethod( this object obj, string methodName, params object[] parameters )
        {
            return InvokeMethod<object>( obj, methodName, parameters );
        }

        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public static T InvokeMethod<T>( this object obj, string methodName )
        {
            return obj.InvokeMethod<T>(  methodName, null );
        }

        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static T InvokeMethod<T>( this object obj, string methodName, params object[] parameters )
        {
            var type = obj.GetType();
            var method = type.GetMethod( methodName );

            if( method == null ) throw new ArgumentException( string.Format( "Method '{0}' not found.", methodName ), methodName );

            var value = method.Invoke( obj, parameters );
            return (value is T ? (T)value : default(T));
        }

        /// <summary>
        /// 判断是否异步方法
        /// </summary>
        public static bool IsAsyncMethod(this MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }
    }
}