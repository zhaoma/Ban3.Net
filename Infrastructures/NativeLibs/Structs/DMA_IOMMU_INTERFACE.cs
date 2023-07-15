using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// An extended version of the INTERFACE structure that allows device drivers to invoke the callback functions that perform device domain operations.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_dma_iommu_interface
    /// DMA_IOMMU_INTERFACE has been deprecated in Windows 10, version 2103 and has been replaced by DMA_IOMMU_INTERFACE_EX.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_IOMMU_INTERFACE
    {    
        /// ULONG->unsigned int
        public uint Version;

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
}
