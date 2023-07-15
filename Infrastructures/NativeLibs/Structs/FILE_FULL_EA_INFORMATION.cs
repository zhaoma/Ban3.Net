using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_FULL_EA_INFORMATION structure provides extended attribute (EA) information.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_full_ea_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_FULL_EA_INFORMATION
    {
        /// <summary>
        /// The offset of the next FILE_FULL_EA_INFORMATION-type entry. 
        /// This member is zero if no other entries follow this one.
        /// </summary>
        public uint NextEntryOffset;

        /// <summary>
        /// Can be zero or can be set with FILE_NEED_EA, 
        /// indicating that the file to which the EA belongs cannot be interpreted without understanding 
        /// the associated extended attributes.
        /// </summary>
        public byte Flags;

        /// <summary>
        /// The length in bytes of the EaName array. 
        /// This value does not include a null-terminator to EaName.
        /// </summary>
        public byte EaNameLength;

        /// <summary>
        /// The length in bytes of each EA value in the array.
        /// </summary>
        public ushort EaValueLength;

        /// <summary>
        /// An array of characters naming the EA for this entry.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string EaName;
    }
}
