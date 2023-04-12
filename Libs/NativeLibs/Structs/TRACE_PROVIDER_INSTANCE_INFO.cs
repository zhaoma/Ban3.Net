using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines an instance of the provider GUID.
    /// This data is returned from EnumerateTraceGuidsEx when called with the TraceGuidQueryInfo information class.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_provider_instance_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_PROVIDER_INSTANCE_INFO
    {
        /// <summary>
        /// Offset, in bytes, from the beginning of this structure to the next TRACE_PROVIDER_INSTANCE_INFO structure.
        /// The value is zero if there is not another instance info block.
        /// </summary>
        public uint NextOffset;

        /// <summary>
        /// Number of TRACE_ENABLE_INFO structures in this block.
        /// Each structure represents a session that enabled the provider.
        /// </summary>
        public uint EnableCount;

        /// <summary>
        /// Process identifier of the process that registered the provider.
        /// </summary>
        public uint Pid;

        /// <summary>
        /// Can be one of the following flags.
        /// TRACE_PROVIDER_FLAG_LEGACY:         The provider used RegisterTraceGuids instead of EventRegister to register itself.
        /// TRACE_PROVIDER_FLAG_PRE_ENABLE:     The provider is not registered; however, one or more sessions have enabled the provider.
        /// </summary>
        public uint Flags;
    }
}