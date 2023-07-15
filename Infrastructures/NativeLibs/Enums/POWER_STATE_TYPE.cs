//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:25
//  function:	POWER_STATE_TYPE.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_power_state_type
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.NativeLibs.Enums
{
	public enum POWER_STATE_TYPE
	{
        SystemPowerState,
        DevicePowerState
    }
}

