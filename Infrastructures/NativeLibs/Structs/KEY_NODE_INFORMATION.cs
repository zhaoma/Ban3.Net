using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_NODE_INFORMATION structure defines the basic information available for a registry (sub)key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_node_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_NODE_INFORMATION
    {
        /// same as KEY_BASIC_INFORMATION
        public LARGE_INTEGER LastWriteTime;

        /// same as KEY_BASIC_INFORMATION
        public uint TitleIndex;

        /// <summary>
        /// The byte offset from the start of this structure to the class name string, 
        /// which is located in the Name array immediately following the key name string. 
        /// Like the key name string, the class name string is not null-terminated.
        /// </summary>
        public uint ClassOffset;

        /// <summary>
        /// The size, in bytes, in the class name string.
        /// </summary>
        public uint ClassLength;

        /// <summary>
        /// The size, in bytes, of the key name string contained in the Name array.
        /// </summary>
        public uint NameLength;

        /// <summary>
        /// An array of wide characters that contains the name of the registry key. 
        /// This character string is not null-terminated. 
        /// Only the first element in this array is included in the KEY_NODE_INFORMATION structure definition. 
        /// The storage for the remaining elements in the array immediately follows this element.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Name;
    }
}
