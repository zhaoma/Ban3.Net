using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This topic describes the NOTIFY_USER_POWER_SETTING structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-notify_user_power_setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NOTIFY_USER_POWER_SETTING
    {
        /// <summary>
        /// Defines the GUID member Guid.
        /// </summary>
        public GUID Guid;
    }
}
