using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DMA_TRANSFER_INFO structure is a container for a DMA_TRANSFER_INFO_XXX structure that describes the allocation requirements for a scatter/gather list.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_dma_transfer_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_TRANSFER_INFO
    {
        /// <summary>
        /// The version number of the DMA_TRANSFER_INFO_XXX structure that follows this member. 
        /// For a DMA_TRANSFER_INFO_V1 structure, set this member to DMA_TRANSFER_INFO_VERSION1 before calling the GetDmaTransferInfo routine.
        /// </summary>
        public uint Version;

        /// 
        public DMA_TRANSFER_INFO_UNION Union1;
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct DMA_TRANSFER_INFO_UNION
    {
        [FieldOffset(0)]
        public DMA_TRANSFER_INFO_V1 V1;

        [FieldOffset(0)]
        public DMA_TRANSFER_INFO_V2 V2;
    }

    /// <summary>
    /// The allocation requirements for a scatter/gather list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_TRANSFER_INFO_V1
    {
        /// <summary>
        /// The number of map registers required to translate all the physical addresses in the scatter/gather list to logical addresses.
        /// </summary>
        public uint MapRegisterCount;

        /// <summary>
        /// The number of scatter/gather elements in the scatter/gather list. Each element is a structure of type SCATTER_GATHER_ELEMENT.
        /// </summary>
        public uint ScatterGatherElementCount;

        /// <summary>
        /// The required size, in bytes, of the scatter/gather buffer. 
        /// This buffer contains the scatter/gather list that describes the memory that is used to buffer I/O data during the DMA transfer. 
        /// The scatter/gather buffer must be large enough to contain a SCATTER_GATHER_LIST structure and an array of SCATTER_GATHER_ELEMENT structures, 
        /// plus additional data that is used internally by the operating system.
        /// </summary>
        public uint ScatterGatherListSize;
    }

    /// <summary>
    /// The allocation requirements for a scatter/gather list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_TRANSFER_INFO_V2
    {

        /// same as DMA_TRANSFER_INFO_V1
        public uint MapRegisterCount;

        /// same as DMA_TRANSFER_INFO_V1
        public uint ScatterGatherElementCount;

        /// same as DMA_TRANSFER_INFO_V1
        public uint ScatterGatherListSize;

        /// <summary>
        /// The number of logical pages.
        /// </summary>
        public uint LogicalPageCount;
    }

}
