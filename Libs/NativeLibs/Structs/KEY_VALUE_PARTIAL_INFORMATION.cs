using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_VALUE_PARTIAL_INFORMATION structure defines a subset of the value information available for a value entry of a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_value_partial_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_VALUE_PARTIAL_INFORMATION
    {
        /// <summary>
        /// Device and intermediate drivers should ignore this member.
        /// </summary>
        public uint TitleIndex;

        /// <summary>
        /// Specifies the system-defined type for the registry value in the Data member.
        /// </summary>
        public REG_KEY_TYPE Type;

        /// <summary>
        /// The size in bytes of the Data member.
        /// </summary>
        public uint DataLength;

        /// <summary>
        /// A value entry of the key.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Data;
    }
}
