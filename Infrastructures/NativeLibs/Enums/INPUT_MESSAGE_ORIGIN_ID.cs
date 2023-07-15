namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The ID of the input message source.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-input_message_origin_id
    /// </summary>
    public enum INPUT_MESSAGE_ORIGIN_ID
    {
        IMO_UNAVAILABLE = 0x00000000,
        IMO_HARDWARE = 0x00000001,
        IMO_INJECTED = 0x00000002,
        IMO_SYSTEM = 0x00000004
    }
}