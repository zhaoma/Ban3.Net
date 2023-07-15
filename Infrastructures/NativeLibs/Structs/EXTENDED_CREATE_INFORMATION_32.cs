using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes the 32-bit version of the EXTENDED_CREATE_INFORMATION structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-extended_create_information_32
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EXTENDED_CREATE_INFORMATION_32
    {
        /// <summary>
        /// Defines the LONGLONG member ExtendedCreateFlags.
        /// </summary>
        public long ExtendedCreateFlags;

        /// <summary>
        /// Defines the void* POINTER_32 member EaBuffer.
        /// </summary>
        public System.IntPtr EaBuffer;

        /// <summary>
        /// Defines the ULONG member EaLength.
        /// </summary>
        public uint EaLength;

    }
}
