using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_IO_STATISTICS structure holds I/O statistics data for a Common Log File System (CLFS) log.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cls_io_statistics
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_IO_STATISTICS
    {
        /// <summary>
        /// A CLFS_IO_STATISTICS_HEADER structure that holds header information for the set of statistics.
        /// </summary>
        public CLS_IO_STATISTICS_HEADER hdrIoStats;

        /// <summary>
        /// The number of data flushes.
        /// </summary>
        public ulong cFlush;

        /// <summary>
        /// The number of bytes of data flushed.
        /// </summary>
        public ulong cbFlush;

        /// <summary>
        /// The number of metadata flushes.
        /// </summary>
        public ulong cMetaFlush;

        /// <summary>
        /// The number of bytes of metadata flushed.
        /// </summary>
        public ulong cbMetaFlush;
    }
}
