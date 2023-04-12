using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_POST_DUPLICATE_HANDLE_INFORMATION structure provides information to an ObjectPostCallback routine about a thread or process handle that has been duplicated.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_post_duplicate_handle_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_POST_DUPLICATE_HANDLE_INFORMATION
    {
        /// <summary>
        /// An ACCESS_MASK value that specifies the access that is granted for the handle.
        /// </summary>
        public ACCESS_MASK GrantedAccess;
    }
}
