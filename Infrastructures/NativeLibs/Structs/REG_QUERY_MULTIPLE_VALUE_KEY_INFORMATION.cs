using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_QUERY_MULTIPLE_VALUE_KEY_INFORMATION structure describes the multiple value entries that are being retrieved for a key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_query_multiple_value_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_QUERY_MULTIPLE_VALUE_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr ValueEntries;

        /// ULONG->unsigned int
        public uint EntryCount;

        /// PVOID->void*
        public System.IntPtr ValueBuffer;

        /// PULONG->ULONG*
        public System.IntPtr BufferLength;

        /// PULONG->ULONG*
        public System.IntPtr RequiredBufferLength;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
