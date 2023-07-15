using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines a unique event identifier.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_event_key
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_EVENT_KEY
    {
        /// <summary>
        /// The event key.
        /// </summary>
        public ulong Key;
    }
}