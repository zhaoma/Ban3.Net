using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines an extended item stack key on a 64-bit computer.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_stack_key64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_EXTENDED_ITEM_STACK_KEY64
    {
        /// <summary>
        /// A unique identifier that you use to match the kernel-mode calls to the user-mode calls;
        /// the kernel-mode calls and user-mode calls are captured in separate events if the environment prevents
        /// both from being captured in the same event.
        /// If the kernel-mode and user-mode calls were captured in the same event, the value is zero.
        /// </summary>
        public ulong MatchId;

        /// <summary>
        /// The key.
        /// </summary>
        public ulong StackKey;
    }
}