using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PCI_COMMON_CONFIG structure defines standard PCI configuration information returned by the HalGetBusData or HalGetBusDataByOffset routine for the input BusDataType PCIConfiguration, 
    /// assuming the caller-allocated Buffer is of sufficient Length.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_pci_common_config
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_COMMON_CONFIG
    {    
        /// UCHAR[192]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 192)]
        public string DeviceSpecific;
    }
}
