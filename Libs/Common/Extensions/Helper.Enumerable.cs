﻿/* —————————————————————————————————————————————————————————————————————————————
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

        /// 
        public static IEnumerable<string> UnionAll(
          this IEnumerable<IEnumerable<string>> source)
        {
            List<string> result = new List<string>();
            source.AsParallel<IEnumerable<string>>().ForAll<IEnumerable<string>>((Action<IEnumerable<string>>)(a => result = result.Union<string>(a).ToList<string>()));
            return (IEnumerable<string>)result;
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
    }
}