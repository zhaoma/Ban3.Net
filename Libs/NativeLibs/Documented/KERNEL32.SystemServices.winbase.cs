//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/9 10:08
//  function:	KERNEL32.SystemServices.winbase.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class KERNEL32
    {
        /*
	
        18 (0x0012),  (0x), AddSecureMemoryCacheCallback, 0x00039100, None
        108 (0x006c),  (0x), BuildCommDCBA, 0x00042ca0, None
        109 (0x006d),  (0x), BuildCommDCBAndTimeoutsA, 0x00042d00, None
        110 (0x006e),  (0x), BuildCommDCBAndTimeoutsW, 0x00042d40, None
        111 (0x006f),  (0x), BuildCommDCBW, 0x00042dd0, None
        112 (0x0070),  (0x), CallNamedPipeA, 0x00061d30, None
        135 (0x0087),  (0x), ClearCommBreak, 0x00025850, None
        136 (0x0088),  (0x), ClearCommError, 0x00025860, None
        152 (0x0098),  (0x), CommConfigDialogA, 0x0003e160, None
        153 (0x0099),  (0x), CommConfigDialogW, 0x0003e210, None
        200 (0x00c8),  (0x), CreateFileMappingA, 0x0001c470, None
	    202 (0x00ca),  (0x), CreateFileMappingNumaA, 0x00063450, None
        216 (0x00d8),  (0x), CreateMailslotA, 0x0001c620, None
        217 (0x00d9),  (0x), CreateMailslotW, 0x0001c690, None
        358 (0x0166),  (0x), EscapeCommFunction, 0x00025870, None
        474 (0x01da),  (0x), GetCommConfig, 0x00025880, None
        475 (0x01db),  (0x), GetCommMask, 0x00025890, None
        476 (0x01dc),  (0x), GetCommModemStatus, 0x000258a0, None
        477 (0x01dd),  (0x), GetCommProperties, 0x000258b0, None
        478 (0x01de),  (0x), GetCommState, 0x000258c0, None
        479 (0x01df),  (0x), GetCommTimeouts, 0x000258d0, None
        558 (0x022e),  (0x), GetDefaultCommConfigA, 0x0003e470, None
        559 (0x022f),  (0x), GetDefaultCommConfigW, 0x0003e520, None
        560 (0x0230),  (0x), GetDevicePowerState, 0x000679b0, None
        567 (0x0237),  (0x), GetDllDirectoryA, 0x00039460, None
        568 (0x0238),  (0x), GetDllDirectoryW, 0x00022640, None
        633 (0x0279),  (0x), GetMailslotInfo, 0x00063600, None
        646 (0x0286),  (0x), GetNamedPipeClientComputerNameA, 0x00061e80, None
        648 (0x0288),  (0x), GetNamedPipeClientProcessId, 0x00061fd0, None
        649 (0x0289),  (0x), GetNamedPipeClientSessionId, 0x000396e0, None
        650 (0x028a),  (0x), GetNamedPipeHandleStateA, 0x00062010, None
        653 (0x028d),  (0x), GetNamedPipeServerProcessId, 0x000621a0, None
        654 (0x028e),  (0x), GetNamedPipeServerSessionId, 0x00039740, None
        699 (0x02bb),  (0x), GetProcessDEPPolicy, 0x0003a6a0, None
        741 (0x02e5),  (0x), GetSystemDEPPolicy, 0x0003a6f0, None
        751 (0x02ef),  (0x), GetSystemPowerStatus, 0x00018390, None
        826 (0x033a),  (0x), GlobalAlloc, 0x000185e0, None
        832 (0x0340),  (0x), GlobalFlags, 0x000201d0, None
        833 (0x0341),  (0x), GlobalFree, 0x00016130, None
        836 (0x0344),  (0x), GlobalHandle, 0x000208b0, None
        837 (0x0345),  (0x), GlobalLock, 0x00015f70, None
        838 (0x0346),  (0x), GlobalMemoryStatus, 0x0001d0c0, None
        840 (0x0348),  (0x), GlobalReAlloc, 0x00017190, None
        841 (0x0349),  (0x), GlobalSize, 0x00018600, None
        844 (0x034c),  (0x), GlobalUnlock, 0x00015e90, None
        890 (0x037a),  (0x), IsBadCodePtr, 0x0003a7c0, None
        893 (0x037d),  (0x), IsBadReadPtr, 0x00016080, None
        894 (0x037e),  (0x), IsBadStringPtrA, 0x0003a7f0, None
        895 (0x037f),  (0x), IsBadStringPtrW, 0x0003a840, None
        896 (0x0380),  (0x), IsBadWritePtr, 0x000671b0, None
        910 (0x038e),  (0x), IsSystemResumeAutomatic, 0x00039cc0, None
        973 (0x03cd),  (0x), LoadModule, 0x00067240, None
        974 (0x03ce),  (0x), LoadPackagedLibrary, 0x000257e0, None
        978 (0x03d2),  (0x), LocalAlloc, 0x00018c90, None
        982 (0x03d6),  (0x), LocalFlags, 0x000686d0, None
        983 (0x03d7),  (0x), LocalFree, 0x00018330, None
        984 (0x03d8),  (0x), LocalHandle, 0x00039220, None
        985 (0x03d9),  (0x), LocalLock, 0x0003c110, None
        986 (0x03da),  (0x), LocalReAlloc, 0x00020520, None
        988 (0x03dc),  (0x), LocalSize, 0x0001bbf0, None
        990 (0x03de),  (0x), LocalUnlock, 0x0003c130, None
        997 (0x03e5),  (0x), MapUserPhysicalPagesScatter, 0x000446c0, None
	    1000 (0x03e8),  (0x), MapViewOfFileExNuma, 0x0003c190, None
	
		*/

    }
}

