using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POOL_TYPE enumeration type specifies the type of system memory to allocate.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_pool_type
    /// </summary>
    public enum POOL_TYPE
    {
        /// <summary>
        /// Nonpaged pool, which is nonpageable system memory. Nonpaged pool can be accessed from any IRQL, but it is a scarce resource and drivers should allocate it only when necessary.
        /// 
        /// System memory allocated with the NonPagedPool pool type is executable. For more information, see the description of the NonPagedPoolExecute pool type.
        /// 
        /// Starting with Windows 8, drivers should allocate most or all of their nonpaged memory from the no-execute (NX) nonpaged pool instead of the executable nonpaged pool. For more information, see the description of the NonPagedPoolNx pool type.
        /// </summary>
        NonPagedPool,

        /// <summary>
        /// Starting with Windows 8, NonPagedPoolExecute is an alternate name for the NonPagedPool value. 
        /// This value indicates that the allocated memory is to be nonpaged and executable—that is, 
        /// instruction execution is enabled in this memory. 
        /// To port a driver from an earlier version of Windows, 
        /// you should typically replace all or most instances of the NonPagedPool name in the driver source code with NonPagedPoolNx. 
        /// Avoid replacing instances of the NonPagedPool name with NonPagedPoolExecute except in cases in which executable memory is explicitly required. 
        /// For more information, see No-Execute (NX) Nonpaged Pool.
        /// </summary>
        NonPagedPoolExecute = NonPagedPool,

        /// <summary>
        /// Paged pool, which is pageable system memory. Paged pool can only be allocated and accessed at IRQL < DISPATCH_LEVEL.
        /// </summary>
        PagedPool,

        /// <summary>
        /// This value is for internal use only, and is allowed only during system startup. 
        /// Drivers must not specify this value at times other than system startup, 
        /// because a "must succeed" request crashes the system if the requested memory size is unavailable.
        /// </summary>
        NonPagedPoolMustSucceed = NonPagedPool + 2,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        DontUseThisType,

        /// <summary>
        /// Nonpaged pool, aligned on processor cache boundaries.
        /// This value is for internal use only.
        /// </summary>
        NonPagedPoolCacheAligned = NonPagedPool + 4,

        /// <summary>
        /// Paged pool, aligned on processor cache boundaries. 
        /// This value is for internal use only.
        /// </summary>
        PagedPoolCacheAligned,

        /// <summary>
        /// This value is for internal use only, and is allowed only during system startup. 
        /// It is the cache-aligned equivalent of NonPagedPoolMustSucceed.
        /// </summary>
        NonPagedPoolCacheAlignedMustS = NonPagedPool + 6,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        MaxPoolType,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        NonPagedPoolBase = 0,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        NonPagedPoolBaseMustSucceed = NonPagedPoolBase + 2,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        NonPagedPoolBaseCacheAligned = NonPagedPoolBase + 4,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        NonPagedPoolBaseCacheAlignedMustS = NonPagedPoolBase + 6,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        NonPagedPoolSession = 32,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        PagedPoolSession = NonPagedPoolSession + 1,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        NonPagedPoolMustSucceedSession = PagedPoolSession + 1,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        DontUseThisTypeSession = NonPagedPoolMustSucceedSession + 1,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        NonPagedPoolCacheAlignedSession = DontUseThisTypeSession + 1,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        PagedPoolCacheAlignedSession = NonPagedPoolCacheAlignedSession + 1,

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        NonPagedPoolCacheAlignedMustSSession = PagedPoolCacheAlignedSession + 1,

        /// <summary>
        /// No-execute (NX) nonpaged pool. This pool type is available starting with Windows 8. 
        /// In contrast to the nonpaged pool designated by NonPagedPool, which allocates executable memory, 
        /// the NX nonpaged pool allocates memory in which instruction execution is disabled. 
        /// For more information, see No-Execute (NX) Nonpaged Pool.
        /// 
        /// Nonpaged pool can be accessed from any IRQL, but it is a scarce resource and drivers should allocate it only when necessary.
        /// </summary>
        NonPagedPoolNx = 512,

        /// <summary>
        /// NX nonpaged pool, aligned on processor cache boundaries. This value is reserved for exclusive use by the operating system.
        /// </summary>
        NonPagedPoolNxCacheAligned = NonPagedPoolNx + 4,

        /// <summary>
        /// Reserved for exclusive use by the operating system.
        /// </summary>
        NonPagedPoolSessionNx = NonPagedPoolNx + 32,
    }
}
