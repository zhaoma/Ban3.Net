using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_REPLACE_KEY_INFORMATION structure describes the metadata that is about to be replaced for a key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_replace_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_REPLACE_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr OldFileName;

        /// PVOID->void*
        public System.IntPtr NewFileName;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
