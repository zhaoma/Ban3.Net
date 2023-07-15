using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_operation_registration
    /// </summary>
    [Flags]
    public enum OB_OPERATION
    {
        /// <summary>
        /// A new process, thread, or desktop handle was or will be opened.
        /// </summary>
        OB_OPERATION_HANDLE_CREATE,

        /// <summary>
        /// A process, thread, or desktop handle was or will be duplicated.
        /// </summary>
        OB_OPERATION_HANDLE_DUPLICATE
    }
}
