/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（公共）
 * reference:           
 * —————————————————————————————————————————————————————————————————————————————
 */

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// 
    public static partial class Helper
    {
        public static void ExecuteAndTiming(this Action action, string message)
        {
            var now = DateTime.Now;

            action();

            Console.WriteLine($"{message},{DateTime.Now.Subtract(now).TotalMilliseconds} ms spent.");
        }

        /// <summary>
        /// 并发运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="all"></param>
        /// <param name="action"></param>
        /// <param name="taskCount"></param>
        public static void ParallelExecute<T>(
                this IEnumerable<T> all,
                Action<T> action,
                int taskCount)
        {
            var queue = new Queue<T>();
            foreach (var item in all)
            {
                queue.Enqueue(item);
            }

            while (queue.Any())
            {
                var tasks = new List<Task>();

                while (queue.Any() && tasks.Count < taskCount)
                {
                    var t = queue.Dequeue();
                    tasks.Add(Task.Run(() =>
                    {
                        action(t);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
        }
        
        public static void TimesParallel(this int count, Action action)
        {
            Enumerable.Range(1, count)
                .AsParallel()
                .ForAll(
                 _=>   action());
        }


        public static void Times(this int count, Action action)
        {
            Enumerable.Range(1, count)
                .ToList()
                .ForEach(
                    _ => action());
        }
    }
}