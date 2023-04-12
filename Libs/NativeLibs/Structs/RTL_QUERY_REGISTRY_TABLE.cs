using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Each table entry contains the address of a caller-supplied QueryRoutine function that will be called for each value name that exists in the registry.
    /// The table must be terminated with a NULL table entry, which is a table entry with a NULL QueryRoutine member and a NULL Name member.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlqueryregistryvalues
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RTL_QUERY_REGISTRY_TABLE
    {
        /// PVOID->void*
        public System.IntPtr QueryRoutine;

        /// ULONG->unsigned int
        public uint Flags;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Name;

        /// PVOID->void*
        public System.IntPtr EntryContext;

        /// ULONG->unsigned int
        public uint DefaultType;

        /// PVOID->void*
        public System.IntPtr DefaultData;

        /// ULONG->unsigned int
        public uint DefaultLength;
    }
}
