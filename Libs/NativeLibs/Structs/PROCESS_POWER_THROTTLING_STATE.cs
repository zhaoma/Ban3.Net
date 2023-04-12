using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Specifies the throttling policies and how to apply them to a target process when that process is subject to power management.
    /// This structure is used by the SetProcessInformation function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_power_throttling_state
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_POWER_THROTTLING_STATE
    {
        /// <summary>
        /// The version of the PROCESS_POWER_THROTTLING_STATE structure.
        /// </summary>
        public uint Version;

        /// <summary>
        /// This field enables the caller to take control of the power throttling mechanism.
        /// </summary>
        public uint ControlMask;

        /// <summary>
        /// Manages the power throttling mechanism on/off state.
        /// </summary>
        public uint StateMask;
    }
}