using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_COMPONENT_PERF_SET structure represents a set of performance states for a single component within a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_component_perf_set
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_PERF_SET
    {
        /// PVOID->void*
        public System.IntPtr Name;

        /// ULONGLONG->unsigned __int64
        public ulong Flags;

        /// PVOID->void*
        public System.IntPtr Unit;

        /// PVOID->void*
        public System.IntPtr Type;

        /// Anonymous_a0898f18_10a6_4c09_b8b9_e25f4feb3ced
        public PO_FX_COMPONENT_PERF_SET_UNION Union1;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct PO_FX_COMPONENT_PERF_SET_UNION
    {

        /// Anonymous_6bb6e2df_f6e2_4ec4_b1d4_0aa8807d13f5
        [FieldOffset(0)]
        public PO_FX_COMPONENT_PERF_SET_DISCRETE Discrete;

        /// Anonymous_d02836fa_2207_4b26_a747_6208f2f56973
        [FieldOffset(0)]
        public PO_FX_COMPONENT_PERF_SET_RANGE Range;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_PERF_SET_DISCRETE
    {

        /// ULONG->unsigned int
        public uint Count;

        /// PVOID->void*
        public System.IntPtr States;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_PERF_SET_RANGE
    {

        /// ULONGLONG->unsigned __int64
        public ulong Minimum;

        /// ULONGLONG->unsigned __int64
        public ulong Maximum;
    }
}
