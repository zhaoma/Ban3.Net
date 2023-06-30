/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（集合）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Models;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 列表扩展
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 遍历下级
    /// </summary>
    /// <param name="allNodes"></param>
    /// <param name="specialNodeId"></param>
    /// <returns></returns>
    public static List<RecursionNode> AllChildren(
        this List<RecursionNode> allNodes,
        int specialNodeId)
    {
        var result = new List<RecursionNode>();
        
        var node = allNodes.FindLast(o => o.Id == specialNodeId);

        if (node != null)
            result.Add(node);

        RecursionScan(allNodes, result, specialNodeId);

        return result;
    }

    private static void RecursionScan(
        List<RecursionNode> all,
        List<RecursionNode> result,
        int specialNodeId)
    {
        var temp = all.FindAll(o => o.ParentId == specialNodeId);
        if (!temp.Any()) return;

        foreach (var node in temp)
        {
            result.Add(node);

            RecursionScan(all, result, node.Id);
        }
    }

    /// <summary>
    /// 列表串串(string.Join改写扩展而已)
    /// </summary>
    /// <param name="names"></param>
    /// <param name="seq"></param>
    /// <returns></returns>
    public static string AggregateToString(this IEnumerable<object> names, string seq = " ")
    {
        return string.Join(seq, names);
    }

    /// <summary>
    /// [checked] 查重添加
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="all"></param>
    /// <param name="one"></param>
    public static void AppendDistinct<T>(this List<T> all, T one)
    {
        try
        {
            LockSlim.EnterWriteLock();
            if (!all.Contains(one))
                all.Add(one);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
        finally
        {
            LockSlim.ExitWriteLock();
        }
    }

    /// <summary>
    /// [checked] 查重添加
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="all"></param>
    /// <param name="add">新集合</param>
    public static void AppendDistinct<T>(this List<T> all, IEnumerable<T> add)
    {
        foreach (var v in add)
        {
            all.AppendDistinct(v);
        }
    }

    /// <summary>
    /// [checked] 合并集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">集合列表</param>
    /// <returns></returns>
    public static IEnumerable<T> UnionAll<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        var result = new List<T>();

        return source.Aggregate(result, (current, a) => current.Union(a).ToList());
    }

    /// <summary>
    /// [checked] 集合发现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keys">待查找</param>
    /// <param name="targetKeys">目标集</param>
    /// <returns></returns>
    public static bool AllFoundIn<T>(this IEnumerable<T>? keys, IEnumerable<T> targetKeys)
        => keys != null && !keys.Except(targetKeys).Any();
    
    /// <summary>
    /// 全包含，包括复合条件
    /// </summary>
    /// <param name="keys"></param>
    /// <param name="setKeys"></param>
    /// <returns></returns>
    public static bool AllFoundInComplex(this List<string> keys, List<string> setKeys)
    {
        var result = true;

        keys.ForEach(k =>
        {
            if (k.Contains("|"))
            {
                var ks = k.Split('|');
                var one = ks.Select(s => s.Contains(";")
                        ? s.Split(';').Aggregate(true, (current, s1) => current && setKeys.Contains(s1))
                        : setKeys.Contains(s))
                    .Aggregate(false, (current1, x) => current1 || x);

                result = result && one;
            }
            else
            {
                result = result && setKeys.Contains(k);
            }
        });

        return result;
    }

    /// <summary>
    /// [checked] 集合未发现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keys">待查找</param>
    /// <param name="targetKeys">目标集</param>
    /// <returns></returns>
    public static bool NotFoundIn<T>(this IEnumerable<T>? keys, IEnumerable<T> targetKeys)
        => keys != null && !keys.Intersect(targetKeys).Any();

    /// <summary>
    /// [checked] 集合随机排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="oriList">源集合</param>
    /// <returns></returns>
    public static IEnumerable<T> RandomResortList<T>(this IEnumerable<T> oriList)
    {
        var random = new Random();
        var newList = new List<T>();

        foreach (var item in oriList)
        {
            newList.Insert(random.Next(newList.Count), item);
        }

        return newList;
    }

    /// <summary>
    /// 类型数组一致
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static bool Matches(this Type[] arr, Type[] args)
    {
        if (arr.Length != args.Length) return false;
        return !args.Where((t, i) => !arr[i].IsAssignableFrom(t)).Any();
    }
    
    /// <summary>
    /// [checked] 重新定义数组长度
    /// </summary>
    /// <param name="arr">原数组</param>
    /// <param name="length">新长度</param>
    /// <returns>新长度，从头填充原数组，超出部分截断</returns>
    public static T[] Redim<T>(this T[]? arr, int length)
    {
        var r = new T[length];

        if (arr is { Length: > 0 })
        {
            var len = Math.Min(r.Length, arr.Length);
            Array.Copy(arr, 0, r, 0, len);
        }

        return r;
    }

    /// <summary>
    /// [checked] 集合是否为升序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numbers"></param>
    /// <param name="toDecimal">用来排序的取值函数</param>
    /// <returns></returns>
    public static bool IsAsc<T>(this List<T>? numbers, Func<T, decimal> toDecimal)
    {
        if(numbers is not { Count: > 1 })return true;

        for (var i = 1; i < numbers.Count; i++)
        {
            if (toDecimal(numbers[i - 1]) > toDecimal(numbers[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// [checked] 集合是否为降序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numbers"></param>
    /// <param name="toDecimal">用来排序的取值函数</param>
    /// <returns></returns>
    public static bool IsDesc<T>(this List<T>? numbers, Func<T, decimal> toDecimal)
    {
        if (numbers is not { Count: > 1 }) return true;

        for (var i = 1; i < numbers.Count; i++)
        {
            if (toDecimal(numbers[i ]) > toDecimal(numbers[i-1]))
            {
                return false;
            }
        }

        return true;
    }
}