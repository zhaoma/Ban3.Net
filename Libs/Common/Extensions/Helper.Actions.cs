/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（公共）
 * reference:           
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Timer = System.Timers.Timer;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// 
    public static partial class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="message"></param>
        public static void ExecuteAndTiming(
            this Action action, 
            string message)
        {
            var now = DateTime.Now;
            action();

            _logger.Info($"{message},{DateTime.Now.Subtract(now).TotalMilliseconds} ms spent.");
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

        //static SemaphoreSlim semaphore;

        public static async Task ParallelExecuteAsync<T>(
            this IEnumerable<T> all,
            Action<T> action,
            int taskCount)
        {
            var semaphore=new SemaphoreSlim(taskCount);
            var tasks = new List<Task>();
            
            foreach (var t in all)
            {
                await semaphore.WaitAsync();
                tasks.Add(Task.Run(() =>
                {
                    try
                    {
                        action(t);
                        Console.WriteLine($"：：{semaphore.CurrentCount}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }

        public static Timer? CreateTimer(this Action action, DateTime dailyTime)
        {
            var timer = new Timer
            {
                AutoReset = true,
                Interval =1000,
                Enabled = true
            };

            timer.Elapsed += (s, e) =>
            {
                try
                {
                    timer.Enabled = false;
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
                finally
                {
                    timer.Enabled = true;
                }
            };
            timer.Start();

            return timer;
        }

        public static Timer? CreateTimer(this Action action, int interval)
        {
            var timer = new Timer
            {
                AutoReset = true,
                Interval = interval,
                Enabled = true
            };

            timer.Elapsed += (s, e) =>
            {
                try
                {
                    timer.Enabled = false;
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
                finally
                {
                    timer.Enabled = true;
                }
            };
            timer.Start();

            return timer;
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