using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_SAVE_MERGED_KEY_INFORMATION structure contains the information about the two registry subtrees for which a merged view is to be saved to a file.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-reg_save_merged_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_SAVE_MERGED_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// HANDLE->void*
        public System.IntPtr FileHandle;

        /// PVOID->void*
        public System.IntPtr HighKeyObject;

        /// PVOID->void*
        public System.IntPtr LowKeyObject;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
