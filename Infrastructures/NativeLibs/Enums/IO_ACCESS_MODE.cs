using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines the types of access mode for Scheduled File I/O (SFIO).
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_access_mode
    /// </summary>
    public enum IO_ACCESS_MODE
    {
        /// <summary>
        /// Indicates that the input/output will be sent down in a sequential order.
        /// </summary>
        SequentialAccess,

        /// <summary>
        /// Indicates that the input/output might not be in a predictable order.
        /// </summary>
        RandomAccess
    }
}
