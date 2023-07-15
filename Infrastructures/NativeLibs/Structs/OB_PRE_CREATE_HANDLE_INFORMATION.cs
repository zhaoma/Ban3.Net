using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_PRE_CREATE_HANDLE_INFORMATION structure provides information to an ObjectPreCallback routine about a thread or process handle that is being opened.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_pre_create_handle_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_PRE_CREATE_HANDLE_INFORMATION
    {
        public ACCESS_MASK DesiredAccess;

        public ACCESS_MASK OriginalDesiredAccess;
    }
}
