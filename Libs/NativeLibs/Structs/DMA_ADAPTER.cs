using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DMA_ADAPTER structure describes a system-defined interface to a DMA controller for a given device. 
    /// A driver calls IoGetDmaAdapter to obtain this structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_dma_adapter
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMA_ADAPTER
    {
        /// <summary>
        /// Specifies the version of this structure. 
        /// Version 3 of the DMA_ADAPTER structure is available starting with Windows 8. 
        /// For versions 1 and 2 of this structure, this member is set to the value 1.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// Specifies the size, in bytes, of this structure.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Pointer to a DMA_OPERATIONS structure that contains pointers to DMA adapter functions.
        /// The version of the DMA_OPERATIONS structure that this member points to is determined by the version of the DMA_ADAPTER structure.
        /// Thus, for version 1 of the DMA_ADAPTER structure, DmaOperations points to version 1 of the DMA_OPERATIONS structure, and so on. 
        /// </summary>
        public IntPtr DmaOperations;
    }
}
