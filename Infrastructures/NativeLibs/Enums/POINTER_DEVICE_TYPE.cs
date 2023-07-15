﻿namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Identifies the pointer device types.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_device_type
    /// </summary>
    public enum POINTER_DEVICE_TYPE:uint
    {

        POINTER_DEVICE_TYPE_INTEGRATED_PEN = 0x00000001,
        POINTER_DEVICE_TYPE_EXTERNAL_PEN = 0x00000002,
        POINTER_DEVICE_TYPE_TOUCH = 0x00000003,
        POINTER_DEVICE_TYPE_TOUCH_PAD = 0x00000004,
        POINTER_DEVICE_TYPE_MAX = 0xFFFFFFFF
    }
}