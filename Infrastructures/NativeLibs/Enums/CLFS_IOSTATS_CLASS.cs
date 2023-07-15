using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines types of I/O statistics reported by CLFS and is used when a client calls GetLogIoStatistics. 
    /// Currently, log flush rates are the only type of statistic reported, 
    /// but this enumeration will reflect more types of statistics in the future.
    /// https://learn.microsoft.com/en-us/windows/win32/api/clfs/ne-clfs-clfs_iostats_class
    /// </summary>
    public enum CLFS_IOSTATS_CLASS:uint
    {
        /// <summary>
        /// The default I/O statistics exported.
        /// </summary>
        ClfsIoStatsDefault = 0x0000,

        /// <summary>
        /// The log flush rate.
        /// </summary>
        ClfsIoStatsMax = 0xFFFF
    }
}
