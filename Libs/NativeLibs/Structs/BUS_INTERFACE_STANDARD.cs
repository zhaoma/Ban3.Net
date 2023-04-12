using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The BUS_INTERFACE_STANDARD interface structure enables device drivers to make direct calls to parent bus driver routines. 
    /// This structure defines the GUID_BUS_INTERFACE_STANDARD interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_bus_interface_standard
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BUS_INTERFACE_STANDARD
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
        /// A pointer to a TranslateBusAddress routine that translates addresses on the parent bus to logical addresses.
        /// </summary>
        public IntPtr TranslateBusAddress;

        /// <summary>
        /// A pointer to a GetDmaAdapter routine that returns a DMA adapter structure (DMA_ADAPTER) for the target device.
        /// </summary>
        public IntPtr GetDmaAdapter;

        /// <summary>
        /// A pointer to a SetBusData routine that writes data to the device's configuration space.
        /// </summary>
        public IntPtr SetBusData;

        /// <summary>
        /// A pointer to a GetBusData routine that reads data from the device's configuration space.
        /// </summary>
        public IntPtr GetBusData;
    }
}
