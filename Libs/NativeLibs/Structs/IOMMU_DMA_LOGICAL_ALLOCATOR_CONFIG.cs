using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG structure contains information required to configure a logical allocator.
    /// This structure is used by IOMMU_DOMAIN_CREATE_EX to create a logical allocator attached to the created [IOMMU_DMA_DOMAIN].
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_dma_logical_allocator_config
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG
    {
        /// <summary>
        /// An IOMMU_DMA_LOGICAL_ALLOCATOR_TYPE value that indicates the type of logical allocator to be created.
        /// </summary>
        public uint LogicalAllocatorType;

        /// Anonymous_cdfacc01_8934_419b_92a2_a22c6ed8d52f
        public IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG_UNION Union1;
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG_UNION
    {
        /// <summary>
        /// Provides configuration information specific to the HAL Buddy Allocator.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG_WIDTH BuddyAllocatorConfig;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG_WIDTH
    {
        /// ULONG->unsigned int
        public uint AddressWidth;
    }
}
