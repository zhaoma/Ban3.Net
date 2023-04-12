using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_SET_INFORMATION_KEY_INFORMATION structure describes a new setting for a key's metadata.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_set_information_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_SET_INFORMATION_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr KeySetInformationClass;

        /// PVOID->void*
        public System.IntPtr KeySetInformation;

        /// ULONG->unsigned int
        public uint KeySetInformationLength;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
