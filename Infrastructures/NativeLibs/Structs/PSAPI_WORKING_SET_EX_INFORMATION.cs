using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains extended working set information for a process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_working_set_ex_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WORKING_SET_EX_INFORMATION
    {
        /// <summary>
        /// The virtual address.
        /// </summary>
        public IntPtr VirtualAddress;

        /// <summary>
        /// A PSAPI_WORKING_SET_EX_BLOCK union that indicates the attributes of the page at VirtualAddress.
        /// </summary>
        public PSAPI_WORKING_SET_EX_BLOCK VirtualAttributes;
    }
}