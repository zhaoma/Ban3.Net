// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 对象比较
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TV">The type of the V.</typeparam>
public class EqualityComparer<T, TV> : IEqualityComparer<T>
{
    private readonly Func<T, TV> _keySelector;
    private readonly IEqualityComparer<TV> _comparer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    public EqualityComparer( Func<T, TV> keySelector, IEqualityComparer<TV> comparer )
    {
        _keySelector = keySelector;
        _comparer = comparer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keySelector"></param>
    public EqualityComparer( Func<T, TV> keySelector )
        : this( keySelector, EqualityComparer<TV>.Default ) {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Equals( T x, T y )
    {
        return _comparer.Equals( _keySelector( x ), _keySelector( y ) );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetHashCode( T obj )
    {
        return _comparer.GetHashCode( _keySelector( obj ) );
    }
}