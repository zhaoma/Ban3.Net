//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Timer = System.Timers.Timer;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// Action 相关扩展
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 计时
    /// </summary>
    /// <param name="action"></param>
    /// <param name="message"></param>
    public static void ExecuteAndTiming(
        this Action action,
        string message )
    {
        var sw = new Stopwatch();

        sw.Start();
        action();
        sw.Stop();

        Logger.Debug( $"{message},{sw.ElapsedMilliseconds} ms elapsed." );
    }

    /// <summary>
    /// 用队列并行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="all"></param>
    /// <param name="action"></param>
    /// <param name="taskCount"></param>
    public static void ParallelExecute<T>(
        this IEnumerable<T> all,
        Action<T> action,
        int taskCount )
    {
        var queue = new Queue<T>();
        foreach( var item in all )
        {
            queue.Enqueue( item );
        }

        if( taskCount <= 0 ) taskCount = 32;

        while( queue.Any() )
        {
            var tasks = new List<Task>();

            while( queue.Any() && tasks.Count < taskCount )
            {
                var t = queue.Dequeue();
                tasks.Add( Task.Run( () =>
                {
                    action( t );
                } ) );
            }

            Task.WaitAll( tasks.ToArray() );
        }
    }

    internal static SemaphoreSlim? Semaphore;

    /// <summary>
    /// 用信号量并行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="all"></param>
    /// <param name="action"></param>
    /// <param name="taskCount"></param>
    /// <returns></returns>
    public static async Task ParallelExecuteAsync<T>(
        this IEnumerable<T> all,
        Action<T> action,
        int taskCount )
    {
        if( taskCount <= 0 ) taskCount = 32;

        Semaphore ??= new SemaphoreSlim( taskCount );
        var tasks = new List<Task>();

        foreach( var t in all )
        {
            await Semaphore.WaitAsync();
            tasks.Add( Task.Run( () =>
            {
                try
                {
                    action( t );
                }
                finally
                {
                    Semaphore.Release();
                }
            } ) );
        }

        await Task.WhenAll( tasks );
    }

    private static string? _latestExecutedDate;

    /// <summary>
    /// 给任务创建一个定时时钟
    /// </summary>
    /// <param name="action"></param>
    /// <param name="dailyTime"></param>
    /// <returns></returns>
    public static Timer CreateTimer( this Action action, DateTime dailyTime )
    {
        var timer = new Timer
        {
            AutoReset = true,
            Interval = 1000,
            Enabled = true
        };

        timer.Elapsed += ( _, _ ) =>
        {
            var now = DateTime.Now;

            if( _latestExecutedDate == now.ToYmd() || !now.TimeGe( dailyTime ) ) return;

            try
            {
                timer.Enabled = false;
                _latestExecutedDate = now.ToYmd();
                action.Invoke();
            }
            catch( Exception ex )
            {
                Logger.Error( ex );
            }
            finally
            {
                timer.Enabled = true;
            }
        };
        timer.Start();

        return timer;
    }

    /// <summary>
    /// 给任务创建一个频发时钟
    /// </summary>
    /// <param name="action"></param>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static Timer CreateTimer( this Action action, int interval )
    {
        var timer = new Timer
        {
            AutoReset = true,
            Interval = interval,
            Enabled = true
        };

        timer.Elapsed += ( _, _ ) =>
        {
            try
            {
                timer.Enabled = false;
                action.Invoke();
            }
            catch( Exception ex )
            {
                Logger.Error( ex );
            }
            finally
            {
                timer.Enabled = true;
            }
        };
        timer.Start();

        return timer;
    }

    /// <summary>
    /// 给异步任务创建一个频发时钟
    /// </summary>
    /// <param name="action"></param>
    /// <param name="callbackAction"></param>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static Timer CreateAsyncTimer( this Action action, Action<IAsyncResult> callbackAction, int interval )
    {
        var timer = new Timer
        {
            AutoReset = true,
            Interval = interval,
            Enabled = true
        };

        timer.Elapsed += ( _, _ ) =>
        {
            try
            {
                timer.Enabled = false;
                action.BeginInvoke( new AsyncCallback( callbackAction ), null );
            }
            catch( Exception ex )
            {
                Logger.Error( ex );
            }
        };

        return timer;
    }

    /// <summary>
    /// 并发任务
    /// </summary>
    /// <param name="action"></param>
    /// <param name="count"></param>
    public static void TimesParallel( this Action action, int count )
    {
        Enumerable.Range( 1, count )
                  .AsParallel()
                  .ForAll(
                       _ => action() );
    }

    /// <summary>
    /// 重发任务
    /// </summary>
    /// <param name="action"></param>
    /// <param name="count"></param>
    public static void Times( this Action action, int count )
    {
        Enumerable.Range( 1, count )
                  .ToList()
                  .ForEach(
                       _ => action() );
    }
}