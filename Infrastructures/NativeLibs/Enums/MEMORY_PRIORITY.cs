namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The memory priority for the thread or process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-memory_priority_information
    /// </summary>
    public enum MEMORY_PRIORITY:ulong
    {
        /// <summary>
        /// Very low memory priority. 
        /// </summary>
        MEMORY_PRIORITY_VERY_LOW = 1,

        /// <summary>
        /// Low memory priority. 
        /// </summary>
        MEMORY_PRIORITY_LOW = 2,

        /// <summary>
        /// Medium memory priority. 
        /// </summary>
        MEMORY_PRIORITY_MEDIUM = 3,

        /// <summary>
        /// Below normal memory priority. 
        /// </summary>
        MEMORY_PRIORITY_BELOW_NORMAL = 4,

        /// <summary>
        /// Normal memory priority.
        /// This is the default priority for all threads and processes on the system. 
        /// </summary>
        MEMORY_PRIORITY_NORMAL = 5
    }
}