using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This topic describes the DEVICE_RESET_STATUS_FLAGS union.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-device_reset_status_flags
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DEVICE_RESET_STATUS_FLAGS
    {
        /// <summary>
        /// Defines the u structure.
        /// </summary>
        [FieldOffset(0)]
        public DEVICE_RESET_STATUS_FLAGS_U u;

        /// <summary>
        /// Defines the ULONGLONG member AsUlonglong.
        /// </summary>
        [FieldOffset(0)]
        public ulong AsUlonglong;

    }

    /// <summary>
    /// Defines the u structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_RESET_STATUS_FLAGS_U
    {
        /// <summary>
        /// Defines the ULONGLONG member KeepStackReset.
        /// </summary>
        public ulong KeepStackReset;

        /// <summary>
        /// Defines the ULONGLONG member RecoveringFromBusError.
        /// </summary>
        public ulong RecoveringFromBusError;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public ulong Reserved;
    }
}
