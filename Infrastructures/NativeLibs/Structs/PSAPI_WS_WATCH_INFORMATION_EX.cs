using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains extended information about a page added to a process working set.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-psapi_ws_watch_information_ex
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PSAPI_WS_WATCH_INFORMATION_EX
    {
        /// <summary>
        /// A PSAPI_WS_WATCH_INFORMATION structure.
        /// </summary>
        public PSAPI_WS_WATCH_INFORMATION BasicInfo;

        /// <summary>
        /// The identifier of the thread that caused the page fault.
        /// </summary>
        public uint FaultingThreadId;

        /// <summary>
        /// This member is reserved for future use.
        /// </summary>
        public uint Flags;
    }
}