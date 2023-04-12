using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies how the system handles positive leap seconds.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_leap_second_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_LEAP_SECOND_INFO
    {
        /// <summary>
        /// Currently, the only valid flag is PROCESS_LEAP_SECOND_INFO_FLAG_ENABLE_SIXTY_SECOND.
        /// </summary>
        public uint Flags;

        /// <summary>
        /// Reserved for future use
        /// </summary>
        public uint Reserved;
    }
}