/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（可查询列表）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Ban3.Infrastructures.Common.Extensions.Comparers;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 可查询列表扩展方法
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// Wheres if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>( this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition )
        {
            return condition ? source.Where( predicate ) : source;
        }

        /// <summary>
        /// Wheres if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>( this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition )
        {
            return condition ? source.Where( predicate ) : source;
        }

        /// <summary>
        /// Wheres if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>( this IEnumerable<T> source, Func<T, bool> predicate, bool condition )
        {
            return condition ? source.Where( predicate ) : source;
        }

        /// <summary>
        /// Wheres if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>( this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition )
        {
            return condition ? source.Where( predicate ) : source;
        }

        /// <summary>
        /// Determines whether the specified t is between.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="includeLowerBound">if set to <c>true</c> [include lower bound].</param>
        /// <param name="includeUpperBound">if set to <c>true</c> [include upper bound].</param>
        /// <returns>
        ///   <c>true</c> if the specified t is between; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBetween<T>( this T t,
                                         T lowerBound,
                                         T upperBound,
                                         bool includeLowerBound = false,
                                         bool includeUpperBound = false )
                where T : class, IComparable<T>
        {
            if( t == null ) throw new ArgumentNullException( "t" );

            var lowerCompareResult = t.CompareTo( lowerBound );
            var upperCompareResult = t.CompareTo( upperBound );

            return (includeLowerBound && lowerCompareResult == 0) ||
                   (includeUpperBound && upperCompareResult == 0) ||
                   (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        /// <summary>
        /// Determines whether the specified t is between.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="includeLowerBound">if set to <c>true</c> [include lower bound].</param>
        /// <param name="includeUpperBound">if set to <c>true</c> [include upper bound].</param>
        /// <returns>
        ///   <c>true</c> if the specified t is between; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBetween<T>( this T t,
                                         T lowerBound,
                                         T upperBound,
                                         IComparer<T> comparer,
                                         bool includeLowerBound = false,
                                         bool includeUpperBound = false )
        {
            if( comparer == null ) throw new ArgumentNullException( "comparer" );

            var lowerCompareResult = comparer.Compare( t, lowerBound );
            var upperCompareResult = comparer.Compare( t, upperBound );

            return (includeLowerBound && lowerCompareResult == 0) ||
                   (includeUpperBound && upperCompareResult == 0) ||
                   (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        /// <summary>
        /// Distincts the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TV"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T, TV>( this IEnumerable<T> source, Func<T, TV> keySelector )
        {
            return source.Distinct( new CurrentEqualityComparer<T, TV>( keySelector ) );
        }

        /// <summary>
        /// Distincts the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TV">The type of the V.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T, TV>( this IEnumerable<T> source, Func<T, TV> keySelector, IEqualityComparer<TV> comparer )
        {
            return source.Distinct( new CurrentEqualityComparer<T, TV>( keySelector, comparer ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression AndAlso( this Expression left, Expression right )
        {
            return Expression.AndAlso( left, right );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static Expression Call( this Expression instance, string methodName, params Expression[] arguments )
        {
            return Expression.Call( instance, instance.Type.GetMethod( methodName ), arguments );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Expression Property( this Expression expression, string propertyName )
        {
            return Expression.Property( expression, propertyName );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression GreaterThan( this Expression left, Expression right )
        {
            return Expression.GreaterThan( left, right );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDelegate"></typeparam>
        /// <param name="body"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Expression<TDelegate> ToLambda<TDelegate>( this Expression body, params ParameterExpression[] parameters )
        {
            return Expression.Lambda<TDelegate>( body, parameters );
        }

    }
}