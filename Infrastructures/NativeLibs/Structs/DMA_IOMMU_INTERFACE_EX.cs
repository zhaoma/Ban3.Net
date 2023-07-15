using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// An interface structure that allows device drivers to interface with the IOMMU functions that perform device domain operations.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-dma_iommu_interface_ex
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_IOMMU_INTERFACE_EX
    {
        /// <summary>
        /// The size (in bytes) of the interface structure.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The interface version number that determines the set of interface functions that are provided by this interface structure.
        /// </summary>
        public uint Version;

        /// Anonymous_d23a8e47_75d3_42c3_9d99_30ec97388fdf
        public DMA_IOMMU_INTERFACE_EX_UNION Union1;

    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DMA_IOMMU_INTERFACE_EX_UNION
    {
        [FieldOffset(0)]
        public DMA_IOMMU_INTERFACE_EX_V1 V1;

        [FieldOffset(0)]
        public DMA_IOMMU_INTERFACE_EX_V2 V2;
    }

    /// <summary>
    /// A DMA_IOMMU_INTERFACE_V1 structure that specifies the set of Version 1 (V1) IOMMU interface functions.
    /// These are the same set of functions as those provided by the deprecated DMA_IOMMU_INTERFACE structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_IOMMU_INTERFACE_EX_V1
    {
        /// PVOID->void*
        public IntPtr CreateDomain;

        /// PVOID->void*
        public IntPtr DeleteDomain;

        /// PVOID->void*
        public IntPtr AttachDevice;

        /// PVOID->void*
        public IntPtr DetachDevice;

        /// PVOID->void*
        public IntPtr FlushDomain;

        /// PVOID->void*
        public IntPtr FlushDomainByVaList;

        /// PVOID->void*
        public IntPtr QueryInputMappings;

        /// PVOID->void*
        public IntPtr MapLogicalRange;

        /// PVOID->void*
        public IntPtr UnmapLogicalRange;

        /// PVOID->void*
        public IntPtr MapIdentityRange;

        /// PVOID->void*
        public IntPtr UnmapIdentityRange;

        /// PVOID->void*
        public IntPtr SetDeviceFaultReporting;

        /// PVOID->void*
        public IntPtr ConfigureDomain;
    }

    /// <summary>
    /// A DMA_IOMMU_INTERFACE_V2 structure that specifies the set of Version 2 (V2) IOMMU interface functions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_IOMMU_INTERFACE_EX_V2
    {

        /// PVOID->void*
        public System.IntPtr CreateDomainEx;

        /// PVOID->void*
        public System.IntPtr DeleteDomain;

        /// PVOID->void*
        public System.IntPtr AttachDeviceEx;

        /// PVOID->void*
        public System.IntPtr DetachDeviceEx;

        /// PVOID->void*
        public System.IntPtr FlushDomain;

        /// PVOID->void*
        public System.IntPtr FlushDomainByVaList;

        /// PVOID->void*
        public System.IntPtr QueryInputMappings;

        /// PVOID->void*
        public System.IntPtr MapLogicalRangeEx;

        /// PVOID->void*
        public System.IntPtr UnmapLogicalRange;

        /// PVOID->void*
        public System.IntPtr MapIdentityRangeEx;

        /// PVOID->void*
        public System.IntPtr UnmapIdentityRangeEx;

        /// PVOID->void*
        public System.IntPtr SetDeviceFaultReportingEx;

        /// PVOID->void*
        public System.IntPtr ConfigureDomain;

        /// PVOID->void*
        public System.IntPtr QueryAvailableDomainTypes;

        /// PVOID->void*
        public System.IntPtr RegisterInterfaceStateChangeCallback;

        /// PVOID->void*
        public System.IntPtr UnregisterInterfaceStateChangeCallback;

        /// PVOID->void*
        public System.IntPtr ReserveLogicalAddressRange;

        /// PVOID->void*
        public System.IntPtr FreeReservedLogicalAddressRange;

        /// PVOID->void*
        public System.IntPtr MapReservedLogicalRange;

        /// PVOID->void*
        public System.IntPtr UnmapReservedLogicalRange;

        /// PVOID->void*
        public System.IntPtr CreateDevice;

        /// PVOID->void*
        public System.IntPtr DeleteDevice;

    }
}
