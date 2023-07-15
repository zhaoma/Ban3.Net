namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Identifies the pointer device cursor types.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_device_cursor_type
    /// </summary>
    public enum POINTER_DEVICE_CURSOR_TYPE:uint
    {

        POINTER_DEVICE_CURSOR_TYPE_UNKNOWN = 0x00000000,
        POINTER_DEVICE_CURSOR_TYPE_TIP = 0x00000001,
        POINTER_DEVICE_CURSOR_TYPE_ERASER = 0x00000002,
        POINTER_DEVICE_CURSOR_TYPE_MAX = 0xFFFFFFFF
    }
}