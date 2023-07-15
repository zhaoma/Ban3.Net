using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the parent event of this event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_related_activityid
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID
    {
        /// <summary>
        /// A GUID that uniquely identifies the parent activity to which this activity is related. The identifier is specified in the RelatedActivityId parameter passed to the EventWriteTransfer function.
        /// </summary>
        public GUID RelatedActivityId;
    }
}