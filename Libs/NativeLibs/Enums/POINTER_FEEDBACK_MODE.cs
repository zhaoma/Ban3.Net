namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Identifies the visual feedback behaviors available to CreateSyntheticPointerDevice.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_feedback_mode
    /// </summary>
    public enum POINTER_FEEDBACK_MODE
    {
        POINTER_FEEDBACK_DEFAULT = 1,
        POINTER_FEEDBACK_INDIRECT = 2,
        POINTER_FEEDBACK_NONE = 3
    }
}