using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_PRE_OPERATION_PARAMETERS union describes the operation-specific parameters for an ObjectPreCallback routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_pre_operation_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_PRE_OPERATION_PARAMETERS
    {
        /// <summary>
        /// An OB_PRE_CREATE_HANDLE_INFORMATION structure that contains information that is specific to a handle that is being opened.
        /// </summary>
        public OB_PRE_CREATE_HANDLE_INFORMATION CreateHandleInformation;

        /// <summary>
        /// An OB_PRE_DUPLICATE_HANDLE_INFORMATION structure that contains information that is specific to a handle that is being duplicated.
        /// </summary>
        public OB_PRE_DUPLICATE_HANDLE_INFORMATION DuplicateHandleInformation;
    }
}
