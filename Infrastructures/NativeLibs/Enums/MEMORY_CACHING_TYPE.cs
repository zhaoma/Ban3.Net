using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The MEMORY_CACHING_TYPE enumeration type specifies the permitted caching behavior 
    /// when allocating or mapping memory.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_memory_caching_type
    /// </summary>
    public enum MEMORY_CACHING_TYPE
    {
        /// <summary>
        /// The requested memory should not be cached by the processor.
        /// </summary>
        MmNonCached,

        /// <summary>
        /// The processor should cache the requested memory.
        /// </summary>
        MmCached,

        /// <summary>
        /// The requested memory should not be cached by the processor, 
        /// but writes to the memory can be combined by the processor.
        /// </summary>
        MmWriteCombined,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        MmHardwareCoherentCached,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        MmNonCachedUnordered,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        MmUSWCCached,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        MmMaximumCacheType,

        ///
        MmNotMapped
    }
}
