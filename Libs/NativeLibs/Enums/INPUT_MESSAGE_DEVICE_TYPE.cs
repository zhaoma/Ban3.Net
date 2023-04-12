﻿namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The type of device that sent the input message.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-input_message_device_type
    /// </summary>
    public enum INPUT_MESSAGE_DEVICE_TYPE
    {
        IMDT_UNAVAILABLE = 0x00000000,
        IMDT_KEYBOARD = 0x00000001,
        IMDT_MOUSE = 0x00000002,
        IMDT_TOUCH = 0x00000004,
        IMDT_PEN = 0x00000008,
        IMDT_TOUCHPAD = 0x00000010
    }
}