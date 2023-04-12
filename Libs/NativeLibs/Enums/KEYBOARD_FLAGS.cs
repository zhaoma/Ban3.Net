using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    [Flags]
    public enum KEYBOARD_FLAGS:uint
    {
        InsertON = 0x80,
        CapsLockON = 0x40,
        NumLockON = 0x20,
        ScrollLockOn = 0x10,
        AltKeyIsDown = 0x08,
        CtrlKeyIsDown = 0x04,
        LeftShiftKeyIsDown = 0x02,
        RightShiftKeyIsDown = 0x00
    }
}
