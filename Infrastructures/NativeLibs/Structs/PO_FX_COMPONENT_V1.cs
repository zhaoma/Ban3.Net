using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_COMPONENT structure describes the power state attributes of a component in a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_component_v1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_V1
    {
        /// GUID->_GUID
        public GUID Id;

        /// ULONG->unsigned int
        public uint IdleStateCount;

        /// ULONG->unsigned int
        public uint DeepestWakeableIdleState;

        /// PVOID->void*
        public System.IntPtr IdleStates;
    }
}
