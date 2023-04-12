using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_LSN structure identifies an individual record in a Common Log File System (CLFS) stream.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cls_lsn
    /// A container is a contiguous physical disk extent that serves as part of a CLFS log.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_LSN
    {
        /// <summary>
        /// A 64-bit value that holds three pieces of information about a log record: 
        /// container identifier, block offset, and record sequence number.
        /// </summary>
        public ulong Internal;
    }
}
