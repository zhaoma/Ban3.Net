using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the DEVICE_BUS_SPECIFIC_RESET_TYPE structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-device_bus_specific_reset_type
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DEVICE_BUS_SPECIFIC_RESET_TYPE
    {
        [FieldOffset(0)]
        public DEVICE_BUS_SPECIFIC_RESET_TYPE_PCI Pci;

        [FieldOffset(0)]
        public DEVICE_BUS_SPECIFIC_RESET_TYPE_ACPI Acpi;

        [FieldOffset(0)]
        public ulong AsULONGLONG;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_BUS_SPECIFIC_RESET_TYPE_PCI
    {
        /*
        ULONGLONG FunctionLevelDeviceReset : 1;
        ULONGLONG PlatformLevelDeviceReset : 1;
        ULONGLONG SecondaryBusReset : 1;
        ULONGLONG Reserved : 61;
         */

        public ulong FunctionLevelDeviceReset;
        public ulong PlatformLevelDeviceReset;
        public ulong SecondaryBusReset;
        public ulong Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_BUS_SPECIFIC_RESET_TYPE_ACPI
    {
        /*
        ULONGLONG FunctionLevelDeviceReset : 1;
        ULONGLONG PlatformLevelDeviceReset : 1;
        ULONGLONG Reserved : 62;
         */

        public ulong FunctionLevelDeviceReset;
        public ulong PlatformLevelDeviceReset;
        public ulong Reserved;
    }
}
