using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This topic describes the ACPI_INTERFACE_STANDARD2 structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-acpi_interface_standard2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACPI_INTERFACE_STANDARD2
    {
        /// <summary>
        /// Describes the USHORT member Size.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Describes the USHORT member Version.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// Describes the PVOID member Context.
        /// </summary>
        public IntPtr Context;

        /// <summary>
        /// Describes the PINTERFACE_REFERENCE member InterfaceReference.
        /// </summary>
        public IntPtr InterfaceReference;

        /// <summary>
        /// Describes the PINTERFACE_DEREFERENCE member InterfaceDereference.
        /// </summary>
        public IntPtr InterfaceDereference;

        /// <summary>
        /// Describes the PGPE_CONNECT_VECTOR member GpeConnectVector.
        /// </summary>
        public IntPtr GpeConnectVector;

        /// <summary>
        /// Describes the PGPE_DISCONNECT_VECTOR member GpeDisconnectVector.
        /// </summary>
        public IntPtr GpeDisconnectVector;

        /// <summary>
        /// Describes the PGPE_ENABLE_EVENT member GpeEnableEvent.
        /// </summary>
        public IntPtr GpeEnableEvent;

        /// <summary>
        /// Describes the PGPE_DISABLE_EVENT member GpeDisableEvent.
        /// </summary>
        public IntPtr GpeDisableEvent;

        /// <summary>
        /// Describes the PGPE_CLEAR_STATUS member GpeClearStatus.
        /// </summary>
        public IntPtr GpeClearStatus;

        /// <summary>
        /// Describes the PREGISTER_FOR_DEVICE_NOTIFICATIONS member RegisterForDeviceNotifications.
        /// </summary>
        public IntPtr RegisterForDeviceNotifications;

        /// <summary>
        /// Describes the PUNREGISTER_FOR_DEVICE_NOTIFICATIONS member UnregisterForDeviceNotifications.
        /// </summary>
        public IntPtr UnregisterForDeviceNotifications;
    }
}
