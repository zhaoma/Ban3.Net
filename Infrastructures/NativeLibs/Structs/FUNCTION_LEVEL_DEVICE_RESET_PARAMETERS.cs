using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FUNCTION_LEVEL_DEVICE_RESET_PARAMETER structure is 
    /// used as an argument to the DeviceReset routine of the GUID_DEVICE_RESET_INTERFACE_STANDARD interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_function_level_device_reset_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FUNCTION_LEVEL_DEVICE_RESET_PARAMETERS
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public uint Size;

        /// <summary>
        /// Pointer to a completion callback routine to be called when a function-level device reset is completed. 
        /// The callback must enter and exit at the same IRQL.
        /// 
        /// The function prototype for this callback routine is defined as follows:
        /// VOID (*PDEVICE_RESET_COMPLETION)(
        ///     _In_ NTSTATUS Status,
        ///     _Inout_opt_ PVOID Context);
        /// </summary>
        public System.IntPtr DeviceResetCompletion;

        /// <summary>
        /// Points to a caller-supplied context structure to be passed to the DeviceResetCompletion callback.
        /// </summary>
        public System.IntPtr CompletionContext;
    }
}
