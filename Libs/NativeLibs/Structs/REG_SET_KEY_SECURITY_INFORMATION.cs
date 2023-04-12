using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_SET_KEY_SECURITY_INFORMATION structure specifies security information for a registry key object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_set_key_security_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_SET_KEY_SECURITY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PSECURITY_INFORMATION->DWORD*
        public System.IntPtr SecurityInformation;

        /// PSECURITY_DESCRIPTOR->PVOID->void*
        public System.IntPtr SecurityDescriptor;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
