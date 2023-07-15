using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IO_PAGING_PRIORITY enumeration describes the priority value for a paging I/O IRP.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_paging_priority
    /// </summary>
    public enum IO_PAGING_PRIORITY
    {
        /// <summary>
        /// The IRP is not a paging I/O IRP.
        /// </summary>
        IoPagingPriorityInvalid,

        /// <summary>
        /// The associated IRP has a normal priority level for paging I/O.
        /// </summary>
        IoPagingPriorityNormal,

        /// <summary>
        /// The associated IRP has a high priority level for paging I/O.
        /// </summary>
        IoPagingPriorityHigh,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        IoPagingPriorityReserved1,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        IoPagingPriorityReserved2
    }
}
