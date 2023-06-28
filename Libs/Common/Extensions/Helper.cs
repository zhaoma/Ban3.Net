/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（公共）
 * reference:           
 * —————————————————————————————————————————————————————————————————————————————
 */

using log4net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Extensions;

/// 
public static partial class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    static readonly object ObjLock = new();

    static readonly ReaderWriterLockSlim LockSlim = new();

    const int LockSlimTimeout = 1000;

    /// <summary>
    /// not correct
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="action"></param>
    public static async void Delay(this TimeSpan ts, Action action)
    {
        await Task.Run(async () =>
        {
            await Task.Delay(ts);
            action();
        });
    }

    /// <summary>
    /// 随机异步延时
    /// </summary>
    /// <param name="range"></param>
    public static async void RandomDelayAsync(this (int, int) range)
    {
        var seconds = new Random().Next(range.Item1, range.Item2);
        await Task.Delay(seconds);
    }

    /// <summary>
    /// 随机延时
    /// </summary>
    /// <param name="range"></param>
    public static void RandomDelay(this (int, int) range)
    {
        var seconds = new Random().Next(range.Item1, range.Item2);
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }
}