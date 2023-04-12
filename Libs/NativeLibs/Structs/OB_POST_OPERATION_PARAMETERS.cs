using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_POST_OPERATION_PARAMETERS union describes the operation-specific parameters for an ObjectPostCallback routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_post_operation_parameters
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct OB_POST_OPERATION_PARAMETERS
    {
        /// <summary>
        /// An OB_POST_CREATE_HANDLE_INFORMATION structure that contains information that is specific to a handle that is being opened.
        /// </summary>
        [FieldOffset(0)]
        public OB_POST_CREATE_HANDLE_INFORMATION CreateHandleInformation;

        /// <summary>
        /// An OB_POST_DUPLICATE_HANDLE_INFORMATION structure that contains information that is specific to a handle that is being duplicated.
        /// </summary>
        [FieldOffset(0)]
        public OB_POST_DUPLICATE_HANDLE_INFORMATION DuplicateHandleInformation;
    }
}
