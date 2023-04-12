using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the priority of a pool memory allocation request.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-ex_pool_priority
    /// </summary>
    public enum EX_POOL_PRIORITY
    {
        /// <summary>
        /// This setting indicates that it is acceptable to the driver for the mapping request to fail 
        /// if the system is low on resources. 
        /// For example, this could be for a non-critical network connection 
        /// where the driver can handle the failure case when system resources are close to being depleted.
        /// </summary>
        LowPoolPriority,
        LowPoolPrioritySpecialPoolOverrun = 8,
        LowPoolPrioritySpecialPoolUnderrun = 9,

        /// <summary>
        /// Indicates that it is acceptable to the driver for the mapping request to fail 
        /// if the system is very low on resources. 
        /// For example, this could be for a non-critical local filesystem request.
        /// </summary>
        NormalPoolPriority = 16,
        NormalPoolPrioritySpecialPoolOverrun = 24,
        NormalPoolPrioritySpecialPoolUnderrun = 25,

        /// <summary>
        /// Should be used when it is unacceptable to the driver for the mapping request to fail 
        /// unless the system is out of resources. 
        /// An example of this would be the paging file path in a driver.
        /// </summary>
        HighPoolPriority = 32,
        HighPoolPrioritySpecialPoolOverrun = 40,
        HighPoolPrioritySpecialPoolUnderrun = 41
    }
}
