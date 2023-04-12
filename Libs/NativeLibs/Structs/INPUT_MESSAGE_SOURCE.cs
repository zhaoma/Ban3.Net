using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the source of the input message.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input_message_source
    /// </summary>
    public struct INPUT_MESSAGE_SOURCE
    {
        public INPUT_MESSAGE_DEVICE_TYPE deviceType;
        public INPUT_MESSAGE_ORIGIN_ID originId;
    }
}