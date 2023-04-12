using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_DISCONNECT_INTERRUPT_PARAMETERS structure describes the parameters when unregistering an interrupt-handling routine with IoDisconnectInterruptEx.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_disconnect_interrupt_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_REPORT_INTERRUPT_ACTIVE_STATE_PARAMETERS
    {
        /// ULONG->unsigned int
        public uint Version;

        public IO_REPORT_INTERRUPT_ACTIVE_STATE_PARAMETERS_UNION ConnectionContext;
    }

    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct IO_REPORT_INTERRUPT_ACTIVE_STATE_PARAMETERS_UNION
    {
        /// ULONG->unsigned int
        [FieldOffset(0)]
        public IntPtr Generic;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public IntPtr InterruptObject;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public IntPtr InterruptMessageTable;
    }
}
