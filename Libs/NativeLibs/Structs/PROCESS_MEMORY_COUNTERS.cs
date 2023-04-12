using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains the memory statistics for a process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-process_memory_counters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_MEMORY_COUNTERS
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public uint cb;

        /// <summary>
        /// The number of page faults.
        /// </summary>
        public uint PageFaultCount;

        /// <summary>
        /// The peak working set size, in bytes.
        /// </summary>
        public uint PeakWorkingSetSize;

        /// <summary>
        /// The current working set size, in bytes.
        /// </summary>
        public uint WorkingSetSize;

        /// <summary>
        /// The peak paged pool usage, in bytes.
        /// </summary>
        public uint QuotaPeakPagedPoolUsage;

        /// <summary>
        /// The current paged pool usage, in bytes.
        /// </summary>
        public uint QuotaPagedPoolUsage;

        /// <summary>
        /// The peak nonpaged pool usage, in bytes.
        /// </summary>
        public uint QuotaPeakNonPagedPoolUsage;

        /// <summary>
        /// The current nonpaged pool usage, in bytes.
        /// </summary>
        public uint QuotaNonPagedPoolUsage;

        /// <summary>
        /// The Commit Charge value in bytes for this process.
        /// Commit Charge is the total amount of memory that the memory manager has committed for a running process.
        /// </summary>
        public uint PagefileUsage;

        /// <summary>
        /// The peak value in bytes of the Commit Charge during the lifetime of this process.
        /// </summary>
        public uint PeakPagefileUsage;
    }
}