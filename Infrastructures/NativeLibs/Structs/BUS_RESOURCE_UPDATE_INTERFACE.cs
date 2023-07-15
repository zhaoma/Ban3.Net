using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Enables device drivers to make direct calls to parent bus driver routines. 
    /// This structure defines the GUID_BUS_RESOURCE_UPDATE_INTERFACE interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_bus_resource_update_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BUS_RESOURCE_UPDATE_INTERFACE
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The driver-defined interface version.
        /// </summary>
        public uint Version;

        /// <summary>
        /// A pointer to interface-specific context information.
        /// </summary>
        public IntPtr Context;

        /// <summary>
        /// A pointer to an InterfaceReference routine that increments the interface's reference count.
        /// </summary>
        public IntPtr InterfaceReference;

        /// <summary>
        /// A pointer to an InterfaceDereference routine that decrements the interface's reference count.
        /// </summary>
        public IntPtr InterfaceDereference;

        /// <summary>
        /// A pointer to the busdriver-implemented callback function that is invoked to retrieve the pdated resource information.
        /// </summary>
        public IntPtr GetUpdatedBusResource;
    }
}
