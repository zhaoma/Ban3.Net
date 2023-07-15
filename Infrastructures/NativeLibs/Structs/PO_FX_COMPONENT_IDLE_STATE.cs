using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_COMPONENT_IDLE_STATE structure specifies the attributes of an Fx power state of a component in a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_component_idle_state
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_IDLE_STATE
    {
        /// ULONGLONG->unsigned __int64
        public ulong TransitionLatency;

        /// ULONGLONG->unsigned __int64
        public ulong ResidencyRequirement;

        /// ULONG->unsigned int
        public uint NominalPower;
    }
}
