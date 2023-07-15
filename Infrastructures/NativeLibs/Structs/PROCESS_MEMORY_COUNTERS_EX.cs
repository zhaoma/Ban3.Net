namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains extended memory statistics for a process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-process_memory_counters_ex
    /// </summary>
    public struct PROCESS_MEMORY_COUNTERS_EX
    {
        /// same as PROCESS_MEMORY_COUNTERS
        public uint cb;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint PageFaultCount;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint PeakWorkingSetSize;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint WorkingSetSize;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint QuotaPeakPagedPoolUsage;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint QuotaPagedPoolUsage;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint QuotaPeakNonPagedPoolUsage;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint QuotaNonPagedPoolUsage;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint PagefileUsage;

        /// same as PROCESS_MEMORY_COUNTERS
        public uint PeakPagefileUsage;

        /// <summary>
        /// Same as PagefileUsage.
        /// The Commit Charge value in bytes for this process.
        /// Commit Charge is the total amount of private memory that the memory manager has committed for a running process.
        /// </summary>
        public uint PrivateUsage;
    }
}