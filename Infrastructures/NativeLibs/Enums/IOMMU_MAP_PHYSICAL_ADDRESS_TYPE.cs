using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IOMMU_MAP_PHYSICAL_ADDRESS_TYPE enum indicates the format of the physical address 
    /// described in an IOMMU_MAP_PHYSICAL_ADDRESS structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-iommu_map_physical_address_type
    /// </summary>
    public enum IOMMU_MAP_PHYSICAL_ADDRESS_TYPE
    {
        /// <summary>
        /// The physical address to be mapped is described by a MDL.
        /// </summary>
        MapPhysicalAddressTypeMdl,

        /// <summary>
        /// The physical address to be mapped is physically contiguous and is described by a base and size.
        /// </summary>
        MapPhysicalAddressTypeContiguousRange,

        /// <summary>
        /// The physical address is described by a PFN array.
        /// </summary>
        MapPhysicalAddressTypePfn,

        /// <summary>
        /// Invalid physical address format.
        /// </summary>
        MapPhysicalAddressTypeMax
    }
}
