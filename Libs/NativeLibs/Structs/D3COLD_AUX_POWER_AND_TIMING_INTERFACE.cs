using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// An extended version of the INTERFACE structure that allows device drivers to negotiate a higher auxiliary power 
    /// for their PCI devices while in D3Cold state.
    /// This interface allows device drivers to invoke the functions that manipulate _DSM functions 0Ah, 0Bh.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_d3cold_aux_power_and_timing_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3COLD_AUX_POWER_AND_TIMING_INTERFACE
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// The driver-defined interface version. 
        /// The current version of this interface is D3COLD_AUX_POWER_AND_TIMING_INTERFACE_VERSION.
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
        /// A pointer to a D3COLD_REQUEST_CORE_POWER_RAIL callback function 
        /// that enables the function device object (FDO) to indicate whether the core power rail is needed.
        /// </summary>
        public IntPtr RequestCorePowerRail;

        /// <summary>
        /// A pointer to a _D3COLD_REQUEST_AUX_POWER callback function 
        /// that enables the function device object (FDO) to convey its auxiliary power requirement.
        /// </summary>
        public IntPtr RequestAuxPower;

        /// <summary>
        /// A pointer to a D3COLD_REQUEST_PERST_DELAY enables the function device object (FDO) to convey its requirement for a fixed delay time.
        /// </summary>
        public IntPtr RequestPerstDelay;

    }
}
