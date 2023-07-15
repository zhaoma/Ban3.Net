using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_PRE_DUPLICATE_HANDLE_INFORMATION structure provides information to an ObjectPreCallback routine about a thread or process handle that is being duplicated.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_pre_duplicate_handle_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_PRE_DUPLICATE_HANDLE_INFORMATION
    {
        public ACCESS_MASK DesiredAccess;

        public ACCESS_MASK OriginalDesiredAccess;

        /// <summary>
        /// A pointer to the process object for the process that is the source of the handle.
        /// </summary>
        public IntPtr SourceProcess;

        /// <summary>
        /// A pointer to the process object for the process that receives the duplicated handle.
        /// </summary>
        public IntPtr TargetProcess;
    }
}
