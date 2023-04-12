using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IOMMU_DMA_RESERVED_REGION structure describes a region of memory that needs to be marked as reserved during domain creation. 
    /// This structure is used by IOMMU_DOMAIN_CREATE_EX.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_dma_reserved_region
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DMA_RESERVED_REGION
    {
        /// <summary>
        /// Provides a pointer to the next reserved region.
        /// </summary>
        public IntPtr RegionNext;

        /// <summary>
        /// Provides the base address of the region to be reserved. Must be page-aligned.
        /// </summary>
        public IntPtr Base;

        /// <summary>
        /// Provides the number of pages to be reserved.
        /// </summary>
        public uint NumberOfPages;

        /// <summary>
        /// Provides whether the reserved region should be identity mapped. 
        /// If not, the region will not be mapped into the domain's page table at all.
        /// </summary>
        public byte ShouldMap;
    }
}
