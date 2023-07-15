using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_SAVE_KEY_INFORMATION structure contains the information for a registry key that is about to be saved.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_save_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_SAVE_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// HANDLE->void*
        public System.IntPtr FileHandle;

        /// ULONG->unsigned int
        public uint Format;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
