namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the collection of supported thread types.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ne-processthreadsapi-thread_information_class
    /// </summary>
    public enum THREAD_INFORMATION_CLASS
    {
        /// <summary>
        /// Lower the memory priority of threads that perform background operations or access files and data
        /// that are not expected to be accessed frequently.
        /// </summary>
        ThreadMemoryPriority,

        /// <summary>
        /// CPU priority.
        /// </summary>
        ThreadAbsoluteCpuPriority,

        /// <summary>
        /// Generate dynamic code or modify executable code.
        /// </summary>
        ThreadDynamicCodePolicy,

        /// <summary>
        /// Throttle the target process activity for power management.
        /// </summary>
        ThreadPowerThrottling,

        ThreadInformationClassMax
    }
}