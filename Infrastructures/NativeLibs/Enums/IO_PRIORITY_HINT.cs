using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IO_PRIORITY_HINT enumeration type specifies the priority hint for an IRP.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_priority_hint
    /// </summary>
    public enum IO_PRIORITY_HINT
    {
        /// <summary>
        /// Specifies the lowest possible priority hint level. The system uses this value for background I/O operations.
        /// </summary>
        IoPriorityVeryLow,

        /// <summary>
        /// Specifies a low-priority hint level.
        /// </summary>
        IoPriorityLow,

        /// <summary>
        /// Specifies a normal-priority hint level. This value is the default setting for an IRP.
        /// </summary>
        IoPriorityNormal,

        /// <summary>
        /// Specifies a high-priority hint level. This value is reserved for use by the system.
        /// </summary>
        IoPriorityHigh,

        /// <summary>
        /// Specifies the highest-priority hint level. This value is reserved for use by the system.
        /// </summary>
        IoPriorityCritical,

        /// <summary>
        /// Marks the limit for priority hints. Any priority hint value must be less than MaxIoPriorityTypes.
        /// </summary>
        MaxIoPriorityTypes
    }
}
