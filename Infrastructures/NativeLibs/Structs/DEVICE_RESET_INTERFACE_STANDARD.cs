using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DEVICE_RESET_INTERFACE_STANDARD structure enables function drivers to reset and recover malfunctioning devices. 
    /// This structure describes the GUID_DEVICE_RESET_INTERFACE_STANDARD interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_device_reset_interface_standard
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_RESET_INTERFACE_STANDARD
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// The driver-defined interface version.
        /// </summary>
        public ushort Version;

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
        /// A pointer to the interface's DeviceReset routine. 
        /// This routine can be used by function drivers to attempt to reset and recover a malfunctioning device.
        /// </summary>
        public IntPtr DeviceReset;

        /// <summary>
        /// Defines the ULONG parameter SupportedResetTypes.
        /// </summary>
        public uint SupportedResetTypes;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public IntPtr Reserved;

        /// <summary>
        /// Defines the PDEVICE_QUERY_BUS_SPECIFIC_RESET_HANDLER parameter QueryBusSpecificResetInfo.
        /// </summary>
        public IntPtr QueryBusSpecificResetInfo;

        /// <summary>
        /// Defines the PDEVICE_BUS_SPECIFIC_RESET_HANDLER parameter DeviceBusSpecificReset.
        /// </summary>
        public IntPtr DeviceBusSpecificReset;

        /// <summary>
        /// Defines the PGET_DEVICE_RESET_STATUS parameter GetDeviceResetStatus.
        /// </summary>
        public IntPtr GetDeviceResetStatus;
    }
}
