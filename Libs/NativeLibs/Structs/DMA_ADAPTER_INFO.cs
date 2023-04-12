using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DMA_ADAPTER_INFO structure is a container for a DMA_ADAPTER_INFO_XXX structure that describes the capabilities of a system DMA controller.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_dma_adapter_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_ADAPTER_INFO
    {
        /// <summary>
        /// The version number of the **DMA_ADAPTER_INFO_**XXX structure that follows this member. 
        /// For a DMA_ADAPTER_INFO_V1 structure, set this member to DMA_ADAPTER_INFO_VERSION1 before calling the GetDmaAdapterInfo routine.
        /// </summary>
        public uint Version;

        /// Anonymous_d9213074_2bb3_460f_a88a_4df8662bbf20
        public DMA_ADAPTER_INFO_UNION Union1;

    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DMA_ADAPTER_INFO_UNION
    {
        /// <summary>
        /// The capabilities of the bus-master DMA device or the system DMA controller. 
        /// </summary>
        [FieldOffset(0)]
        public DMA_ADAPTER_INFO_V1 V1;

        /// <summary>
        /// Defines the DMA_ADAPTER_INFO_CRASHDUMP member Crashdump.
        /// </summary>
        [FieldOffset(0)]
        public DMA_ADAPTER_INFO_CRASHDUMP Crashdump;
    }

    /// <summary>
    /// The DMA_ADAPTER_INFO_V1 structure describes the capabilities of the system DMA controller that is represented by an adapter object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_ADAPTER_INFO_V1
    {
        /// <summary>
        /// Whether the counter value in each DMA channel can be read. 
        /// This member is TRUE if the counter can be read, and is FALSE if it cannot be read.
        /// </summary>
        public uint ReadDmaCounterAvailable;

        /// <summary>
        /// The maximum number of elements in a scatter/gather list that the DMA controller can process in a single scatter/gather DMA transfer.
        /// </summary>
        public uint ScatterGatherLimit;

        /// <summary>
        /// The memory address width, in bits, of the DMA controller. The width is expressed as the number of bits in a DMA address. 
        /// If the DMA address width is less than the memory address width, 
        /// the platform hardware drives the remaining, high-order memory address bits to zero during a DMA transfer.
        /// </summary>
        public uint DmaAddressWidth;

        /// <summary>
        /// A set of flags that describe the capabilities of the DMA adapter. 
        /// No flags are currently defined for this member.
        /// </summary>
        public uint Flags;

        /// <summary>
        /// The size, in bytes, of the minimum transfer unit. 
        /// The number of bytes specified by an element in a scatter/gather list must be an integer multiple of the minimum transfer unit.
        /// </summary>
        public uint MinimumTransferUnit;
    }

    /// <summary>
    /// This topic describes the DMA_ADAPTER_INFO_CRASHDUMP structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_ADAPTER_INFO_CRASHDUMP
    {
        /// <summary>
        /// Defines the DEVICE_DESCRIPTION member DeviceDescription.
        /// </summary>
        public DEVICE_DESCRIPTION DeviceDescription;

        /// <summary>
        /// Defines the SIZE_T member DeviceIdSize.
        /// </summary>
        public uint DeviceIdSize;

        /// <summary>
        /// Defines the PVOID member DeviceId.
        /// </summary>
        public IntPtr DeviceId;

    }
}
