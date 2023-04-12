using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// This enumeration is used in the POOL_EXTENDED_PARAMETER structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-pool_extended_parameter_type
    /// </summary>
    public enum POOL_EXTENDED_PARAMETER_TYPE
    {
        /// <summary>
        /// Invalid extended parameter type. Do not use.
        /// </summary>
        PoolExtendedParameterInvalidType = 0,

        /// <summary>
        /// The extended parameter specifies the priority of the pool allocation using the Priority field of the POOL_EXTENDED_PARAMETER structure.
        /// </summary>
        PoolExtendedParameterPriority,

        /// <summary>
        /// The extended parameter specifies the secure pool parameters of the pool allocation using the SecurePoolParams field of the POOL_EXTENDED_PARAMETER structure.
        /// </summary>
        PoolExtendedParameterSecurePool,

        /// <summary>
        /// The extended parameter specifies the preferred NUMA node of the pool allocation using the PreferredNode field of the POOL_EXTENDED_PARAMETER structure.
        /// </summary>
        PoolExtendedParameterNumaNode,

        /// <summary>
        /// For internal use only.
        /// </summary>
        PoolExtendedParameterMax
    }
}
