/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（集合）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Models;
using Newtonsoft.Json.Linq;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 列表扩展
    /// </summary>
    public static partial class Helper
    {
        /// 
        public static List<RecursionNode> AllChildren(
	        this IEnumerable<RecursionNode> allNodes, 
	        int specialNodeId)
        {
            var result = new List<RecursionNode>();

            var node = allNodes.ToList().FindLast(o => o.Id == specialNodeId);

            if (node != null)
                result.Add(node);

            RecursionScan(allNodes, result, specialNodeId);

            return result;
        }

        private static void RecursionScan(
	        IEnumerable<RecursionNode> all, 
	        List<RecursionNode> result, 
	        int specialNodeId)
        {
            var temp = all.ToList().FindAll(o => o.ParentId == specialNodeId);
            if (temp != null && temp.Any())
            {
                foreach (var node in temp)
                {
                    result.Add(node);

                    RecursionScan(all, result, node.Id);
                }
            }
        }

        ///
        public static string AggregateToString(this IEnumerable<object> names, string seq = " ")
        {
            return string.Join(seq,names);
        }

        public static void AppendList(this Dictionary<string, List<string>> result, string key, List<string> values)
        {
            if (result.ContainsKey(key))
            {
                result[key] = result[key].Union(values).ToList();
            }
            else
            {
                result.Add(key, values);
            }
        }

        public static void AppendList(this Dictionary<string, List<string>> result, List<string> keys, string value)
        {
            keys.ForEach(key =>
            {
                if (!string.IsNullOrEmpty(key))
                {
                    if (result.ContainsKey(key))
                    {
                        result[key] = result[key].Union(new List<string> { value }).ToList();
                    }
                    else
                    {
                        result.Add(key, new List<string> { value });
                    }
                }
            });
        }

        /// 
        public static IEnumerable<T> UnionAll<T>(
          this IEnumerable<IEnumerable<T>> source)
        {
            var result = new List<T>();
            source
                .AsParallel<IEnumerable<T>>()
                .ForAll<IEnumerable<T>>((Action<IEnumerable<T>>)(a => result = result.Union<T>(a).ToList<T>()));
            return (IEnumerable<T>)result;
        }

        /// 
        public static bool AllFoundIn(this IEnumerable<string> keys, IEnumerable<string[]> filterKeys)
        {
            var targets = filterKeys.UnionAll().ToList();
            return targets.All(o => keys.Contains(o));
        }

        /// 
        public static List<T> RandomResortList<T>(this List<T> oriList)
        {
            Random random = new Random();
            List<T> newList = new List<T>();
            if (oriList != null)
            {
                foreach (T item in oriList)
                {
                    newList.Insert(random.Next(newList.Count), item);
                }
            }

            return newList;
        }

        /// 
        public static bool Matches(this Type[] arr, Type[] args)
        {
            if (arr.Length != args.Length) return false;
            for (var i = 0; i < args.Length; i++)
            {
                if (!arr[i].IsAssignableFrom(args[i]))
                    return false;
            }
            return true;
        }


        public static void AppendToList<T>(this List<T> all, T one)
        {
            try
            {
                LockSlim.EnterWriteLock();
                if (!all.Contains(one))
                    all.Add(one);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                LockSlim.ExitWriteLock();
            }
        }

        /// <summary>
        /// 递归记录hierarchy
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string[] Redim(this string[] arr, int length)
        {
            var r = new string[length];

            Array.Copy(arr, r, length - 1);

            return r;
        }

        public static bool IsAsc(this List<decimal> nums)
        {
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}