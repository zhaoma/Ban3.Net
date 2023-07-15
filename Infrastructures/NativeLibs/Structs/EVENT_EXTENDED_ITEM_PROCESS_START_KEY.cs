using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines a trace flag to get a process start key of a process logging the event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_process_start_key
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_PROCESS_START_KEY
    {
        /// <summary>
        /// The trace flag.
        /// </summary>
        public ulong ProcessStartKey;
    }
}