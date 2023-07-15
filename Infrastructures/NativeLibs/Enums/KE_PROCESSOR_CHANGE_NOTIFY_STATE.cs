using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The state of the processor add operation.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ke_processor_change_notify_context
    /// </summary>
    public enum KE_PROCESSOR_CHANGE_NOTIFY_STATE
    {
        /// <summary>
        /// The operating system is about to add the processor. 
        /// At this state, a device driver that receives this notification can allocate any per-processor data structures and perform any other required tasks to prepare the driver for execution on the new processor.
        /// </summary>
        KeProcessorAddStartNotify,

        /// <summary>
        /// The operating system has successfully added the processor. 
        /// At this state, a device driver that receives this notification can start scheduling threads on the new processor.
        /// </summary>
        KeProcessorAddCompleteNotify,

        /// <summary>
        /// The operating system failed to add the processor. 
        /// If a device driver receives this notification, it should free any per-processor data structures that it allocated for the new processor when it received the KeProcessorAddStartNotify notification.
        /// </summary>
        KeProcessorAddFailureNotify
    }
}
