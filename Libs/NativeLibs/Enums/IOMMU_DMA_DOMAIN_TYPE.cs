using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Describes the domain types that can be created and interacted with via the DMA_IOMMU_INTERFACE_EX.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-iommu_dma_domain_type
    /// </summary>
    public enum IOMMU_DMA_DOMAIN_TYPE
    {
        /// <summary>
        /// The standard remapping domain. 
        /// The HAL/Hypervisor will create a domain structure and page table for holding logical address mappings.
        /// </summary>
        DomainTypeTranslate,

        /// <summary>
        /// Represents a passthrough domain. Calls to map and unmap are not necessary. 
        /// Depending on the DMAGuard policy of the machine, this domain may not be available.
        /// </summary>
        DomainTypePassThrough,

        /// <summary>
        /// This is a remapping domain in which the page table is owned by the caller. 
        /// The caller is responsible for interacting with the IOMMU Interface 
        /// to provide its page table as well as performing necessary IOMMU TLB flushes.
        /// </summary>
        DomainTypeUnmanaged,

        /// <summary>
        /// Invalid domain type.
        /// </summary>
        DomainTypeMax
    }
}
