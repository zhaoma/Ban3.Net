using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The INTERFACE structure describes an interface that is exported by a driver for use by other drivers.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct INTERFACE
    {
        /// <summary>
        /// Size, in bytes, of a structure defining a driver interface, 
        /// including this structure and interface-specific members.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Driver-defined interface version.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// Pointer to interface-specific context information.
        /// </summary>
        public IntPtr Context;

        /// <summary>
        /// Pointer to a driver-supplied InterfaceReference routine that increments the interface's reference count.
        /// </summary>
        public IntPtr InterfaceReference;

        /// <summary>
        /// Pointer to a driver-supplied InterfaceDereference routine that decrements the interface's reference count.
        /// </summary>
        public IntPtr InterfaceDereference;
    }
}
