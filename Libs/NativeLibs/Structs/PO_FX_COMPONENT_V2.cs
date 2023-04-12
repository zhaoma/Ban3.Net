using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PO_FX_COMPONENT structure describes the power state attributes of a component in a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_po_fx_component_v2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PO_FX_COMPONENT_V2
    {
        /// GUID->_GUID
        public GUID Id;

        /// ULONGLONG->unsigned __int64
        public ulong Flags;

        /// ULONG->unsigned int
        public uint DeepestWakeableIdleState;

        /// ULONG->unsigned int
        public uint IdleStateCount;

        /// PVOID->void*
        public System.IntPtr IdleStates;

        /// ULONG->unsigned int
        public uint ProviderCount;

        /// PULONG->ULONG*
        public System.IntPtr Providers;
    }
}
