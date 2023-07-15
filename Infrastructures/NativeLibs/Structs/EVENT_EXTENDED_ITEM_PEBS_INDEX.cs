using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines a Processor Event Based Sampling (PEBS) index.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_pebs_index
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_PEBS_INDEX
    {
        /// <summary>
        /// The PEBS index.
        /// </summary>
        public ulong PebsIndex;
    }
}