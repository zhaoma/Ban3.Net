using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_QUERY_KEY_INFORMATION structure describes the metadata that is about to be queried for a key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_query_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_QUERY_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public KEY_INFORMATION_CLASS KeyInformationClass;

        /// PVOID->void*
        public System.IntPtr KeyInformation;

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
