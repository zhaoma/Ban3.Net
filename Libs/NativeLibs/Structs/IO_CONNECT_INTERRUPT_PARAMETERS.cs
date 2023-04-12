using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_CONNECT_INTERRUPT_PARAMETERS structure contains the parameters 
    /// that a driver supplies to the IoConnectInterruptEx routine to register an interrupt service routine (ISR).
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_connect_interrupt_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_CONNECT_INTERRUPT_PARAMETERS
    {    
        /// ULONG->unsigned int
        public uint Version;

        /// Anonymous_92573f6a_799f_4d64_8891_9a75876c06b9
        public IO_CONNECT_INTERRUPT_PARAMETERS_UNION Union1;
    }


    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct IO_CONNECT_INTERRUPT_PARAMETERS_UNION
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint FullySpecified;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint LineBased;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint MessageBased;
    }
}
