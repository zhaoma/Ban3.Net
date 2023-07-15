using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IOMMU_DMA_LOGICAL_ADDRESS_TOKEN represents a reserved contiguous logical address range created by IOMMU_RESERVE_LOGICAL_ADDRESS_RANGE. 
    /// Logical address tokens guarantee that the logical address represented has all of its associated page tables allocated ahead of time, 
    /// ensuring that future mappings to this region will not fail due to low memory conditions.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_dma_logical_address_token
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DMA_LOGICAL_ADDRESS_TOKEN
    {
        /// <summary>
        /// Represents the base address of the logical address range.
        /// </summary>
        public IOMMU_DMA_LOGICAL_ADDRESS LogicalAddressBase;

        /// <summary>
        /// Represents the size, in bytes, of the logical address range.
        /// </summary>
        public uint Size;
    }
}
