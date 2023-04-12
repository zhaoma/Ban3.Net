using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_QUERY_VALUE_KEY_INFORMATION structure contains information about a registry key's value entry that is being queried.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_query_value_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_QUERY_VALUE_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr ValueName;

        /// PVOID->void*
        public KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass;

        /// PVOID->void*
        public System.IntPtr KeyValueInformation;

        /// ULONG->unsigned int
        public uint Length;

        /// PULONG->ULONG*
        public System.IntPtr ResultLength;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
