﻿namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the visual feedback associated with an event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-feedback_type
    /// </summary>
    public enum FEEDBACK_TYPE : uint
    {

        FEEDBACK_TOUCH_CONTACTVISUALIZATION = 1,
        FEEDBACK_PEN_BARRELVISUALIZATION = 2,
        FEEDBACK_PEN_TAP = 3,
        FEEDBACK_PEN_DOUBLETAP = 4,
        FEEDBACK_PEN_PRESSANDHOLD = 5,
        FEEDBACK_PEN_RIGHTTAP = 6,
        FEEDBACK_TOUCH_TAP = 7,
        FEEDBACK_TOUCH_DOUBLETAP = 8,
        FEEDBACK_TOUCH_PRESSANDHOLD = 9,
        FEEDBACK_TOUCH_RIGHTTAP = 10,
        FEEDBACK_GESTURE_PRESSANDTAP = 11,
        FEEDBACK_MAX = 0xFFFFFFFF
    }
}