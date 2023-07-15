using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This topic describes the SET_POWER_SETTING_VALUE structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-set_power_setting_value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SET_POWER_SETTING_VALUE
    {
        /// ULONG->unsigned int
        public uint Version;

        /// GUID->_GUID
        public GUID Guid;

        /// PVOID->void*
        public SYSTEM_POWER_STATE PowerCondition;

        /// ULONG->unsigned int
        public uint DataLength;

        /// UCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Data;

    }
}
