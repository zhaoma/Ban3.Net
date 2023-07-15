using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_PRE_OPEN_KEY_INFORMATION structure contains the name of a registry key that is about to be opened.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_pre_create_key_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_PRE_CREATE_KEY_INFORMATION
    {
        public IntPtr CompleteName;
    }
}
