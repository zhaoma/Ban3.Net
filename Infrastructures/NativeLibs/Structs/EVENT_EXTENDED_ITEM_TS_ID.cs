using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the terminal session that logged the event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_ts_id
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_TS_ID
    {
        /// <summary>
        /// Identifies the terminal session that logged the event.
        /// </summary>
        public ulong SessionId;
    }
}