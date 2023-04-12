using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_RESOURCE_LIST structure specifies all of the system hardware resources assigned to a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_resource_list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_RESOURCE_LIST
    {
        /// <summary>
        /// The number of full resource descriptors that are specified by this CM_RESOURCE_LIST structure. 
        /// The List member is the header for the first full resource descriptor. 
        /// For WDM drivers, Count is always 1.
        /// </summary>
        public uint Count;

        /// <summary>
        /// The CM_FULL_RESOURCE_DESCRIPTOR structure that serves as the header for the first full resource descriptor. 
        /// If the CM_RESOURCE_LIST structure contains more than one full resource descriptor, 
        /// the second full resource descriptor immediately follows the first in memory, and so on. 
        /// The size of each full resource descriptor depends on the length of the CM_PARTIAL_RESOURCE_DESCRIPTOR array that it contains.
        /// </summary>
        public CM_FULL_RESOURCE_DESCRIPTOR[] List;
    }
}
