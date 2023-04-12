using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DMA_COMPLETION_STATUS enumeration describes the completion status of a DMA transfer.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-dma_completion_status
    /// </summary>
    public enum DMA_COMPLETION_STATUS
    {
        /// <summary>
        /// The DMA transfer completed successfully.
        /// </summary>
        DmaComplete,

        /// <summary>
        /// Not used.
        /// </summary>
        DmaAborted,

        /// <summary>
        /// The DMA transfer did not complete successfully because an error occurred.
        /// </summary>
        DmaError,

        /// <summary>
        /// The DMA transfer did not complete successfully because the client canceled the transfer.
        /// </summary>
        DmaCancelled
    }
}
