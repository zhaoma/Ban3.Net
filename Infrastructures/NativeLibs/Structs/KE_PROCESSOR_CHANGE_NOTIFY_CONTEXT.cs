using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KE_PROCESSOR_CHANGE_NOTIFY_CONTEXT structure describes the notification context that is passed to a registered callback function 
    /// when a new processor is dynamically added to a hardware partition.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ke_processor_change_notify_context
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KE_PROCESSOR_CHANGE_NOTIFY_CONTEXT
    {
        /// <summary>
        /// The state of the processor add operation. 
        /// </summary>
        public KE_PROCESSOR_CHANGE_NOTIFY_STATE State;

        /// <summary>
        /// The processor index of the new processor.
        /// </summary>
        public uint NtNumber;

        /// <summary>
        /// If the State member contains KeProcessorAddFailureNotify, 
        /// this member contains the error status that indicates why the processor add operation failed.
        /// </summary>
        public NTSTATUS Status;

        /// <summary>
        /// The processor number of the new processor. 
        /// This member is a PROCESSOR_NUMBER structure that specifies a group number and a group-relative processor number.
        /// </summary>
        public PROCESSOR_NUMBER ProcNumber;
    }
}
