using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_PERF_STATE structure represents a performance state for a single component within a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_perf_state
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_PERF_STATE
    {    
        /// ULONGLONG->unsigned __int64
        public ulong Value;

        /// PVOID->void*
        public System.IntPtr Context;
    }
}
