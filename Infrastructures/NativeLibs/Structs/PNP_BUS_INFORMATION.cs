using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PNP_BUS_INFORMATION structure describes a bus.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_pnp_bus_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PNP_BUS_INFORMATION
    {    
        /// GUID->_GUID
        public GUID BusTypeGuid;

        /// PVOID->void*
        public INTERFACE_TYPE LegacyBusType;

        /// ULONG->unsigned int
        public uint BusNumber;
    }
}
