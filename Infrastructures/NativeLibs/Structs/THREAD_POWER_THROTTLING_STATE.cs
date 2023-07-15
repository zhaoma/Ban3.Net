using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies the throttling policies and how to apply them to a target thread when that thread is subject to power management.
    /// This structure is used by the SetThreadInformation function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-thread_power_throttling_state
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct THREAD_POWER_THROTTLING_STATE
    {
        /// ULONG->unsigned int
        public uint Version;

        /// ULONG->unsigned int
        public uint ControlMask;

        /// ULONG->unsigned int
        public uint StateMask;
    }
}