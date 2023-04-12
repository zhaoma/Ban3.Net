using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_QUERY_KEY_NAME structure describes the full registry key name of an object being queried.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_query_key_name
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_QUERY_KEY_NAME
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr ObjectNameInfo;

        /// ULONG->unsigned int
        public uint Length;

        /// PULONG->ULONG*
        public System.IntPtr ReturnLength;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;

    }
}
