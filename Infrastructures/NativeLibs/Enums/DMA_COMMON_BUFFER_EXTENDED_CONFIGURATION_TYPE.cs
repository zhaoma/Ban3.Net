using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Provides the types of optional configurations that can be provided 
    /// when creating a common buffer from an MDL. The configuration values corresponding to 
    /// the types are held in the DMA_COMMON_BUFFER_EXTENDED_CONFIGURATION structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_dma_common_buffer_extended_configuration_type
    /// </summary>
    public enum DMA_COMMON_BUFFER_EXTENDED_CONFIGURATION_TYPE
    {
        /// <summary>
        /// The associated configuration will contain information about the limits of logical address 
        /// that can be used to fulfill common buffer creation.
        /// </summary>
        CommonBufferConfigTypeLogicalAddressLimits,

        /// <summary>
        /// The associated configuration will contain information 
        /// about the subsection within the MDL to use to create the common buffer.
        /// </summary>
        CommonBufferConfigTypeSubSection,

        /// <summary>
        /// The associated configuration will contain information about the access permissions for the hardware.
        /// </summary>
        CommonBufferConfigTypeHardwareAccessPermissions,

        /// <summary>
        /// The number of common buffer extended configuration values for this enumeration type 
        /// that represent actual common buffer configuration types.
        /// </summary>
        CommonBufferConfigTypeMax
    }
}
