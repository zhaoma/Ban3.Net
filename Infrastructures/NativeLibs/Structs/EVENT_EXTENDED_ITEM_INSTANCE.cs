using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the relationship between events if TraceEventInstance was used to log related events.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_instance
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_INSTANCE
    {
        /// <summary>
        /// A unique transaction identifier that maps an event to a specific transaction.
        /// </summary>
        public uint InstanceId;

        /// <summary>
        /// A unique transaction identifier of a parent event if you are mapping a hierarchical relationship.
        /// </summary>
        public uint ParentInstanceId;

        /// <summary>
        /// A GUID that uniquely identifies the provider that logged the event referenced by the ParentInstanceId member.
        /// </summary>
        public GUID ParentGuid;

    }
}