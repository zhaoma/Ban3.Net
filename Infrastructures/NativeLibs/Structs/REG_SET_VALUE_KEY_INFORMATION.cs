using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_SET_VALUE_KEY_INFORMATION structure describes a new setting for a registry key's value entry.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_set_value_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_SET_VALUE_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr ValueName;

        /// ULONG->unsigned int
        public uint TitleIndex;

        /// ULONG->unsigned int
        public uint Type;

        /// PVOID->void*
        public System.IntPtr Data;

        /// ULONG->unsigned int
        public uint DataSize;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
