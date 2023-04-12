//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:24
//  function:	POWER_STATE.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The POWER_STATE union specifies a system power state value or a device power state value.
    /// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct POWER_STATE
	{
        [FieldOffset(0)]
        public SYSTEM_POWER_STATE SystemState;

        [FieldOffset(0)]
        public DEVICE_POWER_STATE DeviceState;
    }
}

