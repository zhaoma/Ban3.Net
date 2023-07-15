using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_FULL_RESOURCE_DESCRIPTOR structure specifies a set of system hardware resources of various types, 
    /// assigned to a device that is connected to a specific bus. 
    /// This structure is contained within a CM_RESOURCE_LIST structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_full_resource_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_FULL_RESOURCE_DESCRIPTOR
    {
        /// <summary>
        /// Specifies the type of bus to which the device is connected. 
        /// This must be one of the types defined by INTERFACE_TYPE, in Wdm.h or Ntddk.h. (Not used by WDM drivers.)
        /// </summary>
        public INTERFACE_TYPE InterfaceType;

        /// <summary>
        /// The system-assigned, driver-supplied, zero-based number of the bus to which the device is connected. (Not used by WDM drivers.)
        /// </summary>
        public uint BusNumber;

        /// <summary>
        /// A CM_PARTIAL_RESOURCE_LIST structure.
        /// </summary>
        public CM_PARTIAL_RESOURCE_LIST PartialResourceList;
    }
}
