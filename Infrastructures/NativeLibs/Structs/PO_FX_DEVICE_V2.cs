using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_DEVICE structure describes the power attributes of a device to the power management framework (PoFx).
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_device_v2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_DEVICE_V2
    {
        /// ULONG->unsigned int
        public uint Version;

        /// ULONGLONG->unsigned __int64
        public ulong Flags;

        /// PVOID->void*
        public System.IntPtr ComponentActiveConditionCallback;

        /// PVOID->void*
        public System.IntPtr ComponentIdleConditionCallback;

        /// PVOID->void*
        public System.IntPtr ComponentIdleStateCallback;

        /// PVOID->void*
        public System.IntPtr DevicePowerRequiredCallback;

        /// PVOID->void*
        public System.IntPtr DevicePowerNotRequiredCallback;

        /// PVOID->void*
        public System.IntPtr PowerControlCallback;

        /// PVOID->void*
        public System.IntPtr DeviceContext;

        /// ULONG->unsigned int
        public uint ComponentCount;

        public PO_FX_COMPONENT_V2[] Components;

    }
}