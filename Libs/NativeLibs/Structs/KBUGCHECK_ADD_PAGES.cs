using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KBUGCHECK_ADD_PAGES structure describes one or more pages of driver-supplied data to be written by a KBUGCHECK_REASON_CALLBACK_ROUTINE callback function to the crash dump file.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_kbugcheck_add_pages
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KBUGCHECK_ADD_PAGES
    {

        /// PVOID->void*
        public System.IntPtr Context;

        /// ULONG->unsigned int
        public uint Flags;

        /// ULONG->unsigned int
        public uint BugCheckCode;

        /// ULONG_PTR->unsigned int
        public uint Address;

        /// ULONG_PTR->unsigned int
        public uint Count;
    }
}
