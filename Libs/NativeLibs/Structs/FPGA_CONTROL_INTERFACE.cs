using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Reserved for future use.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_fpga_control_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FPGA_CONTROL_INTERFACE
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// The driver-defined interface version. 
        /// The current version of this interface is FPGA_CONTROL_INTERFACE_VERSION.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// A pointer to interface-specific context information.
        /// </summary>
        public System.IntPtr Context;

        /// <summary>
        /// A pointer to an InterfaceReference routine that increments the interface's reference count.
        /// </summary>
        public System.IntPtr InterfaceReference;

        /// <summary>
        /// A pointer to an InterfaceDereference routine that decrements the interface's reference count.
        /// </summary>
        public System.IntPtr InterfaceDereference;

        /// <summary>
        /// A pointer to a FPGA_BUS_SCAN callback function that triggers a bus scan at the parent of the FPGA device.
        /// </summary>
        public System.IntPtr BusScan;

        /// <summary>
        /// A pointer to a FPGA_CONTROL_LINK callback function that enables or disables the link between the given FPGA device and its parent bridge.
        /// </summary>
        public System.IntPtr ControlLink;

        /// <summary>
        /// A pointer to a FPGA_CONTROL_CONFIG_SPACE callback function that enables or disables the access to the configuration space of the FPGA device.
        /// </summary>
        public System.IntPtr ControlConfigSpace;

        /// <summary>
        /// A pointer to a FPGA_CONTROL_ERROR_REPORTING callback function that toggles the error reporting for the FPGA device and its parent bridge.
        /// </summary>
        public System.IntPtr ControlErrorReporting;
    }
}
