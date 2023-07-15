using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_DEVICE_V3
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
        public System.IntPtr DirectedPowerUpCallback;

        /// PVOID->void*
        public System.IntPtr DirectedPowerDownCallback;

        /// ULONG->unsigned int
        public uint DirectedFxTimeoutInSeconds;

        /// PVOID->void*
        public System.IntPtr DeviceContext;

        /// ULONG->unsigned int
        public uint ComponentCount;

        public PO_FX_COMPONENT_V2[] Components;
    }
}
