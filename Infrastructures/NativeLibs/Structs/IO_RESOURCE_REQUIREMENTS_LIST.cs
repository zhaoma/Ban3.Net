using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_RESOURCE_REQUIREMENTS_LIST structure describes sets of resource configurations that can be used by a device. 
    /// Each configuration represents a range of raw resources, of various types, that can be used by a device.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_resource_requirements_list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_REQUIREMENTS_LIST
    {
        /// ULONG->unsigned int
        public uint ListSize;

        /// ULONG->unsigned int
        public INTERFACE_TYPE InterfaceType;

        /// ULONG->unsigned int
        public uint BusNumber;

        /// ULONG->unsigned int
        public uint SlotNumber;

        /// ULONG[3]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] Reserved;

        /// ULONG->unsigned int
        public uint AlternativeLists;

        /// ULONG[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public IO_RESOURCE_LIST[] List;
    }
}
