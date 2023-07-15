using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The BOUND_CALLBACK_STATUS enumeration indicates 
    /// how a user-mode bounds exception was processed by the BoundCallback function.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_bound_callback_status
    /// </summary>
    public enum BOUND_CALLBACK_STATUS
    {
        /// <summary>
        /// The bounds exception was not handled by the callback, and the exception should continue to propagate.
        /// </summary>
        BoundExceptionContinueSearch,

        /// <summary>
        /// The exception was handled by the callback, and the exception should not propagate any further.
        /// </summary>
        BoundExceptionHandled,

        /// <summary>
        /// The user mode process should be terminated by the system.
        /// </summary>
        BoundExceptionError,

        /// <summary>
        /// This value is not currently used.
        /// </summary>
        BoundExceptionMaximum,
    }
}
