using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_POST_CREATE_KEY_INFORMATION structure contains the result of an attempt to create a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_post_create_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_POST_CREATE_KEY_INFORMATION
    {    
        /// PVOID->void*
        public System.IntPtr CompleteName;

        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public NTSTATUS Status;
    }
}
