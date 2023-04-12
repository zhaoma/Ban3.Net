using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Memory Descriptor List
    /// An MDL structure is a partially opaque structure that represents a memory descriptor list (MDL).
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_mdl
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MDL
    {
        /// <summary>
        /// Pointer to the next MDL in an MDL chain.
        /// </summary>
        public System.IntPtr Next;

        /// ULONG->unsigned int
        public uint Size;

        /// ULONG->unsigned int
        public uint MdlFlags;

        /// _EPROCESS*
        public System.IntPtr Process;

        /// PVOID->void*
        public System.IntPtr MappedSystemVa;

        /// PVOID->void*
        public System.IntPtr StartVa;

        /// ULONG->unsigned int
        public uint ByteCount;

        /// ULONG->unsigned int
        public uint ByteOffset;
    }
}
