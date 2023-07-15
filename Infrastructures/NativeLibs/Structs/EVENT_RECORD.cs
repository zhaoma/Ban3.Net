using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the layout of an event that Event Tracing for Windows (ETW) delivers.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_record
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_RECORD
    {
        /// <summary>
        /// Information about the event such as the time stamp for when it was written.
        /// </summary>
        public EVENT_HEADER EventHeader;

        /// <summary>
        /// Defines information such as the session that logged the event.
        /// </summary>
        public System.IntPtr BufferContext;

        /// <summary>
        /// The number of extended data structures in the ExtendedData member.
        /// </summary>
        public ushort ExtendedDataCount;

        /// <summary>
        /// The size, in bytes, of the data in the UserData member.
        /// </summary>
        public ushort UserDataLength;

        /// <summary>
        /// One or more extended data items that ETW collects.
        /// The extended data includes some items, such as the security identifier (SID) of the user that logged the event,
        /// only if the controller sets the EnableProperty parameter passed to the EnableTraceEx or EnableTraceEx2 function.
        /// The extended data includes other items, such as the related activity identifier and decoding information for trace logging,
        /// regardless whether the controller sets the EnableProperty parameter passed to EnableTraceEx or EnableTraceEx2. 
        /// </summary>
        public System.IntPtr ExtendedData;

        /// <summary>
        /// Event specific data. To parse this data, see Retrieving Event Data Using TDH.
        /// If the Flags member of EVENT_HEADER contains EVENT_HEADER_FLAG_STRING_ONLY,
        /// the data is a null-terminated Unicode string that you do not need TDH to parse.
        /// </summary>
        public System.IntPtr UserData;

        /// <summary>
        /// Th context specified in the Context member of the EVENT_TRACE_LOGFILE structure that is passed to the OpenTrace function.
        /// </summary>
        public System.IntPtr UserContext;

    }
}