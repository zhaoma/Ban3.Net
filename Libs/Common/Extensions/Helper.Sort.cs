/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（排序）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 排序
    /// </summary>
    public static partial class Converter
    {
        /// <summary>
        /// 桶排序
        /// </summary>
        /// <param name="array">数据源</param>
        /// <param name="bucketSize">桶大小</param>
        public static T[] BucketSort<T>( T[] array, int bucketSize = 4 )
                where T : IComparable
        {
            // 获取数组最大值与最小值
            (T max, T min) = array.FindMaxAndMin();

            // 分配的桶数量
            int bucketnum = (int)Math.Round( max.ToFloat() - min.ToFloat() ) / bucketSize + 1;
            var buckets = new List<T>[ bucketnum ];

            // 将数据放在对应的桶里
            for( int i = 0; i < array.Length; i++ )
            {
                // 寻桶位置
                int bucketIndex = (int)Math.Round( array[ i ].ToFloat() - min.ToFloat() ) / bucketSize;
                buckets[ bucketIndex ].Add( array[ i ] );
            }

            int index = 0;
            for( int i = 0; i < buckets.Length; i++ )
            {
                // 对每个桶排序(可以使用其它排序，例如快排)
                buckets[ i ].Sort();
                for( int j = 0; j < buckets[ i ].Count; j++ )
                {
                    array[ index++ ] = buckets[ i ][ j ];
                }
            }

            return array;
        }

        /// 
        public static (T, T) FindMaxAndMin<T>( this T[] array )
                where T : IComparable
        {
            (T max, T min) = (array[ 0 ], array[ 0 ]);
            for( int i = 1; i < array.Length; i++ )
            {
                max = max.CompareTo( array[ i ] ) > 0 ? max : array[ i ];
                min = min.CompareTo( array[ i ] ) > 0 ? array[ i ] : min;
            }

            return (max, min);
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
                        T temp = array[ i - 1 ];
                        array[ i - 1 ] = array[ i ];
                        array[ i ] = temp;
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
                length = array.Length;

            Array.Reverse( array, index, length );
            return array;
        }
    }
}