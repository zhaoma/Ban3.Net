using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a hardware message sent to the system message queue.
    /// This structure is used to store message information for the JournalPlaybackProc callback function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-eventmsg
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENTMSG
    {
        /// <summary>
        /// The message.
        /// </summary>
        public uint message;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the message value.
        /// </summary>
        public uint paramL;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the message value.
        /// </summary>
        public uint paramH;

        /// <summary>
        /// The time at which the message was posted.
        /// </summary>
        public uint time;

        /// <summary>
        /// A handle to the window to which the message was posted.
        /// </summary>
        public System.IntPtr hwnd;
    }
}