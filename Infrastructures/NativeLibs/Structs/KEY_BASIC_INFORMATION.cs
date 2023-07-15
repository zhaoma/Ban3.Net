using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_BASIC_INFORMATION structure defines a subset of the full information that is available for a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_BASIC_INFORMATION
    {
        /// <summary>
        /// The last time this key or any of its values changed. 
        /// This time value is expressed in absolute system time format. 
        /// Absolute system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
        /// </summary>
        public LARGE_INTEGER LastWriteTime;

        /// <summary>
        /// Device and intermediate drivers should ignore this member.
        /// </summary>
        public uint TitleIndex;

        /// <summary>
        /// The size, in bytes, of the key name string in the Name array.
        /// </summary>
        public uint NameLength;

        /// <summary>
        /// An array of wide characters that contains the name of the registry key.
        /// This character string is not null-terminated. Only the first element in this array is included in the KEY_BASIC_INFORMATION structure definition. 
        /// The storage for the remaining elements in the array immediately follows this element.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Name;
    }
}
