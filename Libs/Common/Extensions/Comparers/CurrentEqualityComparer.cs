/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            对象比较
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Extensions.Comparers;

/// <summary>
/// 对象比较
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TV">The type of the V.</typeparam>
public class CurrentEqualityComparer<T, TV> : IEqualityComparer<T>
{
    private readonly Func<T, TV> _keySelector;
    private readonly IEqualityComparer<TV> _comparer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    public CurrentEqualityComparer(Func<T, TV> keySelector, IEqualityComparer<TV> comparer)
    {
        this._keySelector = keySelector;
        this._comparer = comparer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keySelector"></param>
    public CurrentEqualityComparer(Func<T, TV> keySelector)
        : this(keySelector, EqualityComparer<TV>.Default)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Equals(T x, T y)
    {
        return _comparer.Equals(_keySelector(x), _keySelector(y));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetHashCode(T obj)
    {
        return _comparer.GetHashCode(_keySelector(obj));
    }
}