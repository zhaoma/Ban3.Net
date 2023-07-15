using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The D3COLD_SUPPORT_INTERFACE interface structure contains pointers to the routines in the D3COLD Support Interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_d3cold_support_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3COLD_SUPPORT_INTERFACE
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// The driver-defined interface version. 
        /// The current version of this interface is D3COLD_SUPPORT_INTERFACE_VERSION.
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
        /// A pointer to a SetD3ColdSupport routine that enables or disables transitions to the D3cold device power state.
        /// </summary>
        public IntPtr SetD3ColdSupport;

        /// <summary>
        /// A pointer to a GetIdleWakeInfo routine that the device driver calls 
        /// to discover the device power states from which this device can signal wake events to the processor.
        /// </summary>
        public IntPtr GetIdleWakeInfo;

        /// <summary>
        /// A pointer to a GetD3ColdCapability routine 
        /// that reports whether this device is capable of entering the D3cold device power state.
        /// </summary>
        public IntPtr GetD3ColdCapability;

        /// <summary>
        /// A pointer to a GetBusDriverD3ColdSupport routine 
        /// that reports whether the underlying bus driver and ACPI system firmware support D3cold for this device.
        /// </summary>
        public IntPtr GetBusDriverD3ColdSupport;

        /// <summary>
        /// A pointer to a GetLastTransitionStatus routine 
        /// that reports whether this device's most recent transition to D3hot was followed by a transition to D3cold.
        /// </summary>
        public IntPtr GetLastTransitionStatus;

    }
}
