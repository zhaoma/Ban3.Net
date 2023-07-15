using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_COMPONENT_PERF_INFO structure describes all the sets of performance states for a single component within a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_component_perf_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_PERF_INFO
    {
        public uint PerfStateSetsCount;
        public IntPtr PerfStateSets;
    }
}
