using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_INTERRUPT_MESSAGE_INFO structure describes the driver's message-signaled interrupts.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_interrupt_message_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_INTERRUPT_MESSAGE_INFO
    {    
        /// ULONG->unsigned int
        public uint UnifiedIrql;

        /// ULONG->unsigned int
        public uint MessageCount;

        /// ULONG[1]
        public IO_INTERRUPT_MESSAGE_INFO_ENTRY[] MessageInfo;
    }

    /// <summary>
    /// The IO_INTERRUPT_MESSAGE_INFO_ENTRY structure describes the properties of a single message-signaled interrupt.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_interrupt_message_info_entry
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_INTERRUPT_MESSAGE_INFO_ENTRY
    {
        /// ULONG->unsigned int
        public uint MessageAddress;

        /// ULONG->unsigned int
        public uint TargetProcessorSet;

        /// ULONG->unsigned int
        public uint InterruptObject;

        /// ULONG->unsigned int
        public uint MessageData;

        /// ULONG->unsigned int
        public uint Vector;

        /// ULONG->unsigned int
        public uint Irql;

        /// ULONG->unsigned int
        public uint Mode;

        /// ULONG->unsigned int
        public uint Polarity;
    }
}
