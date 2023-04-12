using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines a call stack on a 64-bit computer.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_stack_trace64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_STACK_TRACE64
    {
        /// <summary>
        /// A unique identifier that you use to match the kernel-mode calls to the user-mode calls;
        /// the kernel-mode calls and user-mode calls are captured in separate events if the environment prevents
        /// both from being captured in the same event.
        /// If the kernel-mode and user-mode calls were captured in the same event, the value is zero.
        /// 
        /// Typically, on 32-bit computers, you can always capture both the kernel-mode and user-mode calls in the same event.
        /// However, if you use the frame pointer optimization compiler option, the stack may not be captured, captured incorrectly, or truncated.
        /// </summary>
        public ulong MatchId;

        /// <summary>
        /// An array of call addresses on the stack.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        public ulong[] Address;
    }
}