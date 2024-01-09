//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 排序
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 桶排序
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="bucketSize">桶大小</param>
    public static T[] BucketSort<T>( T[] array, int bucketSize = 4 )
        where T : IComparable
    {
        ( T max, T min ) = array.FindMaxAndMin();

        var bucketNum = (int)Math.Round( max.ToFloat() - min.ToFloat() ) / bucketSize + 1;
        var buckets = new List<T>[bucketNum];

        foreach( var t in array )
        {
            var bucketIndex = (int)Math.Round( t.ToFloat() - min.ToFloat() ) / bucketSize;
            buckets[ bucketIndex ].Add( t );
        }

        int index = 0;
        foreach( var t in buckets )
        {
            // 对每个桶排序(可以使用其它排序，例如快排)
            t.Sort();
            foreach( var t1 in t )
            {
                array[ index++ ] = t1;
            }
        }

        return array;
    }

    /// 
    public static (T, T) FindMaxAndMin<T>( this T[] array )
        where T : IComparable
    {
        ( T max, T min ) = ( array[ 0 ], array[ 0 ] );
        for( var i = 1; i < array.Length; i++ )
        {
            max = max.CompareTo( array[ i ] ) > 0 ? max : array[ i ];
            min = min.CompareTo( array[ i ] ) > 0 ? array[ i ] : min;
        }

        return ( max, min );
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static T[] BubbleSort<T>( this T[] array )
        where T : IComparable
    {
        var length = array.Length;
        for( int j = 0; j < length - 1; j++ )
        {
            for( int i = length - 1; i > j; i-- )
            {
                if( array[ i - 1 ].CompareTo( array[ i ] ) > 0 )
                {
                    ( array[ i - 1 ], array[ i ] ) = ( array[ i ], array[ i - 1 ] );
                }
            }

            length--;
        }

        return array;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="index"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static T[] ReverseArray<T>( this T[] array, int index = 0, int length = 0 )
    {
        if( length == 0 )
        {
            length = array.Length;
        }

        Array.Reverse( array, index, length );
        return array;
    }
}