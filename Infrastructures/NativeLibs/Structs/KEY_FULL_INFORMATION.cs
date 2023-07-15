using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_FULL_INFORMATION structure defines the information available for a registry key, including information about its subkeys
    /// and the maximum length for their names and value entries. 
    /// This information can be used to size buffers to get the names of subkeys and their value entries.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_full_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_FULL_INFORMATION
    {
        /// same as KEY_BASIC_INFORMATION
        public LARGE_INTEGER LastWriteTime;

        /// same as KEY_BASIC_INFORMATION
        public uint TitleIndex;

        /// <summary>
        /// The byte offset from the start of this structure to the Class member.
        /// </summary>
        public uint ClassOffset;

        /// <summary>
        /// The size, in bytes, of the key class name string in the Class array.
        /// </summary>
        public uint ClassLength;

        /// <summary>
        /// The number of subkeys for this key.
        /// </summary>
        public uint SubKeys;

        /// <summary>
        /// The maximum size, in bytes, of any name for a subkey.
        /// </summary>
        public uint MaxNameLen;

        /// <summary>
        /// The maximum size, in bytes, of a class name.
        /// </summary>
        public uint MaxClassLen;

        /// <summary>
        /// The number of value entries for this key.
        /// </summary>
        public uint Values;

        /// <summary>
        /// The maximum size, in bytes, of a value entry name.
        /// </summary>
        public uint MaxValueNameLen;

        /// <summary>
        /// The maximum size, in bytes, of a value entry data field.
        /// </summary>
        public uint MaxValueDataLen;

        /// <summary>
        /// An array of wide characters that contains the name of the class of the key.
        /// This character string is not null-terminated. Only the first element in this array is included in the KEY_FULL_INFORMATION structure definition. 
        /// The storage for the remaining elements in the array immediately follows this element.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Class;
    }
}
