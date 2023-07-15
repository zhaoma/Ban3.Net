using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_INSTANCE_INFO structure maps a unique transaction identifier to a registered event trace class for TraceEventInstance.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_instance_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_INSTANCE_INFO
    {
        /// HANDLE->void*
        public System.IntPtr RegHandle;

        /// ULONG->unsigned int
        public uint InstanceId;
    }
}