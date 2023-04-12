using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IOMMU_DMA_LOGICAL_ADDRESS_TOKEN_MAPPED_SEGMENT represents a mapped portion of an IOMMU_DMA_LOGICAL_ADDRESS_TOKEN.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_dma_logical_address_token_mapped_segment
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DMA_LOGICAL_ADDRESS_TOKEN_MAPPED_SEGMENT
    {
        /// <summary>
        /// Provides a pointer to the logical address token that this mapped segment belongs to.
        /// </summary>
        public System.IntPtr OwningToken;

        /// <summary>
        /// The offset, in bytes, into the logical address token of the mapped region.
        /// </summary>
        public uint Offset;

        /// <summary>
        /// The size, in bytes, of the mapped region within the logical address token.
        /// </summary>
        public uint Size;
    }
}
