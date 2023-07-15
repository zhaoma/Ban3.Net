using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_VALUE_ENTRY structure is used by the REG_QUERY_MULTIPLE_VALUE_KEY_INFORMATION structure to describe a single value entry for a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_value_entry
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_VALUE_ENTRY
    {
        /// <summary>
        /// Pointer to a UNICODE_STRING structure that contains the name of the value entry.
        /// </summary>
        public System.IntPtr ValueName;

        /// <summary>
        /// Specifies the size, in bytes, of the data for the value entry.
        /// </summary>
        public uint DataLength;

        /// <summary>
        /// Specifies the offset, in bytes, of the value entry's data within the buffer that is pointed to by the ValueBuffer member of REG_QUERY_MULTIPLE_VALUE_KEY_INFORMATION.
        /// </summary>
        public uint DataOffset;

        /// <summary>
        /// Specifies the type of the value entry's data. 
        /// </summary>
        public REG_KEY_TYPE Type;
    }
}
