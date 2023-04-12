using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_PARTIAL_RESOURCE_LIST structure specifies a set of system hardware resources, of various types, assigned to a device. 
    /// This structure is contained within a CM_FULL_RESOURCE_DESCRIPTOR structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_partial_resource_list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_LIST
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
        /// The number of elements contained in the PartialDescriptors array.
        /// </summary>
        public uint Count;

        /// <summary>
        /// The first element in an array of one or more CM_PARTIAL_RESOURCE_DESCRIPTOR structures.
        /// </summary>
        public CM_PARTIAL_RESOURCE_DESCRIPTOR[] PartialDescriptors;
    }
}
