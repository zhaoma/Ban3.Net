using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Reserved for system use.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-kernel_soft_restart_notification
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KERNEL_SOFT_RESTART_NOTIFICATION
    {    
        /// USHORT->unsigned short
        public ushort Version;

        /// USHORT->unsigned short
        public ushort Size;

        /// GUID->_GUID
        public GUID Event;
    }
}
