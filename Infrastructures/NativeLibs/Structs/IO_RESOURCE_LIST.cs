using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_RESOURCE_LIST structure describes a range of raw hardware resources, of various types, that can be used by a device. 
    /// The resources specified represent a single, acceptable resource configuration for a device.
    /// An array of IO_RESOURCE_LIST structures is contained within each IO_RESOURCE_REQUIREMENTS_LIST structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_resource_list
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_RESOURCE_LIST
    {
        /// <summary>
        /// The version number of this structure. This value should be 1.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// The revision of this structure. This value should be 1.
        /// </summary>
        public ushort Revision;

        /// <summary>
        /// The number of elements in the Descriptors array.
        /// </summary>
        public uint Count;

        /// <summary>
        /// The first element in an array of one or more IO_RESOURCE_DESCRIPTOR structures.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1)]
        public IO_RESOURCE_DESCRIPTOR[] Descriptors;
    }
}
