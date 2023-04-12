using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines the access rights for Scheduled File I/O (SFIO).
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_access_type
    /// </summary>
    public enum IO_ACCESS_TYPE
    {
        /// <summary>
        /// Indicates that the input/output will be comprised solely of reads.
        /// </summary>
        ReadAccess,

        /// <summary>
        /// Indicates that the input/output will be comprised solely of writes.
        /// </summary>
        WriteAccess,

        /// <summary>
        /// Indicates that the input/output will be comprised of reads and writes.
        /// </summary>
        ModifyAccess
    }
}
