using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a page added to a process working set.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_ws_watch_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WS_WATCH_INFORMATION
    {
        /// <summary>
        /// A pointer to the instruction that caused the page fault.
        /// </summary>
        public System.IntPtr FaultingPc;

        /// <summary>
        /// A pointer to the page that was added to the working set.
        /// </summary>
        public System.IntPtr FaultingVa;
    }
}