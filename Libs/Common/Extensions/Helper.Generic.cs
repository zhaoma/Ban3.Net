/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（泛型）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Linq;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 扩展方法定义（泛型）
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 获取类型名
    /// </summary>
    /// <param name="type">类型</param>
    /// <returns></returns>
    public static string GetGenericTypeName(this Type type)
    {
        string typeName;

        if (type.IsGenericType)
        {
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
            typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    /// <summary>
    /// 获取对象类型名
    /// </summary>
    /// <param name="object">对象</param>
    /// <returns></returns>
    public static string GetGenericTypeName(this object @object)
    {
        return @object.GetType().GetGenericTypeName();
    }

    /// <summary>
    /// Unsafes the cast.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static T? UnsafeCast<T>(this object value)
    {
        return value.IsNull() ? default(T) : (T)value;
    }

    /// <summary>
    /// Safes the cast.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static T? SafeCast<T>(this object value)
    {
        return value is T ? value.UnsafeCast<T>() : default(T);
    }

    /// <summary>
    /// Instances the of.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static bool InstanceOf<T>(this object value)
    {
        return value is T;
    }
}
