using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IOMMU_DMA_LOGICAL_ALLOCATOR_TYPE enum indicates the type of logical allocator 
    /// described in an IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-iommu_dma_logical_allocator_type
    /// </summary>
    public enum IOMMU_DMA_LOGICAL_ALLOCATOR_TYPE
    {
        /// <summary>
        /// The logical allocator configuration does not describe any logical allocator type.
        /// </summary>
        IommuDmaLogicalAllocatorNone,

        /// <summary>
        /// The logical allocator configuration describes the system's Buddy Allocator.
        /// </summary>
        IommuDmaLogicalAllocatorBuddy,

        /// <summary>
        /// Invalid logical allocator type.
        /// </summary>
        IommuDmaLogicalAllocatorMax
    }
}
