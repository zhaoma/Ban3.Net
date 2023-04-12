using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DMA_OPERATIONS structure provides a table of pointers to functions that control the operation of a DMA controller.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_dma_operations
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_OPERATIONS
    {
        /// <summary>
        /// The size, in bytes, of this DMA_OPERATIONS structure.
        /// </summary>
        public uint Size;

        /// <summary>
        /// A pointer to a system-defined routine to free a DMA_ADAPTER structure. 
        /// </summary>
        public IntPtr PutDmaAdapter;

        /// <summary>
        /// A pointer to a system-defined routine to allocate a physically contiguous DMA buffer.
        /// </summary>
        public IntPtr AllocateCommonBuffer;

        /// <summary>
        /// A pointer to a system-defined routine to free a physically contiguous DMA buffer previously allocated by AllocateCommonBuffer.
        /// </summary>
        public IntPtr FreeCommonBuffer;

        /// <summary>
        /// A pointer to a system-defined routine to allocate a channel for DMA operations.
        /// </summary>
        public IntPtr AllocateAdapterChannel;

        /// <summary>
        /// A pointer to a system-defined routine to flush data from the system or bus-master adapter's internal cache after a DMA operation.
        /// </summary>
        public IntPtr FlushAdapterBuffers;

        /// <summary>
        /// A pointer to a system-defined routine to free a channel previously allocated for DMA operations by AllocateAdapterChannel.
        /// </summary>
        public IntPtr FreeAdapterChannel;

        /// <summary>
        /// A pointer to a system-defined routine to free map registers allocated for DMA operations.
        /// </summary>
        public IntPtr FreeMapRegisters;

        /// <summary>
        /// A pointer to a system-defined routine to begin a DMA operation.
        /// </summary>
        public IntPtr MapTransfer;

        /// <summary>
        /// A pointer to a system-defined routine to obtain the DMA alignment requirements of the controller.
        /// </summary>
        public IntPtr GetDmaAlignment;

        /// <summary>
        /// A pointer to a system-defined routine to obtain the current transfer count for a DMA operation.
        /// </summary>
        public IntPtr ReadDmaCounter;

        /// <summary>
        /// A pointer to a system-defined routine that allocates map registers and creates a scatter/gather list for DMA.
        /// </summary>
        public IntPtr GetScatterGatherList;

        /// <summary>
        /// A pointer to a system-defined routine that frees map registers and a scatter/gather list after a DMA operation is complete.
        /// </summary>
        public IntPtr PutScatterGatherList;

        /// <summary>
        /// A pointer to a system-defined routine that determines the buffer size needed to hold the scatter/gather list that describes an I/O data buffer. 
        /// This member is available only in versions 2 and later of DMA_OPERATIONS.
        /// </summary>
        public IntPtr CalculateScatterGatherList;

        /// <summary>
        /// A pointer to a system-defined routine that allocates map registers and creates a scatter/gather list for DMA in a driver-supplied buffer. 
        /// This member is available only in versions 2 and later of DMA_OPERATIONS.
        /// </summary>
        public IntPtr BuildScatterGatherList;

        /// <summary>
        /// A pointer to a system-defined routine that builds an MDL corresponding to a scatter/gather list. 
        /// This member is available only in versions 2 and later of DMA_OPERATIONS.
        /// </summary>
        public IntPtr BuildMdlFromScatterGatherList;

        /// <summary>
        /// A pointer to a system-defined routine that describes the capabilities of a bus-master DMA device or a system DMA controller. 
        /// GetDmaAdapterInfo is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr GetDmaAdapterInfo;

        /// <summary>
        /// A pointer to a system-defined routine that describes the allocation requirements for a scatter/gather list. 
        /// This routine replaces CalculateScatterGatherList. 
        /// GetDmaTransferInfo is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr GetDmaTransferInfo;

        /// <summary>
        /// A pointer to a system-defined routine that initializes an opaque DMA transfer context. 
        /// The operating system stores the internal status of a DMA transfer in this context. 
        /// InitializeDmaTransferContext is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr InitializeDmaTransferContext;

        /// <summary>
        /// A pointer to a system-defined routine that allocates memory for a common buffer 
        /// and maps this memory so that it can accessed both by the processor and by a DMA device. 
        /// AllocateCommonBufferEx is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr AllocateCommonBufferEx;

        /// <summary>
        /// A pointer to a system-defined routine that allocates the resources required for a DMA transfer 
        /// and then calls the driver-supplied AdapterControl routine to initiate the DMA transfer. 
        /// AllocateAdapterChannelEx is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr AllocateAdapterChannelEx;

        /// <summary>
        /// A pointer to a system-defined routine enables a custom function that is implemented by the DMA controller. 
        /// ConfigureAdapterChannel is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr ConfigureAdapterChannel;

        /// <summary>
        /// A pointer to a system-defined routine that tries to cancel a pending request to allocate a DMA channel. 
        /// CancelAdapterChannel is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr CancelAdapterChannel;

        /// <summary>
        /// A pointer to a system-defined routine that sets up map registers to map the physical addresses in a scatter/gather list 
        /// to the logical addresses that are required to do a DMA transfer. 
        /// MapTransferEx is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr MapTransferEx;

        /// <summary>
        /// A pointer to a system-defined routine that allocates resources required for a DMA transfer, 
        /// builds a scatter/gather list, and then calls the driver-supplied AdapterListControl routine to initiate the DMA transfer. 
        /// GetScatterGatherListEx is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr GetScatterGatherListEx;

        /// <summary>
        /// A pointer to a system-defined routine that builds a scatter/gather list in a caller-allocated buffer, 
        /// and then calls the driver-supplied AdapterListControl routine to initiate the DMA transfer. 
        /// BuildScatterGatherListEx is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr BuildScatterGatherListEx;

        /// <summary>
        /// A pointer to a system-defined routine that flushes any data that remains in the system DMA controller's internal cache 
        /// or in a bus-master adapter's internal cache at the end of a DMA transfer. 
        /// For a device that uses a system DMA controller, this routine cancels the current DMA transfer on the controller 
        /// if the transfer is not complete. 
        /// FlushAdapterBuffersEx is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr FlushAdapterBuffersEx;

        /// <summary>
        /// A pointer to a system-defined routine that releases the specified adapter object after a driver has completed all DMA operations. 
        /// FreeAdapterObject is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr FreeAdapterObject;

        /// <summary>
        /// A pointer to a system-defined routine that cancels a mapped transfer. 
        /// CancelMappedTransfer is available only in version 3 of DMA_OPERATIONS.
        /// </summary>
        public IntPtr CancelMappedTransfer;

        /// <summary>
        /// A pointer to a PALLOCATE_DOMAIN_COMMON_BUFFER callback routine to allocate a domain common buffer.
        /// </summary>
        public IntPtr AllocateDomainCommonBuffer;

        /// <summary>
        /// A pointer to a PFLUSH_DMA_BUFFER callback function that flushes any data remaining in the cache.
        /// </summary>
        public IntPtr FlushDmaBuffer;

        /// <summary>
        /// A pointer to a PJOIN_DMA_DOMAIN callback function that joins the specified DMA domain.
        /// </summary>
        public IntPtr JoinDmaDomain;

        /// <summary>
        /// A pointer to a PLEAVE_DMA_DOMAIN callback function that leaves the specified DMA domain.
        /// </summary>
        public IntPtr LeaveDmaDomain;

        /// <summary>
        /// A pointer to the PGET_DMA_DOMAIN callback function that gets a handle to the DMA domain.
        /// </summary>
        public IntPtr GetDmaDomain;

        /// <summary>
        /// A pointer to a PALLOCATE_COMMON_BUFFER_WITH_BOUNDS callback function that allocates the memory for a common buffer 
        /// and maps it so that it can be accessed by a master device and the CPU.
        /// The common buffer can be bound by an optional minimum and maximum logical address. 
        /// This option is available starting in Windows 10, version 1803.
        /// </summary>
        public IntPtr AllocateCommonBufferWithBounds;

        /// 
        public IntPtr AllocateCommonBufferVector;

        /// 
        public IntPtr GetCommonBufferFromVectorByIndex;

        /// 
        public IntPtr FreeCommonBufferFromVector;

        /// 
        public IntPtr FreeCommonBufferVector;

        /// <summary>
        /// A pointer to a PCREATE_COMMON_BUFFER_FROM_MDL callback function that will create a DMA common buffer from an MDL 
        /// and maps the backing memory so that it can be accessed by a bus-mastering device and the CPU. 
        /// This optional callback is available starting in Windows Server 2022.
        /// </summary>
        public IntPtr CreateCommonBufferFromMdl;
    }
}
