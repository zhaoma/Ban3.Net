//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:22
//  function:	POWER_SESSION_ALLOW_EXTERNAL_DMA_DEVICES.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-power_session_allow_external_dma_devices
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Reserved for system use.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POWER_SESSION_ALLOW_EXTERNAL_DMA_DEVICES
	{
        public bool IsAllowed;

    }
}

