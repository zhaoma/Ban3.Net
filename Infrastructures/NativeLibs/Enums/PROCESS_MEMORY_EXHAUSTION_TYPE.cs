namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Represents the different memory exhaustion types.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ne-processthreadsapi-process_memory_exhaustion_type
    /// </summary>
    public enum PROCESS_MEMORY_EXHAUSTION_TYPE
    {
        /// <summary>
        /// Anytime memory management fails an allocation due to an inability to commit memory,
        /// it will cause the process to trigger a Windows Error Reporting report and then terminate immediately with STATUS_COMMITMENT_LIMIT. 
        /// </summary>
        PMETypeFailFastOnCommitFailure,

        /// <summary>
        /// The maximum value for this enumeration.
        /// This value may change in a future version.
        /// </summary>
        PMETypeMax
    }
}