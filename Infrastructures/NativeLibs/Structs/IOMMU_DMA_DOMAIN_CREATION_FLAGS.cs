using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IOMMU_DMA_DOMAIN_CREATION_FLAGS structure defines configuration flags for a domain being created by IOMMU_DOMAIN_CREATE_EX.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_dma_domain_creation_flags
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IOMMU_DMA_DOMAIN_CREATION_FLAGS
    {
        /// <summary>
        /// All flags are currently reserved. This field must be zero.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_DMA_DOMAIN_CREATION_FLAGS_STRUCT u;

        /// <summary>
        /// Represents all flags as a single ULONGLONG.
        /// </summary>
        [FieldOffset(0)]
        public ulong AsUlonglong;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_DMA_DOMAIN_CREATION_FLAGS_STRUCT
    {
        public ulong Reserved;
    }
}
