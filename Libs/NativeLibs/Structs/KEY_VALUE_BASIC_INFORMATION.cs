using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_VALUE_BASIC_INFORMATION structure defines a subset of the full information available for a value entry of a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_value_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_VALUE_BASIC_INFORMATION
    {
        /// <summary>
        /// Device and intermediate drivers should ignore this member.
        /// </summary>
        public uint TitleIndex;

        /// <summary>
        /// Specifies the system-defined type for the value entry in the registry key
        /// </summary>
        public REG_KEY_TYPE Type;

        /// <summary>
        /// Specifies the size in bytes of the following value entry name.
        /// </summary>
        public uint NameLength;

        /// <summary>
        /// A string of Unicode characters naming a value entry of the key.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Name;
    }
}
