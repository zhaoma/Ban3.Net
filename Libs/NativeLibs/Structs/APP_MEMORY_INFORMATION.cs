namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Represents app memory usage at a single point in time.
    /// This structure is used by the PROCESS_INFORMATION_CLASS enumeration.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-app_memory_information
    /// </summary>
    public struct APP_MEMORY_INFORMATION
    {
        /// <summary>
        /// Total commit available to the app.
        /// </summary>
        public ulong AvailableCommit;

        /// <summary>
        /// The app's usage of private commit.
        /// </summary>
        public ulong PrivateCommitUsage;

        /// <summary>
        /// The app's peak usage of private commit.
        /// </summary>
        public ulong PeakPrivateCommitUsage;

        /// <summary>
        /// The app's total usage of private plus shared commit.
        /// </summary>
        public ulong TotalCommitUsage;
    }
}