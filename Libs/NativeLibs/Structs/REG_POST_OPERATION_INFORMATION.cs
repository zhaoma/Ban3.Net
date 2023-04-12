using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The REG_POST_OPERATION_INFORMATION structure contains information about a completed registry operation that a RegistryCallback routine can use.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_post_operation_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_POST_OPERATION_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public NTSTATUS Status;

        /// PVOID->void*
        public System.IntPtr PreInformation;

        /// PVOID->void*
        public NTSTATUS ReturnStatus;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
