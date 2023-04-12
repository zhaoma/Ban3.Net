using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains working set information for a process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_working_set_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WORKING_SET_INFORMATION
    {
        /// <summary>
        /// The number of entries in the WorkingSetInfo array.
        /// </summary>
        public uint NumberOfEntries;

        /// <summary>
        /// An array of PSAPI_WORKING_SET_BLOCK elements, one for each page in the process working set.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public PSAPI_WORKING_SET_BLOCK[] WorkingSetInfo;
    }
}