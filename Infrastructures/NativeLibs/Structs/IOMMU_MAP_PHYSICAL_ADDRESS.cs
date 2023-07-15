using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IOMMU_MAP_PHYSICAL_ADDRESS represents a physical address that is to be mapped to a logical address. 
    /// It is used by IOMMU_MAP_LOGICAL_RANGE_EX and IOMMU_MAP_IDENTITY_RANGE_EX.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-iommu_map_physical_address
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_MAP_PHYSICAL_ADDRESS
    {
        /// <summary>
        /// A IOMMU_MAP_PHYSICAL_ADDRESS_TYPE value that indicates the format the physical address is represented in.
        /// </summary>
        public IOMMU_MAP_PHYSICAL_ADDRESS_TYPE MapType;

        /// Anonymous_7d12f07c_e1a4_402a_8eca_538fb10d74a6
        public IOMMU_MAP_PHYSICAL_ADDRESS_UNION Union1;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IOMMU_MAP_PHYSICAL_ADDRESS_UNION
    {
        /// <summary>
        /// If MapType == MapPhysicalAddressMdl, provides a MDL that represents the physical address.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_MAP_PHYSICAL_ADDRESS_MDL Mdl;

        /// <summary>
        /// If MapType == MapPhysicalAddressContiguousRange, provides a contiguous physical address.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_MAP_PHYSICAL_ADDRESS_RANGE ContiguousRange;

        /// <summary>
        /// If MapType == MapPhysicalAddressPfn, provides a PFN array.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_MAP_PHYSICAL_ADDRESS_ARRAY PfnArray;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_MAP_PHYSICAL_ADDRESS_MDL
    {
        /// <summary>
        /// The pointer to the MDL that represents the physical address.
        /// </summary>
        public IntPtr Mdl;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_MAP_PHYSICAL_ADDRESS_RANGE
    {
        /// <summary>
        /// The base address of a contiguous physical address.
        /// </summary>
        public PHYSICAL_ADDRESS Base;

        /// <summary>
        /// The size, in bytes, of a contiguous physical address.
        /// </summary>
        public uint Size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_MAP_PHYSICAL_ADDRESS_ARRAY
    {
        /// <summary>
        /// The pointer to the PFN array.
        /// </summary>
        public IntPtr PageFrame;

        /// <summary>
        /// The number of PFNs in the PFN array.
        /// </summary>
        public uint NumberOfPages;
    }
}
