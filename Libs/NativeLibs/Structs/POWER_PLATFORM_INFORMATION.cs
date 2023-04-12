//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:20
//  function:	POWER_PLATFORM_INFORMATION.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_power_platform_information
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The POWER_PLATFORM_INFORMATION structure contains information about the power capabilities of the system.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POWER_PLATFORM_INFORMATION
	{
        public bool AoAc;
	}

}

