using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies the memory priority for a thread or process.
    /// This structure is used by the GetProcessInformation, SetProcessInformation, GetThreadInformation, and SetThreadInformation functions.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-memory_priority_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_PRIORITY_INFORMATION
    {
        public MEMORY_PRIORITY MemoryPriority;
    }
}