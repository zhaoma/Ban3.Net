using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Allows applications to configure a process to terminate if an allocation fails to commit memory.
    /// This structure is used by the PROCESS_INFORMATION_CLASS class.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_memory_exhaustion_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_MEMORY_EXHAUSTION_INFO
    {
        /// <summary>
        /// Version should be set to PME_CURRENT_VERSION.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// Reserved.
        /// </summary>
        public ushort Reserved;

        /// <summary>
        /// Type of failure.
        /// Type should be set to PMETypeFailFastOnCommitFailure (this is the only type available).
        /// </summary>
        public PROCESS_MEMORY_EXHAUSTION_TYPE Type;

        /// <summary>
        /// Used to turn the feature on or off.
        /// </summary>
        public uint Value;
    }
}