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

namespace Ban3.Infrastructures.Common.Extensions
{
    /// 
    public static partial class Helper
    {
        static readonly ILog _logger = LogManager.GetLogger(typeof(Helper));

        static readonly object _objLock = new object();

        static readonly ReaderWriterLockSlim LockSlim = new ReaderWriterLockSlim();

        const int LockSlimTimeout = 1000;

        /// <summary>
        /// not correct
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="action"></param>
        public static void Delay(this TimeSpan ts,Action action)
        {
            Task.Run(async () => { await Task.Delay(ts);action(); });
        }
    }
}