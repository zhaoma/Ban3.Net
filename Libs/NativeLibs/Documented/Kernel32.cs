/*
 
    https://learn.microsoft.com/en-us/windows/win32/api/winbase/
    http://pinvoke.net/default.aspx/kernel32.ActivateActCtx
 */

using Ban3.Infrastructures.NativeLibs.Structs;
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class KERNEL32
    {
        const string Dll = "kernel32.dll";


        /// <summary>
        /// Adds an alternate local network name for the computer from which it is called.
        /// AddLocalAlternateComputerNameA;AddLocalAlternateComputerNameW
        /// </summary>
        /// <param name="lpDnsFQHostname"></param>
        /// <param name="ulFlags"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint AddLocalAlternateComputerName(
            string lpDnsFQHostname,
            uint ulFlags);


        /// <summary>
        /// AssignProcessToJobObject
        /// </summary>
        /// <param name="hJob"></param>
        /// <param name="hProcess"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AssignProcessToJobObject(
            IntPtr hJob, 
            IntPtr hProcess);


        /// <summary>
        /// Generates simple tones on the speaker. 
        /// The function is synchronous; it performs an alertable wait and does not return control to its caller until the sound finishes.
        /// utilapiset.h
        /// </summary>
        /// <param name="dwFreq"></param>
        /// <param name="dwDuration"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool Beep(
            uint dwFreq, 
            uint dwDuration);

        /// <summary>
        /// BeginUpdateResourceA;BeginUpdateResourceW
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="bDeleteExistingResources"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr BeginUpdateResource(
            string pFileName,
            bool bDeleteExistingResources);


        /*
         
        *   0001 (0x0001),  (0x), AcquireSRWLockExclusive, NTDLL.RtlAcquireSRWLockExclusive, None
        *   0002 (0x0002),  (0x), AcquireSRWLockShared, NTDLL.RtlAcquireSRWLockShared, None
        *   0003 (0x0003),  (0x), ActivateActCtx, 0x00020840, None
        *   0004 (0x0004),  (0x), ActivateActCtxWorker, 0x0001bed0, None
        *   0005 (0x0005),  (0x), AddAtomA, 0x0005a800, None
        *   0006 (0x0006),  (0x), AddAtomW, 0x000128f0, None
        *   0007 (0x0007),  (0x), AddConsoleAliasA, 0x00025e00, None
        *   0008 (0x0008),  (0x), AddConsoleAliasW, 0x00025e10, None
        *   0009 (0x0009),  (0x), AddDllDirectory, api-ms-win-core-libraryloader-l1-1-0.AddDllDirectory, None
        10 (0x000a),  (0x), AddIntegrityLabelToBoundaryDescriptor, 0x0003d3a0, None
        11 (0x000b),  (0x), AddLocalAlternateComputerNameA, 0x0005a940, None
        12 (0x000c),  (0x), AddLocalAlternateComputerNameW, 0x0005a9a0, None
        *   0013 (0x000d),  (0x), AddRefActCtx, 0x00022a30, None
        *   0014 (0x000e),  (0x), AddRefActCtxWorker, 0x0001ea80, None
        15 (0x000f),  (0x), AddResourceAttributeAce, 0x0003ace0, None
        16 (0x0010),  (0x), AddSIDToBoundaryDescriptor, 0x00021060, None
        17 (0x0011),  (0x), AddScopedPolicyIDAce, 0x0003ad00, None
        *   18 (0x0012),  (0x), AddSecureMemoryCacheCallback, 0x00039100, None
        19 (0x0013),  (0x), AddVectoredContinueHandler, NTDLL.RtlAddVectoredContinueHandler, None
        20 (0x0014),  (0x), AddVectoredExceptionHandler, NTDLL.RtlAddVectoredExceptionHandler, None
        21 (0x0015),  (0x), AdjustCalendarDate, 0x00007200, None
        *   0022 (0x0016),  (0x), AllocConsole, 0x00025a50, None
        *   23 (0x0017),  (0x), AllocateUserPhysicalPages, 0x0003ad40, None
        *   24 (0x0018),  (0x), AllocateUserPhysicalPagesNuma, 0x0003ad20, None
        25 (0x0019),  (0x), AppPolicyGetClrCompat, kernelbase.AppPolicyGetClrCompat, None
        26 (0x001a),  (0x), AppPolicyGetCreateFileAccess, kernelbase.AppPolicyGetCreateFileAccess, None
        27 (0x001b),  (0x), AppPolicyGetLifecycleManagement, kernelbase.AppPolicyGetLifecycleManagement, None
        28 (0x001c),  (0x), AppPolicyGetMediaFoundationCodecLoading, kernelbase.AppPolicyGetMediaFoundationCodecLoading, None
        29 (0x001d),  (0x), AppPolicyGetProcessTerminationMethod, kernelbase.AppPolicyGetProcessTerminationMethod, None
        30 (0x001e),  (0x), AppPolicyGetShowDeveloperDiagnostic, kernelbase.AppPolicyGetShowDeveloperDiagnostic, None
        31 (0x001f),  (0x), AppPolicyGetThreadInitializationType, kernelbase.AppPolicyGetThreadInitializationType, None
        32 (0x0020),  (0x), AppPolicyGetWindowingModel, kernelbase.AppPolicyGetWindowingModel, None
        33 (0x0021),  (0x), AppXGetOSMaxVersionTested, kernelbase.AppXGetOSMaxVersionTested, None
        34 (0x0022),  (0x), ApplicationRecoveryFinished, 0x000444f0, None
        35 (0x0023),  (0x), ApplicationRecoveryInProgress, 0x00044500, None
        *   36 (0x0024),  (0x), AreFileApisANSI, 0x000213b0, None
        37 (0x0025),  (0x), AssignProcessToJobObject, 0x000206c0, None
        *   0038 (0x0026),  (0x), AttachConsole, 0x00025a60, None
        *   39 (0x0027),  (0x), BackupRead, 0x0005d3a0, None
        *   40 (0x0028),  (0x), BackupSeek, 0x0005e560, None
        *   41 (0x0029),  (0x), BackupWrite, 0x0005e840, None
        42 (0x002a),  (0x), BaseCheckAppcompatCache, 0x0003adc0, None
        43 (0x002b),  (0x), BaseCheckAppcompatCacheEx, 0x0003ad60, None
        44 (0x002c),  (0x), BaseCheckAppcompatCacheExWorker, 0x00021720, None
        45 (0x002d),  (0x), BaseCheckAppcompatCacheWorker, 0x00021720, None
        46 (0x002e),  (0x), BaseCheckElevation, 0x00018f20, None
        47 (0x002f),  (0x), BaseCleanupAppcompatCacheSupport, 0x0003ade0, None
        48 (0x0030),  (0x), BaseCleanupAppcompatCacheSupportWorker, 0x00021ba0, None
        49 (0x0031),  (0x), BaseDestroyVDMEnvironment, 0x00040cf0, None
        50 (0x0032),  (0x), BaseDllReadWriteIniFile, 0x0000c500, None
        51 (0x0033),  (0x), BaseDumpAppcompatCache, 0x0003ae00, None
        52 (0x0034),  (0x), BaseDumpAppcompatCacheWorker, 0x00038220, None
        53 (0x0035),  (0x), BaseElevationPostProcessing, 0x0001dad0, None
        54 (0x0036),  (0x), BaseFlushAppcompatCache, 0x0003ae20, None
        55 (0x0037),  (0x), BaseFlushAppcompatCacheWorker, 0x00071170, None
        56 (0x0038),  (0x), BaseFormatObjectAttributes, 0x00025020, None
        57 (0x0039),  (0x), BaseFormatTimeOut, 0x0005a020, None
        58 (0x003a),  (0x), BaseFreeAppCompatDataForProcessWorker, 0x00020620, None
        59 (0x003b),  (0x), BaseGenerateAppCompatData, 0x00016d90, None
        60 (0x003c),  (0x), BaseGetNamedObjectDirectory, 0x0003ae40, None
        61 (0x003d),  (0x), BaseInitAppcompatCacheSupport, 0x0003ae60, None
        62 (0x003e),  (0x), BaseInitAppcompatCacheSupportWorker, 0x00021ba0, None
        63 (0x003f),  (0x), BaseIsAppcompatInfrastructureDisabled, 0x00021720, None
        64 (0x0040),  (0x), BaseIsAppcompatInfrastructureDisabledWorker, 0x00021720, None
        65 (0x0041),  (0x), BaseIsDosApplication, 0x000614e0, None
        66 (0x0042),  (0x), BaseQueryModuleData, 0x000715e0, None
        67 (0x0043),  (0x), BaseReadAppCompatDataForProcessWorker, 0x0001feb0, None
        68 (0x0044),  (0x), BaseSetLastNTError, 0x000130e0, None
        69 (0x0045),  (0x), BaseThreadInitThunk, 0x00017600, None
        70 (0x0046),  (0x), BaseUpdateAppcompatCache, 0x0003ae80, None
        71 (0x0047),  (0x), BaseUpdateAppcompatCacheWorker, 0x000711d0, None
        72 (0x0048),  (0x), BaseUpdateVDMEntry, 0x00041050, None
        73 (0x0049),  (0x), BaseVerifyUnicodeString, 0x0005a0c0, None
        74 (0x004a),  (0x), BaseWriteErrorElevationRequiredEvent, 0x0005fcb0, None
        75 (0x004b),  (0x), Basep8BitStringToDynamicUnicodeString, 0x0001c850, None
        76 (0x004c),  (0x), BasepAllocateActivationContextActivationBlock, 0x0005a120, None
        77 (0x004d),  (0x), BasepAnsiStringToDynamicUnicodeString, 0x0005a050, None
        78 (0x004e),  (0x), BasepAppContainerEnvironmentExtension, 0x00007600, None
        79 (0x004f),  (0x), BasepAppXExtension, 0x00020b60, None
        80 (0x0050),  (0x), BasepCheckAppCompat, 0x000194d0, None
        81 (0x0051),  (0x), BasepCheckWebBladeHashes, 0x0001d7d0, None
        82 (0x0052),  (0x), BasepCheckWinSaferRestrictions, 0x00011df0, None
        83 (0x0053),  (0x), BasepConstructSxsCreateProcessMessage, 0x0000dd40, None
        84 (0x0054),  (0x), BasepCopyEncryption, 0x00038bb0, None
        85 (0x0055),  (0x), BasepFinishPackageActivationForSxS, 0x000272f0, None
        86 (0x0056),  (0x), BasepFreeActivationContextActivationBlock, 0x0005a2b0, None
        87 (0x0057),  (0x), BasepFreeAppCompatData, 0x0001c350, None
        88 (0x0058),  (0x), BasepGetAppCompatData, 0x000163f0, None
        89 (0x0059),  (0x), BasepGetComputerNameFromNtPath, 0x0001a920, None
        90 (0x005a),  (0x), BasepGetExeArchType, 0x00019cb0, None
        91 (0x005b),  (0x), BasepGetPackageActivationTokenForSxS, 0x00027330, None
        92 (0x005c),  (0x), BasepInitAppCompatData, 0x00071300, None
        93 (0x005d),  (0x), BasepIsProcessAllowed, 0x0001c980, None
        94 (0x005e),  (0x), BasepMapModuleHandle, 0x00013740, None
        95 (0x005f),  (0x), BasepNotifyLoadStringResource, 0x0001bde0, None
        96 (0x0060),  (0x), BasepPostSuccessAppXExtension, 0x00021370, None
        97 (0x0061),  (0x), BasepProcessInvalidImage, 0x00039d50, None
        98 (0x0062),  (0x), BasepQueryAppCompat, 0x0000cee0, None
        99 (0x0063),  (0x), BasepQueryModuleChpeSettings, 0x00071390, None
        100 (0x0064),  (0x), BasepReleaseAppXContext, 0x00021350, None
        101 (0x0065),  (0x), BasepReleaseSxsCreateProcessUtilityStruct, 0x000151b0, None
        102 (0x0066),  (0x), BasepReportFault, 0x000447b0, None
        103 (0x0067),  (0x), BasepSetFileEncryptionCompression, 0x0001eb70, None
        104 (0x0068),  (0x), Beep, 0x00037f50, None
        105 (0x0069),  (0x), BeginUpdateResourceA, 0x0004a2f0, None
        106 (0x006a),  (0x), BeginUpdateResourceW, 0x0004a360, None
        *   107 (0x006b),  (0x), BindIoCompletionCallback, 0x00024a20, None
        *   108 (0x006c),  (0x), BuildCommDCBA, 0x00042ca0, None
        *   109 (0x006d),  (0x), BuildCommDCBAndTimeoutsA, 0x00042d00, None
        *   110 (0x006e),  (0x), BuildCommDCBAndTimeoutsW, 0x00042d40, None
        *   111 (0x006f),  (0x), BuildCommDCBW, 0x00042dd0, None
        *   112 (0x0070),  (0x), CallNamedPipeA, 0x00061d30, None
        113 (0x0071),  (0x), CallNamedPipeW, 0x000257f0, None
        114 (0x0072),  (0x), CallbackMayRunLong, 0x0003aea0, None
        115 (0x0073),  (0x), CancelDeviceWakeupRequest, 0x00039ca0, None
        116 (0x0074),  (0x), CancelIo, 0x00021430, None
        117 (0x0075),  (0x), CancelIoEx, 0x00020800, None
        118 (0x0076),  (0x), CancelSynchronousIo, 0x0003aee0, None
        119 (0x0077),  (0x), CancelThreadpoolIo, NTDLL.TpCancelAsyncIoOperation, None
        120 (0x0078),  (0x), CancelTimerQueueTimer, 0x00044710, None
        *   0121 (0x0079),  (0x), CancelWaitableTimer, 0x000250e0, None
        122 (0x007a),  (0x), CeipIsOptedIn, kernelbase.CeipIsOptedIn, None
        123 (0x007b),  (0x), ChangeTimerQueueTimer, 0x00021a40, None
        124 (0x007c),  (0x), CheckAllowDecryptedRemoteDestinationPolicy, 0x0003af00, None
        125 (0x007d),  (0x), CheckElevation, 0x00018de0, None
        126 (0x007e),  (0x), CheckElevationEnabled, 0x00020db0, None
        127 (0x007f),  (0x), CheckForReadOnlyResource, 0x00062230, None
        128 (0x0080),  (0x), CheckForReadOnlyResourceFilter, 0x0003d3d0, None
        129 (0x0081),  (0x), CheckIsMSIXPackage, kernelbase.CheckIsMSIXPackage, None
        *   0130 (0x0082),  (0x), CheckNameLegalDOS8Dot3A, 0x00039ab0, None
        *   0131 (0x0083),  (0x), CheckNameLegalDOS8Dot3W, 0x00039b60, None
        132 (0x0084),  (0x), CheckRemoteDebuggerPresent, 0x00001250, None
        133 (0x0085),  (0x), CheckTokenCapability, 0x0003af20, None
        134 (0x0086),  (0x), CheckTokenMembershipEx, 0x0003af40, None
        *   135 (0x0087),  (0x), ClearCommBreak, 0x00025850, None
        *   136 (0x0088),  (0x), ClearCommError, 0x00025860, None
        137 (0x0089),  (0x), CloseConsoleHandle, 0x0006a0d0, None
        *   138 (0x008a),  (0x), CloseHandle, 0x000250a0, None
        139 (0x008b),  (0x), ClosePackageInfo, kernelbase.ClosePackageInfo, None
        140 (0x008c),  (0x), ClosePrivateNamespace, 0x000229d0, None
        141 (0x008d),  (0x), CloseProfileUserMapping, 0x00021ba0, None
        *   0142 (0x008e),  (0x), ClosePseudoConsole, 0x00025a70, None
        143 (0x008f),  (0x), CloseState, kernelbase.CloseState, None
        144 (0x0090),  (0x), CloseThreadpool, NTDLL.TpReleasePool, None
        145 (0x0091),  (0x), CloseThreadpoolCleanupGroup, NTDLL.TpReleaseCleanupGroup, None
        146 (0x0092),  (0x), CloseThreadpoolCleanupGroupMembers, NTDLL.TpReleaseCleanupGroupMembers, None
        147 (0x0093),  (0x), CloseThreadpoolIo, NTDLL.TpReleaseIoCompletion, None
        148 (0x0094),  (0x), CloseThreadpoolTimer, NTDLL.TpReleaseTimer, None
        149 (0x0095),  (0x), CloseThreadpoolWait, NTDLL.TpReleaseWait, None
        150 (0x0096),  (0x), CloseThreadpoolWork, NTDLL.TpReleaseWork, None
        151 (0x0097),  (0x), CmdBatNotification, 0x00020730, None
        *   152 (0x0098),  (0x), CommConfigDialogA, 0x0003e160, None
        *   153 (0x0099),  (0x), CommConfigDialogW, 0x0003e210, None
        154 (0x009a),  (0x), CompareCalendarDates, 0x0004ad00, None
        155 (0x009b),  (0x), CompareFileTime, 0x000252d0, None
        156 (0x009c),  (0x), CompareStringA, 0x0001dde0, None
        157 (0x009d),  (0x), CompareStringEx, 0x00016230, None
        158 (0x009e),  (0x), CompareStringOrdinal, 0x000163d0, None
        159 (0x009f),  (0x), CompareStringW, 0x0001ce60, None
        160 (0x00a0),  (0x), ConnectNamedPipe, 0x00021790, None
        161 (0x00a1),  (0x), ConsoleMenuControl, 0x0006a210, None
        162 (0x00a2),  (0x), ContinueDebugEvent, 0x0003af60, None
        163 (0x00a3),  (0x), ConvertCalDateTimeToSystemTime, 0x0004adb0, None
        164 (0x00a4),  (0x), ConvertDefaultLocale, 0x0003af80, None
        *   165 (0x00a5),  (0x), ConvertFiberToThread, 0x000259a0, None
        166 (0x00a6),  (0x), ConvertNLSDayOfWeekToWin32DayOfWeek, 0x0004aeb0, None
        167 (0x00a7),  (0x), ConvertSystemTimeToCalDateTime, 0x000074b0, None
        *   168 (0x00a8),  (0x), ConvertThreadToFiber, 0x000259b0, None
        *   169 (0x00a9),  (0x), ConvertThreadToFiberEx, 0x000259c0, None
        170 (0x00aa),  (0x), CopyContext, 0x0003afa0, None
        *   0171 (0x00ab),  (0x), CopyFile2, 0x0003afc0, None
        *   0172 (0x00ac),  (0x), CopyFileA, 0x00062580, None
        *   0173 (0x00ad),  (0x), CopyFileExA, 0x00062630, None
        *   0174 (0x00ae),  (0x), CopyFileExW, 0x00020e80, None
        *   0175 (0x00af),  (0x), CopyFileTransactedA, 0x000626f0, None
        *   0176 (0x00b0),  (0x), CopyFileTransactedW, 0x000627e0, None
        *   0177 (0x00b1),  (0x), CopyFileW, 0x00025990, None
        *   0178 (0x00b2),  (0x), CopyLZFile, 0x00038110, None
        *   0179 (0x00b3),  (0x), CreateActCtxA, 0x00022380, None
        *   0180 (0x00b4),  (0x), CreateActCtxW, 0x00021950, None
        *   0181 (0x00b5),  (0x), CreateActCtxWWorker, 0x000137b0, None
        *   182 (0x00b6),  (0x), CreateBoundaryDescriptorA, 0x000623f0, None
        183 (0x00b7),  (0x), CreateBoundaryDescriptorW, 0x00021000, None
        *   0184 (0x00b8),  (0x), CreateConsoleScreenBuffer, 0x00025b90, None
        *   0185 (0x00b9),  (0x), CreateDirectoryA, 0x000252e0, None
        *   0186 (0x00ba),  (0x), CreateDirectoryExA, 0x00063210, None
        *   0187 (0x00bb),  (0x), CreateDirectoryExW, 0x0003afe0, None
        *   0188 (0x00bc),  (0x), CreateDirectoryTransactedA, 0x00038470, None
        *   0189 (0x00bd),  (0x), CreateDirectoryTransactedW, 0x000632a0, None
        *   0190 (0x00be),  (0x), CreateDirectoryW, 0x000252f0, None
        191 (0x00bf),  (0x), CreateEnclave, api-ms-win-core-enclave-l1-1-0.CreateEnclave, None
        *   0192 (0x00c0),  (0x), CreateEventA, 0x000250f0, None
        *   0193 (0x00c1),  (0x), CreateEventExA, 0x00025100, None
        *   0194 (0x00c2),  (0x), CreateEventExW, 0x00025110, None
        *   0195 (0x00c3),  (0x), CreateEventW, 0x00025120, None
        *   196 (0x00c4),  (0x), CreateFiber, 0x000259d0, None
        *   197 (0x00c5),  (0x), CreateFiberEx, 0x000259e0, None
        *   0198 (0x00c6),  (0x), CreateFile2, 0x00025300, None
        *   0199 (0x00c7),  (0x), CreateFileA, 0x00025310, None
        *   0200 (0x00c8),  (0x), CreateFileMappingA, 0x0001c470, None
        *   0201 (0x00c9),  (0x), CreateFileMappingFromApp, api-ms-win-core-memory-l1-1-1.CreateFileMappingFromApp, None
        *   0202 (0x00ca),  (0x), CreateFileMappingNumaA, 0x00063450, None
        *   0203 (0x00cb),  (0x), CreateFileMappingNumaW, 0x0003b000, None
        *   0204 (0x00cc),  (0x), CreateFileMappingW, 0x0001d0a0, None
        *   0205 (0x00cd),  (0x), CreateFileTransactedA, 0x000628e0, None
        *   0206 (0x00ce),  (0x), CreateFileTransactedW, 0x000629a0, None
        *   0207 (0x00cf),  (0x), CreateFileW, 0x00025320, None
        *   0208 (0x00d0),  (0x), CreateHardLinkA, 0x0003b020, None
        *   0209 (0x00d1),  (0x), CreateHardLinkTransactedA, 0x00043ed0, None
        *   0210 (0x00d2),  (0x), CreateHardLinkTransactedW, 0x00063520, None
        *   0211 (0x00d3),  (0x), CreateHardLinkW, 0x0003b040, None
        212 (0x00d4),  (0x), CreateIoCompletionPort, 0x0001e110, None
        *   213 (0x00d5),  (0x), CreateJobObjectA, 0x0005c930, None
        214 (0x00d6),  (0x), CreateJobObjectW, 0x0001e9b0, None
        215 (0x00d7),  (0x), CreateJobSet, 0x0005c9a0, None
        *   216 (0x00d8),  (0x), CreateMailslotA, 0x0001c620, None
        *   217 (0x00d9),  (0x), CreateMailslotW, 0x0001c690, None
        *   218 (0x00da),  (0x), CreateMemoryResourceNotification, 0x000210a0, None
        *   0219 (0x00db),  (0x), CreateMutexA, 0x00025130, None
        *   0220 (0x00dc),  (0x), CreateMutexExA, 0x00025140, None
        *   0221 (0x00dd),  (0x), CreateMutexExW, 0x00025150, None
        *   0222 (0x00de),  (0x), CreateMutexW, 0x00025160, None
        223 (0x00df),  (0x), CreateNamedPipeA, 0x00061dd0, None
        224 (0x00e0),  (0x), CreateNamedPipeW, 0x00020a30, None
        225 (0x00e1),  (0x), CreatePipe, 0x00020a10, None
        226 (0x00e2),  (0x), CreatePrivateNamespaceA, 0x00062460, None
        227 (0x00e3),  (0x), CreatePrivateNamespaceW, 0x00020fc0, None
        *   228 (0x00e4),  (0x), CreateProcessA, 0x0001cf20, None
        *   229 (0x00e5),  (0x), CreateProcessAsUserA, 0x0003b060, None
        *   230 (0x00e6),  (0x), CreateProcessAsUserW, 0x0001e280, None
        231 (0x00e7),  (0x), CreateProcessInternalA, 0x0003b0e0, None
        232 (0x00e8),  (0x), CreateProcessInternalW, 0x0003b160, None
        *   233 (0x00e9),  (0x), CreateProcessW, 0x0001d320, None
        *   0234 (0x00ea),  (0x), CreatePseudoConsole, 0x00025a80, None
        *   235 (0x00eb),  (0x), CreateRemoteThread, 0x0003b1e0, None
        *   236 (0x00ec),  (0x), CreateRemoteThreadEx, api-ms-win-core-processthreads-l1-1-0.CreateRemoteThreadEx, None
        *   0237 (0x00ed),  (0x), CreateSemaphoreA, 0x0001c540, None
        *   0238 (0x00ee),  (0x), CreateSemaphoreExA, 0x0001c570, None
        *   0239 (0x00ef),  (0x), CreateSemaphoreExW, 0x00025170, None
        *   0240 (0x00f0),  (0x), CreateSemaphoreW, 0x00025180, None
        *   0241 (0x00f1),  (0x), CreateSymbolicLinkA, 0x00063af0, None
        *   0242 (0x00f2),  (0x), CreateSymbolicLinkTransactedA, 0x00063bb0, None
        *   0243 (0x00f3),  (0x), CreateSymbolicLinkTransactedW, 0x00063c70, None
        *   0244 (0x00f4),  (0x), CreateSymbolicLinkW, 0x0003b230, None
        *   245 (0x00f5),  (0x), CreateTapePartition, 0x00043c10, None
        *   246 (0x00f6),  (0x), CreateThread, 0x0001bd70, None
        247 (0x00f7),  (0x), CreateThreadpool, 0x000213f0, None
        248 (0x00f8),  (0x), CreateThreadpoolCleanupGroup, 0x00021970, None
        249 (0x00f9),  (0x), CreateThreadpoolIo, 0x00021520, None
        250 (0x00fa),  (0x), CreateThreadpoolTimer, 0x0001ce20, None
        251 (0x00fb),  (0x), CreateThreadpoolWait, 0x00020f60, None
        252 (0x00fc),  (0x), CreateThreadpoolWork, 0x00020d70, None
        253 (0x00fd),  (0x), CreateTimerQueue, 0x00021a00, None
        254 (0x00fe),  (0x), CreateTimerQueueTimer, 0x0001ea60, None
        255 (0x00ff),  (0x), CreateToolhelp32Snapshot, 0x00028260, None
        *   256 (0x0100),  (0x), CreateUmsCompletionList, 0x00042820, None
        *   257 (0x0101),  (0x), CreateUmsThreadContext, 0x00042860, None
        *   0258 (0x0102),  (0x), CreateWaitableTimerA, 0x00063770, None
        *   0259 (0x0103),  (0x), CreateWaitableTimerExA, 0x00063790, None
        *   0260 (0x0104),  (0x), CreateWaitableTimerExW, 0x00025190, None
        *   0261 (0x0105),  (0x), CreateWaitableTimerW, 0x000010b0, None
        262 (0x0106),  (0x), CtrlRoutine, kernelbase.CtrlRoutine, None
        *   0263 (0x0107),  (0x), DeactivateActCtx, 0x00020860, None
        *   0264 (0x0108),  (0x), DeactivateActCtxWorker, 0x0001c010, None
        265 (0x0109),  (0x), DebugActiveProcess, 0x0003b270, None
        266 (0x010a),  (0x), DebugActiveProcessStop, 0x0003b250, None
        267 (0x010b),  (0x), DebugBreak, 0x0003b290, None
        268 (0x010c),  (0x), DebugBreakProcess, 0x00038360, None
        269 (0x010d),  (0x), DebugSetProcessKillOnExit, 0x00038390, None
        270 (0x010e),  (0x), DecodePointer, NTDLL.RtlDecodePointer, None
        271 (0x010f),  (0x), DecodeSystemPointer, NTDLL.RtlDecodeSystemPointer, None
        272 (0x0110),  (0x), DefineDosDeviceA, 0x00065420, None
        273 (0x0111),  (0x), DefineDosDeviceW, 0x00025330, None
        274 (0x0112),  (0x), DelayLoadFailureHook, 0x00024ad0, None
        *   0275 (0x0113),  (0x), DeleteAtom, 0x00012860, None
        276 (0x0114),  (0x), DeleteBoundaryDescriptor, 0x00020fe0, None
        *   0277 (0x0115),  (0x), DeleteCriticalSection, NTDLL.RtlDeleteCriticalSection, None
        *   278 (0x0116),  (0x), DeleteFiber, 0x000259f0, None
        *   0279 (0x0117),  (0x), DeleteFileA, 0x00025340, None
        *   0280 (0x0118),  (0x), DeleteFileTransactedA, 0x00063d50, None
        *   0281 (0x0119),  (0x), DeleteFileTransactedW, 0x00024930, None
        *   0282 (0x011a),  (0x), DeleteFileW, 0x00025350, None
        *   283 (0x011b),  (0x), DeleteProcThreadAttributeList, api-ms-win-core-processthreads-l1-1-0.DeleteProcThreadAttributeList, None
        *   0284 (0x011c),  (0x), DeleteSynchronizationBarrier, 0x0003b2b0, None
        285 (0x011d),  (0x), DeleteTimerQueue, 0x000219b0, None
        286 (0x011e),  (0x), DeleteTimerQueueEx, 0x00021a20, None
        287 (0x011f),  (0x), DeleteTimerQueueTimer, 0x00020be0, None
        *   288 (0x0120),  (0x), DeleteUmsCompletionList, 0x000428a0, None
        *   289 (0x0121),  (0x), DeleteUmsThreadContext, 0x000428e0, None
        290 (0x0122),  (0x), DeleteVolumeMountPointA, 0x000656c0, None
        291 (0x0123),  (0x), DeleteVolumeMountPointW, 0x00025360, None
        *   292 (0x0124),  (0x), DequeueUmsCompletionListItems, 0x00042920, None
        293 (0x0125),  (0x), DeviceIoControl, 0x00015b70, None
        *   0294 (0x0126),  (0x), DisableThreadLibraryCalls, 0x00020680, None
        295 (0x0127),  (0x), DisableThreadProfiling, 0x000447f0, None
        296 (0x0128),  (0x), DisassociateCurrentThreadFromCallback, NTDLL.TpDisassociateCallback, None
        *   297 (0x0129),  (0x), DiscardVirtualMemory, api-ms-win-core-memory-l1-1-2.DiscardVirtualMemory, None
        298 (0x012a),  (0x), DisconnectNamedPipe, 0x00022720, None
        299 (0x012b),  (0x), DnsHostnameToComputerNameA, 0x0005b8d0, None
        300 (0x012c),  (0x), DnsHostnameToComputerNameExW, 0x0003b2d0, None
        301 (0x012d),  (0x), DnsHostnameToComputerNameW, 0x0001ccd0, None
        302 (0x012e),  (0x), DosDateTimeToFileTime, 0x00012a90, None
        303 (0x012f),  (0x), DosPathToSessionPathA, 0x00066ac0, None
        304 (0x0130),  (0x), DosPathToSessionPathW, 0x00066cc0, None
        305 (0x0131),  (0x), DuplicateConsoleHandle, 0x0006a0f0, None
        306 (0x0132),  (0x), DuplicateEncryptionInfoFileExt, 0x00038f00, None
        *   307 (0x0133),  (0x), DuplicateHandle, 0x000250b0, None
        308 (0x0134),  (0x), EnableThreadProfiling, 0x00044830, None
        309 (0x0135),  (0x), EncodePointer, NTDLL.RtlEncodePointer, None
        310 (0x0136),  (0x), EncodeSystemPointer, NTDLL.RtlEncodeSystemPointer, None
        311 (0x0137),  (0x), EndUpdateResourceA, 0x0004a5b0, None
        312 (0x0138),  (0x), EndUpdateResourceW, 0x0004a5c0, None
        *   0313 (0x0139),  (0x), EnterCriticalSection, NTDLL.RtlEnterCriticalSection, None
        *   0314 (0x013a),  (0x), EnterSynchronizationBarrier, 0x0003b2f0, None
        *   315 (0x013b),  (0x), EnterUmsSchedulingMode, 0x00042980, None
        316 (0x013c),  (0x), EnumCalendarInfoA, 0x0004b9a0, None
        317 (0x013d),  (0x), EnumCalendarInfoExA, 0x0004ba40, None
        318 (0x013e),  (0x), EnumCalendarInfoExEx, 0x0001cf00, None
        319 (0x013f),  (0x), EnumCalendarInfoExW, 0x0003b310, None
        320 (0x0140),  (0x), EnumCalendarInfoW, 0x0003b330, None
        321 (0x0141),  (0x), EnumDateFormatsA, 0x0004bae0, None
        322 (0x0142),  (0x), EnumDateFormatsExA, 0x0004bb40, None
        323 (0x0143),  (0x), EnumDateFormatsExEx, 0x0003b350, None
        324 (0x0144),  (0x), EnumDateFormatsExW, 0x0003b370, None
        325 (0x0145),  (0x), EnumDateFormatsW, 0x0003b390, None
        326 (0x0146),  (0x), EnumLanguageGroupLocalesA, 0x0004bbb0, None
        327 (0x0147),  (0x), EnumLanguageGroupLocalesW, 0x0003b3b0, None
        328 (0x0148),  (0x), EnumResourceLanguagesA, 0x00039350, None
        329 (0x0149),  (0x), EnumResourceLanguagesExA, 0x0003b3d0, None
        330 (0x014a),  (0x), EnumResourceLanguagesExW, 0x0003b3f0, None
        331 (0x014b),  (0x), EnumResourceLanguagesW, 0x00039390, None
        332 (0x014c),  (0x), EnumResourceNamesA, 0x000393d0, None
        333 (0x014d),  (0x), EnumResourceNamesExA, 0x0003b410, None
        334 (0x014e),  (0x), EnumResourceNamesExW, 0x0003b430, None
        335 (0x014f),  (0x), EnumResourceNamesW, 0x000257d0, None
        336 (0x0150),  (0x), EnumResourceTypesA, 0x00039400, None
        337 (0x0151),  (0x), EnumResourceTypesExA, 0x0003b450, None
        338 (0x0152),  (0x), EnumResourceTypesExW, 0x0003b470, None
        339 (0x0153),  (0x), EnumResourceTypesW, 0x00039430, None
        340 (0x0154),  (0x), EnumSystemCodePagesA, 0x0004bbe0, None
        341 (0x0155),  (0x), EnumSystemCodePagesW, 0x0003b490, None
        342 (0x0156),  (0x), EnumSystemFirmwareTables, 0x00039130, None
        343 (0x0157),  (0x), EnumSystemGeoID, 0x00054be0, None
        344 (0x0158),  (0x), EnumSystemGeoNames, 0x00054cd0, None
        345 (0x0159),  (0x), EnumSystemLanguageGroupsA, 0x0004bc00, None
        346 (0x015a),  (0x), EnumSystemLanguageGroupsW, 0x0003b4b0, None
        347 (0x015b),  (0x), EnumSystemLocalesA, 0x0003b4d0, None
        348 (0x015c),  (0x), EnumSystemLocalesEx, 0x0003b4f0, None
        349 (0x015d),  (0x), EnumSystemLocalesW, 0x0003b510, None
        350 (0x015e),  (0x), EnumTimeFormatsA, 0x0004bc20, None
        351 (0x015f),  (0x), EnumTimeFormatsEx, 0x00020c00, None
        352 (0x0160),  (0x), EnumTimeFormatsW, 0x0003b530, None
        353 (0x0161),  (0x), EnumUILanguagesA, 0x0004bca0, None
        354 (0x0162),  (0x), EnumUILanguagesW, 0x0003b550, None
        355 (0x0163),  (0x), EnumerateLocalComputerNamesA, 0x0005b9c0, None
        356 (0x0164),  (0x), EnumerateLocalComputerNamesW, 0x0005baf0, None
        *   357 (0x0165),  (0x), EraseTape, 0x00043c70, None
        *   358 (0x0166),  (0x), EscapeCommFunction, 0x00025870, None
        *   359 (0x0167),  (0x), ExecuteUmsThread, 0x00042a30, None
        *   360 (0x0168),  (0x), ExitProcess, 0x0001e860, None
        *   361 (0x0169),  (0x), ExitThread, NTDLL.RtlExitUserThread, None
        362 (0x016a),  (0x), ExitVDM, 0x000412f0, None
        363 (0x016b),  (0x), ExpandEnvironmentStringsA, 0x00022a10, None
        364 (0x016c),  (0x), ExpandEnvironmentStringsW, 0x0001bf60, None
        365 (0x016d),  (0x), ExpungeConsoleCommandHistoryA, 0x00025e20, None
        366 (0x016e),  (0x), ExpungeConsoleCommandHistoryW, 0x00025e30, None
        367 (0x016f),  (0x), FatalAppExitA, 0x0003b570, None
        368 (0x0170),  (0x), FatalAppExitW, 0x0003b590, None
        369 (0x0171),  (0x), FatalExit, 0x0001e860, None
        370 (0x0172),  (0x), FileTimeToDosDateTime, 0x00012d30, None
        371 (0x0173),  (0x), FileTimeToLocalFileTime, 0x00025370, None
        372 (0x0174),  (0x), FileTimeToSystemTime, 0x00025810, None
        *   0373 (0x0175),  (0x), FillConsoleOutputAttribute, 0x00025ba0, None
        *   0374 (0x0176),  (0x), FillConsoleOutputCharacterA, 0x00025bb0, None
        *   0375 (0x0177),  (0x), FillConsoleOutputCharacterW, 0x00025bc0, None
        *   0376 (0x0178),  (0x), FindActCtxSectionGuid, 0x0001c450, None
        *   0377 (0x0179),  (0x), FindActCtxSectionGuidWorker, 0x00012f90, None
        *   0378 (0x017a),  (0x), FindActCtxSectionStringA, 0x00066e50, None
        *   0379 (0x017b),  (0x), FindActCtxSectionStringW, 0x000218c0, None
        *   0380 (0x017c),  (0x), FindActCtxSectionStringWWorker, 0x000132b0, None
        *   0381 (0x017d),  (0x), FindAtomA, 0x00015820, None
        *   0382 (0x017e),  (0x), FindAtomW, 0x00012d10, None
        383 (0x017f),  (0x), FindClose, 0x00025380, None
        384 (0x0180),  (0x), FindCloseChangeNotification, 0x00025390, None
        385 (0x0181),  (0x), FindFirstChangeNotificationA, 0x000253a0, None
        386 (0x0182),  (0x), FindFirstChangeNotificationW, 0x000253b0, None
        *   0387 (0x0183),  (0x), FindFirstFileA, 0x000253c0, None
        *   0388 (0x0184),  (0x), FindFirstFileExA, 0x000253d0, None
        *   0389 (0x0185),  (0x), FindFirstFileExW, 0x000253e0, None
        *   0390 (0x0186),  (0x), FindFirstFileNameTransactedW, 0x00038570, None
        *   0391 (0x0187),  (0x), FindFirstFileNameW, 0x000253f0, None
        *   0392 (0x0188),  (0x), FindFirstFileTransactedA, 0x00038650, None
        *   0393 (0x0189),  (0x), FindFirstFileTransactedW, 0x00066ef0, None
        *   0394 (0x018a),  (0x), FindFirstFileW, 0x00025400, None
        *   0395 (0x018b),  (0x), FindFirstStreamTransactedW, 0x00038740, None
        *   0396 (0x018c),  (0x), FindFirstStreamW, api-ms-win-core-file-l1-2-2.FindFirstStreamW, None
        *   0397 (0x018d),  (0x), FindFirstVolumeA, 0x00065710, None
        *   0398 (0x018e),  (0x), FindFirstVolumeMountPointA, 0x000658b0, None
        *   0399 (0x018f),  (0x), FindFirstVolumeMountPointW, 0x00065aa0, None
        *   0400 (0x0190),  (0x), FindFirstVolumeW, 0x00025410, None
        401 (0x0191),  (0x), FindNLSString, 0x0003b5b0, None
        402 (0x0192),  (0x), FindNLSStringEx, 0x00015e10, None
        403 (0x0193),  (0x), FindNextChangeNotification, 0x00025420, None
        *   0404 (0x0194),  (0x), FindNextFileA, 0x00025430, None
        *   0405 (0x0195),  (0x), FindNextFileNameW, 0x00025440, None
        *   0406 (0x0196),  (0x), FindNextFileW, 0x00025450, None
        *   0407 (0x0197),  (0x), FindNextStreamW, api-ms-win-core-file-l1-2-2.FindNextStreamW, None
        *   0408 (0x0198),  (0x), FindNextVolumeA, 0x00065d30, None
        *   0409 (0x0199),  (0x), FindNextVolumeMountPointA, 0x00065ed0, None
        *   0410 (0x019a),  (0x), FindNextVolumeMountPointW, 0x000665c0, None
        *   0411 (0x019b),  (0x), FindNextVolumeW, 0x00025460, None
        412 (0x019c),  (0x), FindPackagesByPackageFamily, kernelbase.FindPackagesByPackageFamily, None
        413 (0x019d),  (0x), FindResourceA, 0x00013530, None
        414 (0x019e),  (0x), FindResourceExA, 0x00013550, None
        415 (0x019f),  (0x), FindResourceExW, 0x0001bb50, None
        416 (0x01a0),  (0x), FindResourceW, 0x000209f0, None
        417 (0x01a1),  (0x), FindStringOrdinal, 0x0003b5d0, None
        418 (0x01a2),  (0x), FindVolumeClose, 0x00025470, None
        419 (0x01a3),  (0x), FindVolumeMountPointClose, 0x000665d0, None
        420 (0x01a4),  (0x), FlsAlloc, 0x00020990, None
        421 (0x01a5),  (0x), FlsFree, 0x000212d0, None
        422 (0x01a6),  (0x), FlsGetValue, 0x00018cb0, None
        423 (0x01a7),  (0x), FlsSetValue, 0x0001ca90, None
        *   0424 (0x01a8),  (0x), FlushConsoleInputBuffer, 0x00025bd0, None
        425 (0x01a9),  (0x), FlushFileBuffers, 0x00025480, None
        426 (0x01aa),  (0x), FlushInstructionCache, 0x0001b650, None
        *   427 (0x01ab),  (0x), FlushProcessWriteBuffers, NTDLL.NtFlushProcessWriteBuffers, None
        *   428 (0x01ac),  (0x), FlushViewOfFile, 0x0003b5f0, None
        429 (0x01ad),  (0x), FoldStringA, 0x0004bcc0, None
        430 (0x01ae),  (0x), FoldStringW, 0x0003b610, None
        431 (0x01af),  (0x), FormatApplicationUserModelId, kernelbase.FormatApplicationUserModelId, None
        432 (0x01b0),  (0x), FormatMessageA, 0x00022840, None
        433 (0x01b1),  (0x), FormatMessageW, 0x0001d050, None
        *   0434 (0x01b2),  (0x), FreeConsole, 0x00025a90, None
        435 (0x01b3),  (0x), FreeEnvironmentStringsA, 0x00020560, None
        436 (0x01b4),  (0x), FreeEnvironmentStringsW, 0x0001fe70, None
        *   0437 (0x01b5),  (0x), FreeLibrary, 0x0001cf90, None
        *   0438 (0x01b6),  (0x), FreeLibraryAndExitThread, 0x000217f0, None
        *   0439 (0x01b7),  (0x), FreeLibraryWhenCallbackReturns, NTDLL.TpCallbackUnloadDllOnCompletion, None
        440 (0x01b8),  (0x), FreeMemoryJobObject, 0x0005c9d0, None
        441 (0x01b9),  (0x), FreeResource, 0x000225d0, None
        *   442 (0x01ba),  (0x), FreeUserPhysicalPages, 0x0003b630, None
        *   0443 (0x01bb),  (0x), GenerateConsoleCtrlEvent, 0x00025be0, None
        444 (0x01bc),  (0x), GetACP, 0x0001e820, None
        *   445 (0x01bd),  (0x), GetActiveProcessorCount, 0x0001dc70, None
        *   446 (0x01be),  (0x), GetActiveProcessorGroupCount, 0x00067090, None
        447 (0x01bf),  (0x), GetAppContainerAce, 0x0003b650, None
        448 (0x01c0),  (0x), GetAppContainerNamedObjectPath, 0x0003b670, None
        449 (0x01c1),  (0x), GetApplicationRecoveryCallback, 0x0003b690, None
        450 (0x01c2),  (0x), GetApplicationRecoveryCallbackWorker, 0x00044510, None
        451 (0x01c3),  (0x), GetApplicationRestartSettings, 0x0003b6b0, None
        452 (0x01c4),  (0x), GetApplicationRestartSettingsWorker, 0x000445d0, None
        453 (0x01c5),  (0x), GetApplicationUserModelId, kernelbase.GetApplicationUserModelId, None
        *   0454 (0x01c6),  (0x), GetAtomNameA, 0x0005a820, None
        *   0455 (0x01c7),  (0x), GetAtomNameW, 0x00012630, None
        *   0456 (0x01c8),  (0x), GetBinaryType, 0x000615f0, None
        *   0457 (0x01c9),  (0x), GetBinaryTypeA, 0x000615f0, None
        *   0458 (0x01ca),  (0x), GetBinaryTypeW, 0x00061640, None
        459 (0x01cb),  (0x), GetCPInfo, 0x0001eaa0, None
        460 (0x01cc),  (0x), GetCPInfoExA, 0x0004bf70, None
        461 (0x01cd),  (0x), GetCPInfoExW, 0x0003b6d0, None
        462 (0x01ce),  (0x), GetCachedSigningLevel, 0x0003b6f0, None
        463 (0x01cf),  (0x), GetCalendarDateFormat, 0x0004aef0, None
        464 (0x01d0),  (0x), GetCalendarDateFormatEx, 0x000086b0, None
        465 (0x01d1),  (0x), GetCalendarDaysInMonth, 0x000073b0, None
        466 (0x01d2),  (0x), GetCalendarDifferenceInDays, 0x0004b1d0, None
        467 (0x01d3),  (0x), GetCalendarInfoA, 0x0004c050, None
        468 (0x01d4),  (0x), GetCalendarInfoEx, 0x00025820, None
        469 (0x01d5),  (0x), GetCalendarInfoW, 0x00025830, None
        470 (0x01d6),  (0x), GetCalendarMonthsInYear, 0x0004b330, None
        471 (0x01d7),  (0x), GetCalendarSupportedDateRange, 0x00007130, None
        472 (0x01d8),  (0x), GetCalendarWeekNumber, 0x0004b400, None
        473 (0x01d9),  (0x), GetComPlusPackageInstallStatus, 0x00044440, None
        *   474 (0x01da),  (0x), GetCommConfig, 0x00025880, None
        *   475 (0x01db),  (0x), GetCommMask, 0x00025890, None
        *   476 (0x01dc),  (0x), GetCommModemStatus, 0x000258a0, None
        *   477 (0x01dd),  (0x), GetCommProperties, 0x000258b0, None
        *   478 (0x01de),  (0x), GetCommState, 0x000258c0, None
        *   479 (0x01df),  (0x), GetCommTimeouts, 0x000258d0, None
        480 (0x01e0),  (0x), GetCommandLineA, 0x00020600, None
        481 (0x01e1),  (0x), GetCommandLineW, 0x0001fb80, None
        *   0482 (0x01e2),  (0x), GetCompressedFileSizeA, 0x0003b710, None
        *   0483 (0x01e3),  (0x), GetCompressedFileSizeTransactedA, 0x00063da0, None
        *   0484 (0x01e4),  (0x), GetCompressedFileSizeTransactedW, 0x00063e00, None
        *   0485 (0x01e5),  (0x), GetCompressedFileSizeW, 0x0003b730, None
        486 (0x01e6),  (0x), GetComputerNameA, 0x0001aad0, None
        487 (0x01e7),  (0x), GetComputerNameExA, 0x00024a50, None
        488 (0x01e8),  (0x), GetComputerNameExW, 0x000209b0, None
        489 (0x01e9),  (0x), GetComputerNameW, 0x0001ac30, None
        *   0490 (0x01ea),  (0x), GetConsoleAliasA, 0x00025e40, None
        *   0491 (0x01eb),  (0x), GetConsoleAliasExesA, 0x00025e50, None
        *   0492 (0x01ec),  (0x), GetConsoleAliasExesLengthA, 0x00025e60, None
        *   0493 (0x01ed),  (0x), GetConsoleAliasExesLengthW, 0x00025e70, None
        *   0494 (0x01ee),  (0x), GetConsoleAliasExesW, 0x00025e80, None
        *   0495 (0x01ef),  (0x), GetConsoleAliasW, 0x00025e90, None
        *   0496 (0x01f0),  (0x), GetConsoleAliasesA, 0x00025ea0, None
        *   0497 (0x01f1),  (0x), GetConsoleAliasesLengthA, 0x00025eb0, None
        *   0498 (0x01f2),  (0x), GetConsoleAliasesLengthW, 0x00025ec0, None
        *   0499 (0x01f3),  (0x), GetConsoleAliasesW, 0x00025ed0, None
        *   0500 (0x01f4),  (0x), GetConsoleCP, 0x00025aa0, None
        *   0501 (0x01f5),  (0x), GetConsoleCharType, 0x0006a720, None
        *   0502 (0x01f6),  (0x), GetConsoleCommandHistoryA, 0x00025ee0, None
        *   0503 (0x01f7),  (0x), GetConsoleCommandHistoryLengthA, 0x00025ef0, None
        *   0504 (0x01f8),  (0x), GetConsoleCommandHistoryLengthW, 0x00025f00, None
        *   0505 (0x01f9),  (0x), GetConsoleCommandHistoryW, 0x00025f10, None
        *   0506 (0x01fa),  (0x), GetConsoleCursorInfo, 0x00025bf0, None
        *   0507 (0x01fb),  (0x), GetConsoleCursorMode, 0x0006a790, None
        *   0508 (0x01fc),  (0x), GetConsoleDisplayMode, 0x00025f20, None
        *   0509 (0x01fd),  (0x), GetConsoleFontInfo, 0x0006ab00, None
        *   0510 (0x01fe),  (0x), GetConsoleFontSize, 0x00025f30, None
        *   0511 (0x01ff),  (0x), GetConsoleHardwareState, 0x0006a270, None
        *   0512 (0x0200),  (0x), GetConsoleHistoryInfo, 0x00025f40, None
        *   0513 (0x0201),  (0x), GetConsoleInputExeNameA, kernelbase.GetConsoleInputExeNameA, None
        *   0514 (0x0202),  (0x), GetConsoleInputExeNameW, kernelbase.GetConsoleInputExeNameW, None
        *   0515 (0x0203),  (0x), GetConsoleInputWaitHandle, 0x0006a190, None
        *   0516 (0x0204),  (0x), GetConsoleKeyboardLayoutNameA, 0x0006abb0, None
        *   0517 (0x0205),  (0x), GetConsoleKeyboardLayoutNameW, 0x0006abd0, None
        *   0518 (0x0206),  (0x), GetConsoleMode, 0x00025ab0, None
        *   0519 (0x0207),  (0x), GetConsoleNlsMode, 0x0006a810, None
        *   0520 (0x0208),  (0x), GetConsoleOriginalTitleA, 0x00025c00, None
        *   0521 (0x0209),  (0x), GetConsoleOriginalTitleW, 0x00025c10, None
        *   0522 (0x020a),  (0x), GetConsoleOutputCP, 0x00025ac0, None
        *   0523 (0x020b),  (0x), GetConsoleProcessList, 0x00025f50, None
        *   0524 (0x020c),  (0x), GetConsoleScreenBufferInfo, 0x00025c20, None
        *   0525 (0x020d),  (0x), GetConsoleScreenBufferInfoEx, 0x00025c30, None
        *   0526 (0x020e),  (0x), GetConsoleSelectionInfo, 0x00025f60, None
        *   0527 (0x020f),  (0x), GetConsoleTitleA, 0x00025c40, None
        *   0528 (0x0210),  (0x), GetConsoleTitleW, 0x00025c50, None
        *   0529 (0x0211),  (0x), GetConsoleWindow, 0x00025f70, None
        530 (0x0212),  (0x), GetCurrencyFormatA, 0x0004c2b0, None
        531 (0x0213),  (0x), GetCurrencyFormatEx, 0x0003b750, None
        532 (0x0214),  (0x), GetCurrencyFormatW, 0x0003b770, None
        *   0533 (0x0215),  (0x), GetCurrentActCtx, 0x00022740, None
        *   0534 (0x0216),  (0x), GetCurrentActCtxWorker, 0x0001cea0, None
        535 (0x0217),  (0x), GetCurrentApplicationUserModelId, kernelbase.GetCurrentApplicationUserModelId, None
        *   0536 (0x0218),  (0x), GetCurrentConsoleFont, 0x00025f80, None
        *   0537 (0x0219),  (0x), GetCurrentConsoleFontEx, 0x00025f90, None
        538 (0x021a),  (0x), GetCurrentDirectoryA, 0x00021810, None
        539 (0x021b),  (0x), GetCurrentDirectoryW, 0x000206f0, None
        540 (0x021c),  (0x), GetCurrentPackageFamilyName, kernelbase.GetCurrentPackageFamilyName, None
        541 (0x021d),  (0x), GetCurrentPackageFullName, kernelbase.GetCurrentPackageFullName, None
        542 (0x021e),  (0x), GetCurrentPackageId, kernelbase.GetCurrentPackageId, None
        543 (0x021f),  (0x), GetCurrentPackageInfo, kernelbase.GetCurrentPackageInfo, None
        544 (0x0220),  (0x), GetCurrentPackagePath, kernelbase.GetCurrentPackagePath, None
        *   545 (0x0221),  (0x), GetCurrentProcess, 0x00025040, None
        *   546 (0x0222),  (0x), GetCurrentProcessId, 0x00025050, None
        *   547 (0x0223),  (0x), GetCurrentProcessorNumber, NTDLL.RtlGetCurrentProcessorNumber, None
        *   548 (0x0224),  (0x), GetCurrentProcessorNumberEx, NTDLL.RtlGetCurrentProcessorNumberEx, None
        *   549 (0x0225),  (0x), GetCurrentThread, 0x00015e80, None
        *   550 (0x0226),  (0x), GetCurrentThreadId, 0x00015b30, None
        *   551 (0x0227),  (0x), GetCurrentThreadStackLimits, api-ms-win-core-processthreads-l1-1-0.GetCurrentThreadStackLimits, None
        *   552 (0x0228),  (0x), GetCurrentUmsThread, 0x00042a70, None
        553 (0x0229),  (0x), GetDateFormatA, 0x0003b780, None
        554 (0x022a),  (0x), GetDateFormatAWorker, 0x00022ab0, None
        555 (0x022b),  (0x), GetDateFormatEx, 0x0003b7a0, None
        556 (0x022c),  (0x), GetDateFormatW, 0x00020e60, None
        557 (0x022d),  (0x), GetDateFormatWWorker, 0x0000a790, None
        *   558 (0x022e),  (0x), GetDefaultCommConfigA, 0x0003e470, None
        *   559 (0x022f),  (0x), GetDefaultCommConfigW, 0x0003e520, None
        *   560 (0x0230),  (0x), GetDevicePowerState, 0x000679b0, None
        *   561 (0x0231),  (0x), GetDiskFreeSpaceA, 0x00025490, None
        *   562 (0x0232),  (0x), GetDiskFreeSpaceExA, 0x000254a0, None
        *   563 (0x0233),  (0x), GetDiskFreeSpaceExW, 0x000254b0, None
        *   564 (0x0234),  (0x), GetDiskFreeSpaceW, 0x000254c0, None
        *   565 (0x0235),  (0x), GetDiskSpaceInformationA, api-ms-win-core-file-l1-2-3.GetDiskSpaceInformationA, None
        *   566 (0x0236),  (0x), GetDiskSpaceInformationW, api-ms-win-core-file-l1-2-3.GetDiskSpaceInformationW, None
        *   567 (0x0237),  (0x), GetDllDirectoryA, 0x00039460, None
        *   568 (0x0238),  (0x), GetDllDirectoryW, 0x00022640, None
        *   569 (0x0239),  (0x), GetDriveTypeA, 0x000254d0, None
        *   570 (0x023a),  (0x), GetDriveTypeW, 0x000254e0, None
        571 (0x023b),  (0x), GetDurationFormat, 0x0004cf70, None
        572 (0x023c),  (0x), GetDurationFormatEx, 0x0003b7c0, None
        573 (0x023d),  (0x), GetDynamicTimeZoneInformation, 0x00021700, None
        574 (0x023e),  (0x), GetEnabledXStateFeatures, 0x0003b7e0, None
        575 (0x023f),  (0x), GetEncryptedFileVersionExt, 0x00039000, None
        576 (0x0240),  (0x), GetEnvironmentStrings, 0x00020540, None
        577 (0x0241),  (0x), GetEnvironmentStringsA, 0x00025840, None
        578 (0x0242),  (0x), GetEnvironmentStringsW, 0x0001fe50, None
        579 (0x0243),  (0x), GetEnvironmentVariableA, 0x0001eb10, None
        580 (0x0244),  (0x), GetEnvironmentVariableW, 0x0001bdf0, None
        581 (0x0245),  (0x), GetEraNameCountedString, 0x0003b800, None
        582 (0x0246),  (0x), GetErrorMode, 0x000229b0, None
        *   583 (0x0247),  (0x), GetExitCodeProcess, 0x0001d820, None
        *   584 (0x0248),  (0x), GetExitCodeThread, 0x00020180, None
        585 (0x0249),  (0x), GetExpandedNameA, 0x0003d560, None
        586 (0x024a),  (0x), GetExpandedNameW, 0x0003d650, None
        *   0587 (0x024b),  (0x), GetFileAttributesA, 0x000254f0, None
        *   0588 (0x024c),  (0x), GetFileAttributesExA, 0x00025500, None
        *   0589 (0x024d),  (0x), GetFileAttributesExW, 0x00025510, None
        *   0590 (0x024e),  (0x), GetFileAttributesTransactedA, 0x00063ed0, None
        *   0591 (0x024f),  (0x), GetFileAttributesTransactedW, 0x00063f40, None
        *   0592 (0x0250),  (0x), GetFileAttributesW, 0x00025520, None
        *   0593 (0x0251),  (0x), GetFileBandwidthReservation, 0x00038820, None
        *   0594 (0x0252),  (0x), GetFileInformationByHandle, 0x00025530, None
        *   0595 (0x0253),  (0x), GetFileInformationByHandleEx, 0x0001fe10, None
        596 (0x0254),  (0x), GetFileMUIInfo, 0x0003b820, None
        597 (0x0255),  (0x), GetFileMUIPath, 0x00020160, None
        *   598 (0x0256),  (0x), GetFileSize, 0x00025540, None
        *   599 (0x0257),  (0x), GetFileSizeEx, 0x00025550, None
        *   600 (0x0258),  (0x), GetFileTime, 0x00025560, None
        *   601 (0x0259),  (0x), GetFileType, 0x00025570, None
        602 (0x025a),  (0x), GetFinalPathNameByHandleA, 0x00025580, None
        603 (0x025b),  (0x), GetFinalPathNameByHandleW, 0x00025590, None
        604 (0x025c),  (0x), GetFirmwareEnvironmentVariableA, 0x00067a10, None
        605 (0x025d),  (0x), GetFirmwareEnvironmentVariableExA, 0x00067a30, None
        606 (0x025e),  (0x), GetFirmwareEnvironmentVariableExW, 0x000159d0, None
        607 (0x025f),  (0x), GetFirmwareEnvironmentVariableW, 0x00067b60, None
        608 (0x0260),  (0x), GetFirmwareType, 0x00022fe0, None
        *   0609 (0x0261),  (0x), GetFullPathNameA, 0x000255a0, None
        *   0610 (0x0262),  (0x), GetFullPathNameTransactedA, 0x00038230, None
        *   0611 (0x0263),  (0x), GetFullPathNameTransactedW, 0x00067dd0, None
        *   0612 (0x0264),  (0x), GetFullPathNameW, 0x000255b0, None
        613 (0x0265),  (0x), GetGeoInfoA, 0x0004c6b0, None
        614 (0x0266),  (0x), GetGeoInfoEx, 0x00054e00, None
        615 (0x0267),  (0x), GetGeoInfoW, 0x00006020, None
        *   616 (0x0268),  (0x), GetHandleInformation, 0x000250c0, None
        *   617 (0x0269),  (0x), GetLargePageMinimum, 0x0003b840, None
        *   0618 (0x026a),  (0x), GetLargestConsoleWindowSize, 0x00025c60, None
        619 (0x026b),  (0x), GetLastError, 0x000161d0, None
        620 (0x026c),  (0x), GetLocalTime, 0x0001e7e0, None
        621 (0x026d),  (0x), GetLocaleInfoA, 0x00021390, None
        622 (0x026e),  (0x), GetLocaleInfoEx, 0x0001d300, None
        623 (0x026f),  (0x), GetLocaleInfoW, 0x000205e0, None
        *   0624 (0x0270),  (0x), GetLogicalDriveStringsA, 0x000184d0, None
        *   0625 (0x0271),  (0x), GetLogicalDriveStringsW, 0x000255c0, None
        *   0626 (0x0272),  (0x), GetLogicalDrives, 0x00018590, None
        627 (0x0273),  (0x), GetLogicalProcessorInformation, 0x00021830, None
        628 (0x0274),  (0x), GetLogicalProcessorInformationEx, api-ms-win-core-sysinfo-l1-1-0.GetLogicalProcessorInformationEx, None
        *   0629 (0x0275),  (0x), GetLongPathNameA, 0x0005a310, None
        *   0630 (0x0276),  (0x), GetLongPathNameTransactedA, 0x00041390, None
        *   0631 (0x0277),  (0x), GetLongPathNameTransactedW, 0x000619c0, None
        *   0632 (0x0278),  (0x), GetLongPathNameW, 0x000068c0, None
        *   633 (0x0279),  (0x), GetMailslotInfo, 0x00063600, None
        *   634 (0x027a),  (0x), GetMaximumProcessorCount, 0x000670f0, None
        *   635 (0x027b),  (0x), GetMaximumProcessorGroupCount, 0x00022f80, None
        *   636 (0x027c),  (0x), GetMemoryErrorHandlingCapabilities, 0x0003b860, None
        *   0637 (0x027d),  (0x), GetModuleFileNameA, 0x0001f960, None
        *   0638 (0x027e),  (0x), GetModuleFileNameW, 0x0001e6e0, None
        *   0639 (0x027f),  (0x), GetModuleHandleA, 0x0001f870, None
        *   0640 (0x0280),  (0x), GetModuleHandleExA, 0x00021750, None
        *   0641 (0x0281),  (0x), GetModuleHandleExW, 0x0001fdf0, None
        *   0642 (0x0282),  (0x), GetModuleHandleW, 0x0001d8f0, None
        643 (0x0283),  (0x), GetNLSVersion, 0x00022950, None
        644 (0x0284),  (0x), GetNLSVersionEx, 0x0003b880, None
        645 (0x0285),  (0x), GetNamedPipeAttribute, 0x0003b8a0, None
        *   646 (0x0286),  (0x), GetNamedPipeClientComputerNameA, 0x00061e80, None
        647 (0x0287),  (0x), GetNamedPipeClientComputerNameW, 0x0003b8c0, None
        *   648 (0x0288),  (0x), GetNamedPipeClientProcessId, 0x00061fd0, None
        *   649 (0x0289),  (0x), GetNamedPipeClientSessionId, 0x000396e0, None
        *   650 (0x028a),  (0x), GetNamedPipeHandleStateA, 0x00062010, None
        651 (0x028b),  (0x), GetNamedPipeHandleStateW, 0x0003b8e0, None
        652 (0x028c),  (0x), GetNamedPipeInfo, api-ms-win-core-namedpipe-l1-2-1.GetNamedPipeInfo, None
        *   653 (0x028d),  (0x), GetNamedPipeServerProcessId, 0x000621a0, None
        *   654 (0x028e),  (0x), GetNamedPipeServerSessionId, 0x00039740, None
        655 (0x028f),  (0x), GetNativeSystemInfo, 0x00020e40, None
        *   656 (0x0290),  (0x), GetNextUmsListItem, 0x00042ab0, None
        657 (0x0291),  (0x), GetNextVDMCommand, 0x00041460, None
        *   658 (0x0292),  (0x), GetNumaAvailableMemoryNode, 0x00039990, None
        *   659 (0x0293),  (0x), GetNumaAvailableMemoryNodeEx, 0x00068370, None
        660 (0x0294),  (0x), GetNumaHighestNodeNumber, 0x00021020, None
        *   661 (0x0295),  (0x), GetNumaNodeNumberFromHandle, 0x000399a0, None
        *   662 (0x0296),  (0x), GetNumaNodeProcessorMask, 0x00068400, None
        663 (0x0297),  (0x), GetNumaNodeProcessorMaskEx, 0x0003b900, None
        *   664 (0x0298),  (0x), GetNumaProcessorNode, 0x00039a00, None
        *   665 (0x0299),  (0x), GetNumaProcessorNodeEx, 0x00068480, None
        *   666 (0x029a),  (0x), GetNumaProximityNode, 0x00039a70, None
        667 (0x029b),  (0x), GetNumaProximityNodeEx, 0x0003b920, None
        668 (0x029c),  (0x), GetNumberFormatA, 0x0001b6b0, None
        669 (0x029d),  (0x), GetNumberFormatEx, 0x00021d80, None
        670 (0x029e),  (0x), GetNumberFormatW, 0x00001060, None
        *   0671 (0x029f),  (0x), GetNumberOfConsoleFonts, 0x0006ac80, None
        *   0672 (0x02a0),  (0x), GetNumberOfConsoleInputEvents, 0x00025ad0, None
        *   0673 (0x02a1),  (0x), GetNumberOfConsoleMouseButtons, 0x00025fa0, None
        674 (0x02a2),  (0x), GetOEMCP, 0x00021a80, None
        675 (0x02a3),  (0x), GetOverlappedResult, 0x0001ce80, None
        676 (0x02a4),  (0x), GetOverlappedResultEx, api-ms-win-core-io-l1-1-1.GetOverlappedResultEx, None
        677 (0x02a5),  (0x), GetPackageApplicationIds, kernelbase.GetPackageApplicationIds, None
        678 (0x02a6),  (0x), GetPackageFamilyName, kernelbase.GetPackageFamilyName, None
        679 (0x02a7),  (0x), GetPackageFullName, kernelbase.GetPackageFullName, None
        680 (0x02a8),  (0x), GetPackageId, kernelbase.GetPackageId, None
        681 (0x02a9),  (0x), GetPackageInfo, kernelbase.GetPackageInfo, None
        682 (0x02aa),  (0x), GetPackagePath, kernelbase.GetPackagePath, None
        683 (0x02ab),  (0x), GetPackagePathByFullName, kernelbase.GetPackagePathByFullName, None
        684 (0x02ac),  (0x), GetPackagesByPackageFamily, kernelbase.GetPackagesByPackageFamily, None
        685 (0x02ad),  (0x), GetPhysicallyInstalledSystemMemory, 0x00001270, None
        *   686 (0x02ae),  (0x), GetPriorityClass, 0x00021880, None
        687 (0x02af),  (0x), GetPrivateProfileIntA, 0x00015950, None
        688 (0x02b0),  (0x), GetPrivateProfileIntW, 0x000131b0, None
        689 (0x02b1),  (0x), GetPrivateProfileSectionA, 0x00023940, None
        690 (0x02b2),  (0x), GetPrivateProfileSectionNamesA, 0x00060cb0, None
        691 (0x02b3),  (0x), GetPrivateProfileSectionNamesW, 0x00060ce0, None
        692 (0x02b4),  (0x), GetPrivateProfileSectionW, 0x00021490, None
        693 (0x02b5),  (0x), GetPrivateProfileStringA, 0x00015840, None
        694 (0x02b6),  (0x), GetPrivateProfileStringW, 0x00012360, None
        695 (0x02b7),  (0x), GetPrivateProfileStructA, 0x00060d10, None
        696 (0x02b8),  (0x), GetPrivateProfileStructW, 0x00060eb0, None
        *   0697 (0x02b9),  (0x), GetProcAddress, 0x0001b690, None
        *   698 (0x02ba),  (0x), GetProcessAffinityMask, 0x0001c8d0, None
        *   699 (0x02bb),  (0x), GetProcessDEPPolicy, 0x0003a6a0, None
        700 (0x02bc),  (0x), GetProcessDefaultCpuSets, api-ms-win-core-processthreads-l1-1-3.GetProcessDefaultCpuSets, None
        701 (0x02bd),  (0x), GetProcessGroupAffinity, 0x0003b940, None
        *   702 (0x02be),  (0x), GetProcessHandleCount, 0x0003b960, None
        *   0703 (0x02bf),  (0x), GetProcessHeap, 0x00016190, None
        *   0704 (0x02c0),  (0x), GetProcessHeaps, 0x0003b980, None
        *   705 (0x02c1),  (0x), GetProcessId, 0x0001d790, None
        *   706 (0x02c2),  (0x), GetProcessIdOfThread, 0x00020fa0, None
        *   707 (0x02c3),  (0x), GetProcessInformation, 0x00025060, None
        *   708 (0x02c4),  (0x), GetProcessIoCounters, 0x00020580, None
        *   709 (0x02c5),  (0x), GetProcessMitigationPolicy, api-ms-win-core-processthreads-l1-1-1.GetProcessMitigationPolicy, None
        710 (0x02c6),  (0x), GetProcessPreferredUILanguages, 0x00024630, None
        *   711 (0x02c7),  (0x), GetProcessPriorityBoost, 0x0003b9a0, None
        *   712 (0x02c8),  (0x), GetProcessShutdownParameters, 0x0003b9c0, None
        *   713 (0x02c9),  (0x), GetProcessTimes, 0x0001b2a0, None
        *   714 (0x02ca),  (0x), GetProcessVersion, 0x00022860, None
        715 (0x02cb),  (0x), GetProcessWorkingSetSize, 0x00044690, None
        716 (0x02cc),  (0x), GetProcessWorkingSetSizeEx, 0x0003b9e0, None
        717 (0x02cd),  (0x), GetProcessorSystemCycleTime, api-ms-win-core-sysinfo-l1-2-2.GetProcessorSystemCycleTime, None
        718 (0x02ce),  (0x), GetProductInfo, 0x00021910, None
        719 (0x02cf),  (0x), GetProfileIntA, 0x000159c0, None
        720 (0x02d0),  (0x), GetProfileIntW, 0x00013520, None
        721 (0x02d1),  (0x), GetProfileSectionA, 0x00061060, None
        722 (0x02d2),  (0x), GetProfileSectionW, 0x00061070, None
        723 (0x02d3),  (0x), GetProfileStringA, 0x00061080, None
        724 (0x02d4),  (0x), GetProfileStringW, 0x000610b0, None
        725 (0x02d5),  (0x), GetQueuedCompletionStatus, 0x000163b0, None
        726 (0x02d6),  (0x), GetQueuedCompletionStatusEx, 0x0003ba00, None
        *   0727 (0x02d7),  (0x), GetShortPathNameA, 0x00061a90, None
        *   0728 (0x02d8),  (0x), GetShortPathNameW, 0x00006400, None
        729 (0x02d9),  (0x), GetStagedPackagePathByFullName, kernelbase.GetStagedPackagePathByFullName, None
        730 (0x02da),  (0x), GetStartupInfoA, 0x00022120, None
        *   731 (0x02db),  (0x), GetStartupInfoW, 0x0001dff0, None
        732 (0x02dc),  (0x), GetStateFolder, kernelbase.GetStateFolder, None
        *   0733 (0x02dd),  (0x), GetStdHandle, 0x0001dc50, None
        734 (0x02de),  (0x), GetStringScripts, 0x0003ba20, None
        735 (0x02df),  (0x), GetStringTypeA, 0x0003ba40, None
        736 (0x02e0),  (0x), GetStringTypeExA, 0x0003ba40, None
        737 (0x02e1),  (0x), GetStringTypeExW, 0x00022e30, None
        738 (0x02e2),  (0x), GetStringTypeW, 0x0001eaf0, None
        739 (0x02e3),  (0x), GetSystemAppDataKey, kernelbase.GetSystemAppDataKey, None
        740 (0x02e4),  (0x), GetSystemCpuSetInformation, api-ms-win-core-processthreads-l1-1-3.GetSystemCpuSetInformation, None
        *   741 (0x02e5),  (0x), GetSystemDEPPolicy, 0x0003a6f0, None
        742 (0x02e6),  (0x), GetSystemDefaultLCID, 0x00021470, None
        743 (0x02e7),  (0x), GetSystemDefaultLangID, 0x000217b0, None
        744 (0x02e8),  (0x), GetSystemDefaultLocaleName, 0x00001100, None
        745 (0x02e9),  (0x), GetSystemDefaultUILanguage, 0x00020e20, None
        746 (0x02ea),  (0x), GetSystemDirectoryA, 0x0001dba0, None
        747 (0x02eb),  (0x), GetSystemDirectoryW, 0x0001b5d0, None
        *   748 (0x02ec),  (0x), GetSystemFileCacheSize, 0x0003ba60, None
        749 (0x02ed),  (0x), GetSystemFirmwareTable, 0x00039150, None
        750 (0x02ee),  (0x), GetSystemInfo, 0x0001e370, None
        *   751 (0x02ef),  (0x), GetSystemPowerStatus, 0x00018390, None
        752 (0x02f0),  (0x), GetSystemPreferredUILanguages, 0x00021b00, None
        753 (0x02f1),  (0x), GetSystemRegistryQuota, 0x0003a730, None
        754 (0x02f2),  (0x), GetSystemTime, 0x0001bd50, None
        755 (0x02f3),  (0x), GetSystemTimeAdjustment, 0x00020f00, None
        756 (0x02f4),  (0x), GetSystemTimeAsFileTime, 0x00018350, None
        757 (0x02f5),  (0x), GetSystemTimePreciseAsFileTime, 0x00025800, None
        758 (0x02f6),  (0x), GetSystemTimes, 0x00020450, None
        759 (0x02f7),  (0x), GetSystemWindowsDirectoryA, 0x0003ba80, None
        760 (0x02f8),  (0x), GetSystemWindowsDirectoryW, 0x00009110, None
        761 (0x02f9),  (0x), GetSystemWow64DirectoryA, 0x00025970, None
        762 (0x02fa),  (0x), GetSystemWow64DirectoryW, 0x00025980, None
        *   763 (0x02fb),  (0x), GetTapeParameters, 0x00068650, None
        *   764 (0x02fc),  (0x), GetTapePosition, 0x00043cb0, None
        *   765 (0x02fd),  (0x), GetTapeStatus, 0x00043d40, None
        *   0766 (0x02fe),  (0x), GetTempFileNameA, 0x000255d0, None
        *   0767 (0x02ff),  (0x), GetTempFileNameW, 0x000255e0, None
        *   768 (0x0300),  (0x), GetTempPathA, 0x000255f0, None
        *   769 (0x0301),  (0x), GetTempPathW, 0x00025600, None
        770 (0x0302),  (0x), GetThreadContext, 0x00020d30, None
        *   771 (0x0303),  (0x), GetThreadDescription, api-ms-win-core-processthreads-l1-1-3.GetThreadDescription, None
        772 (0x0304),  (0x), GetThreadErrorMode, 0x0003ba90, None
        773 (0x0305),  (0x), GetThreadGroupAffinity, 0x0003bab0, None
        *   774 (0x0306),  (0x), GetThreadIOPendingFlag, 0x0003bad0, None
        *   775 (0x0307),  (0x), GetThreadId, 0x000213d0, None
        *   776 (0x0308),  (0x), GetThreadIdealProcessorEx, 0x0003baf0, None
        *   777 (0x0309),  (0x), GetThreadInformation, 0x00025070, None
        778 (0x030a),  (0x), GetThreadLocale, 0x0001a8c0, None
        779 (0x030b),  (0x), GetThreadPreferredUILanguages, 0x0001d870, None
        *   780 (0x030c),  (0x), GetThreadPriority, 0x0001c040, None
        *   781 (0x030d),  (0x), GetThreadPriorityBoost, 0x0003bb10, None
        782 (0x030e),  (0x), GetThreadSelectedCpuSets, api-ms-win-core-processthreads-l1-1-3.GetThreadSelectedCpuSets, None
        783 (0x030f),  (0x), GetThreadSelectorEntry, 0x000686b0, None
        *   784 (0x0310),  (0x), GetThreadTimes, 0x00016210, None
        785 (0x0311),  (0x), GetThreadUILanguage, 0x00024af0, None
        786 (0x0312),  (0x), GetTickCount, 0x00015c20, None
        787 (0x0313),  (0x), GetTickCount64, 0x00016310, None
        788 (0x0314),  (0x), GetTimeFormatA, 0x0003bb30, None
        789 (0x0315),  (0x), GetTimeFormatAWorker, 0x00024650, None
        790 (0x0316),  (0x), GetTimeFormatEx, 0x0003bb50, None
        791 (0x0317),  (0x), GetTimeFormatW, 0x0001f980, None
        792 (0x0318),  (0x), GetTimeFormatWWorker, 0x00009a80, None
        793 (0x0319),  (0x), GetTimeZoneInformation, 0x000210c0, None
        794 (0x031a),  (0x), GetTimeZoneInformationForYear, 0x00001070, None
        795 (0x031b),  (0x), GetUILanguageInfo, 0x0003bb70, None
        *   796 (0x031c),  (0x), GetUmsCompletionListEvent, 0x00042af0, None
        *   797 (0x031d),  (0x), GetUmsSystemThreadInformation, 0x00042b30, None
        798 (0x031e),  (0x), GetUserDefaultGeoName, 0x00054f60, None
        799 (0x031f),  (0x), GetUserDefaultLCID, 0x00020360, None
        800 (0x0320),  (0x), GetUserDefaultLangID, 0x0003bb90, None
        801 (0x0321),  (0x), GetUserDefaultLocaleName, 0x0001eb30, None
        802 (0x0322),  (0x), GetUserDefaultUILanguage, 0x000212f0, None
        803 (0x0323),  (0x), GetUserGeoID, 0x0001f9a0, None
        804 (0x0324),  (0x), GetUserPreferredUILanguages, 0x00020d50, None
        805 (0x0325),  (0x), GetVDMCurrentDirectories, 0x00041e20, None
        806 (0x0326),  (0x), GetVersion, 0x000217d0, None
        807 (0x0327),  (0x), GetVersionExA, 0x00020bc0, None
        808 (0x0328),  (0x), GetVersionExW, 0x00020140, None
        *   809 (0x0329),  (0x), GetVolumeInformationA, 0x00025610, None
        *   810 (0x032a),  (0x), GetVolumeInformationByHandleW, 0x00025620, None
        *   811 (0x032b),  (0x), GetVolumeInformationW, 0x00025630, None
        *   0812 (0x032c),  (0x), GetVolumeNameForVolumeMountPointA, 0x00024790, None
        *   0813 (0x032d),  (0x), GetVolumeNameForVolumeMountPointW, 0x00025030, None
        *   0814 (0x032e),  (0x), GetVolumePathNameA, 0x00066650, None
        *   0815 (0x032f),  (0x), GetVolumePathNameW, 0x00025640, None
        *   0816 (0x0330),  (0x), GetVolumePathNamesForVolumeNameA, 0x00066830, None
        *   0817 (0x0331),  (0x), GetVolumePathNamesForVolumeNameW, 0x00025650, None
        818 (0x0332),  (0x), GetWindowsDirectoryA, 0x000229f0, None
        819 (0x0333),  (0x), GetWindowsDirectoryW, 0x00023080, None
        *   820 (0x0334),  (0x), GetWriteWatch, 0x000161b0, None
        821 (0x0335),  (0x), GetXStateFeaturesMask, 0x0003bbb0, None
        *   0822 (0x0336),  (0x), GlobalAddAtomA, 0x00012660, None
        *   0823 (0x0337),  (0x), GlobalAddAtomExA, 0x0005a850, None
        *   0824 (0x0338),  (0x), GlobalAddAtomExW, 0x00013190, None
        *   0825 (0x0339),  (0x), GlobalAddAtomW, 0x00012910, None
        *   826 (0x033a),  (0x), GlobalAlloc, 0x000185e0, None
        827 (0x033b),  (0x), GlobalCompact, 0x00039170, None
        *   0828 (0x033c),  (0x), GlobalDeleteAtom, 0x00012850, None
        *   0829 (0x033d),  (0x), GlobalFindAtomA, 0x0005a870, None
        *   0830 (0x033e),  (0x), GlobalFindAtomW, 0x00012e00, None
        831 (0x033f),  (0x), GlobalFix, 0x00039190, None
        *   832 (0x0340),  (0x), GlobalFlags, 0x000201d0, None
        *   833 (0x0341),  (0x), GlobalFree, 0x00016130, None
        *   0834 (0x0342),  (0x), GlobalGetAtomNameA, 0x0005a890, None
        *   0835 (0x0343),  (0x), GlobalGetAtomNameW, 0x00012680, None
        *   836 (0x0344),  (0x), GlobalHandle, 0x000208b0, None
        *   837 (0x0345),  (0x), GlobalLock, 0x00015f70, None
        *   838 (0x0346),  (0x), GlobalMemoryStatus, 0x0001d0c0, None
        839 (0x0347),  (0x), GlobalMemoryStatusEx, 0x00020cf0, None
        *   840 (0x0348),  (0x), GlobalReAlloc, 0x00017190, None
        *   841 (0x0349),  (0x), GlobalSize, 0x00018600, None
        842 (0x034a),  (0x), GlobalUnWire, 0x000391b0, None
        843 (0x034b),  (0x), GlobalUnfix, 0x000391c0, None
        *   844 (0x034c),  (0x), GlobalUnlock, 0x00015e90, None
        845 (0x034d),  (0x), GlobalWire, 0x000391e0, None
        *   0846 (0x034e),  (0x), Heap32First, 0x00064860, None
        *   0847 (0x034f),  (0x), Heap32ListFirst, 0x00064b00, None
        *   0848 (0x0350),  (0x), Heap32ListNext, 0x00064c00, None
        *   0849 (0x0351),  (0x), Heap32Next, 0x00064d00, None
        *   0850 (0x0352),  (0x), HeapAlloc, NTDLL.RtlAllocateHeap, None
        *   0851 (0x0353),  (0x), HeapCompact, 0x0003bbd0, None
        *   0852 (0x0354),  (0x), HeapCreate, 0x00020710, None
        *   0853 (0x0355),  (0x), HeapDestroy, 0x00021a60, None
        *   0854 (0x0356),  (0x), HeapFree, 0x00015b50, None
        *   0855 (0x0357),  (0x), HeapLock, 0x0003bbf0, None
        *   0856 (0x0358),  (0x), HeapQueryInformation, 0x0003bc10, None
        *   0857 (0x0359),  (0x), HeapReAlloc, NTDLL.RtlReAllocateHeap, None
        *   0858 (0x035a),  (0x), HeapSetInformation, 0x00020ba0, None
        *   0859 (0x035b),  (0x), HeapSize, NTDLL.RtlSizeHeap, None
        *   0860 (0x035c),  (0x), HeapSummary, 0x0003bc30, None
        *   0861 (0x035d),  (0x), HeapUnlock, 0x0003bc50, None
        *   0862 (0x035e),  (0x), HeapValidate, 0x0001c8b0, None
        *   0863 (0x035f),  (0x), HeapWalk, 0x0003bc70, None
        864 (0x0360),  (0x), IdnToAscii, 0x00001090, None
        865 (0x0361),  (0x), IdnToNameprepUnicode, 0x0003bc90, None
        866 (0x0362),  (0x), IdnToUnicode, 0x0003bcb0, None
        *   0867 (0x0363),  (0x), InitAtomTable, 0x0005a8c0, None
        *   0868 (0x0364),  (0x), InitOnceBeginInitialize, api-ms-win-core-synch-l1-2-0.InitOnceBeginInitialize, None
        *   0869 (0x0365),  (0x), InitOnceComplete, api-ms-win-core-synch-l1-2-0.InitOnceComplete, None
        *   0870 (0x0366),  (0x), InitOnceExecuteOnce, api-ms-win-core-synch-l1-2-0.InitOnceExecuteOnce, None
        *   0871 (0x0367),  (0x), InitOnceInitialize, NTDLL.RtlRunOnceInitialize, None
        *   0872 (0x0368),  (0x), InitializeConditionVariable, NTDLL.RtlInitializeConditionVariable, None
        873 (0x0369),  (0x), InitializeContext, 0x0003bcf0, None
        874 (0x036a),  (0x), InitializeContext2, 0x0003bcd0, None
        *   0875 (0x036b),  (0x), InitializeCriticalSection, NTDLL.RtlInitializeCriticalSection, None
        *   0876 (0x036c),  (0x), InitializeCriticalSectionAndSpinCount, 0x000251a0, None
        *   0877 (0x036d),  (0x), InitializeCriticalSectionEx, 0x000251b0, None
        878 (0x036e),  (0x), InitializeEnclave, api-ms-win-core-enclave-l1-1-0.InitializeEnclave, None
        *   879 (0x036f),  (0x), InitializeProcThreadAttributeList, api-ms-win-core-processthreads-l1-1-0.InitializeProcThreadAttributeList, None
        880 (0x0370),  (0x), InitializeSListHead, NTDLL.RtlInitializeSListHead, None
        *881 (0x0371),  (0x), InitializeSRWLock, NTDLL.RtlInitializeSRWLock, None
        *882 (0x0372),  (0x), InitializeSynchronizationBarrier, 0x0003bd10, None
        883 (0x0373),  (0x), InstallELAMCertificateInfo, api-ms-win-core-sysinfo-l1-2-1.InstallELAMCertificateInfo, None
        884 (0x0374),  (0x), InterlockedFlushSList, NTDLL.RtlInterlockedFlushSList, None
        885 (0x0375),  (0x), InterlockedPopEntrySList, NTDLL.RtlInterlockedPopEntrySList, None
        886 (0x0376),  (0x), InterlockedPushEntrySList, NTDLL.RtlInterlockedPushEntrySList, None
        887 (0x0377),  (0x), InterlockedPushListSList, NTDLL.RtlInterlockedPushListSList, None
        888 (0x0378),  (0x), InterlockedPushListSListEx, NTDLL.RtlInterlockedPushListSListEx, None
        889 (0x0379),  (0x), InvalidateConsoleDIBits, 0x0006ada0, None
        *   890 (0x037a),  (0x), IsBadCodePtr, 0x0003a7c0, None
        891 (0x037b),  (0x), IsBadHugeReadPtr, 0x0003a7d0, None
        892 (0x037c),  (0x), IsBadHugeWritePtr, 0x0003a7e0, None
        *   893 (0x037d),  (0x), IsBadReadPtr, 0x00016080, None
        *   894 (0x037e),  (0x), IsBadStringPtrA, 0x0003a7f0, None
        *   895 (0x037f),  (0x), IsBadStringPtrW, 0x0003a840, None
        *   896 (0x0380),  (0x), IsBadWritePtr, 0x000671b0, None
        897 (0x0381),  (0x), IsCalendarLeapDay, 0x0004b700, None
        898 (0x0382),  (0x), IsCalendarLeapMonth, 0x0004b7e0, None
        899 (0x0383),  (0x), IsCalendarLeapYear, 0x0004b8d0, None
        900 (0x0384),  (0x), IsDBCSLeadByte, 0x00022100, None
        901 (0x0385),  (0x), IsDBCSLeadByteEx, 0x0003bd30, None
        902 (0x0386),  (0x), IsDebuggerPresent, 0x00020970, None
        903 (0x0387),  (0x), IsEnclaveTypeSupported, api-ms-win-core-enclave-l1-1-0.IsEnclaveTypeSupported, None
        904 (0x0388),  (0x), IsNLSDefinedString, 0x0003bd50, None
        905 (0x0389),  (0x), IsNativeVhdBoot, 0x00037ff0, None
        906 (0x038a),  (0x), IsNormalizedString, 0x0003bd70, None
        *   907 (0x038b),  (0x), IsProcessCritical, api-ms-win-core-processthreads-l1-1-2.IsProcessCritical, None
        908 (0x038c),  (0x), IsProcessInJob, 0x00021080, None
        909 (0x038d),  (0x), IsProcessorFeaturePresent, 0x0001e300, None
        *   910 (0x038e),  (0x), IsSystemResumeAutomatic, 0x00039cc0, None
        911 (0x038f),  (0x), IsThreadAFiber, 0x0001d8b0, None
        912 (0x0390),  (0x), IsThreadpoolTimerSet, NTDLL.TpIsTimerSet, None
        913 (0x0391),  (0x), IsUserCetAvailableInEnvironment, api-ms-win-core-sysinfo-l1-2-6.IsUserCetAvailableInEnvironment, None
        914 (0x0392),  (0x), IsValidCalDateTime, 0x000082b0, None
        915 (0x0393),  (0x), IsValidCodePage, 0x00020430, None
        916 (0x0394),  (0x), IsValidLanguageGroup, 0x0003bd90, None
        917 (0x0395),  (0x), IsValidLocale, 0x00020660, None
        918 (0x0396),  (0x), IsValidLocaleName, 0x0003bdb0, None
        919 (0x0397),  (0x), IsValidNLSVersion, 0x0003bdd0, None
        920 (0x0398),  (0x), IsWow64GuestMachineSupported, api-ms-win-core-wow64-l1-1-2.IsWow64GuestMachineSupported, None
        921 (0x0399),  (0x), IsWow64Process, 0x0001fe30, None
        922 (0x039a),  (0x), IsWow64Process2, api-ms-win-core-wow64-l1-1-1.IsWow64Process2, None
        923 (0x039b),  (0x), K32EmptyWorkingSet, 0x0003bdf0, None
        924 (0x039c),  (0x), K32EnumDeviceDrivers, 0x0003be10, None
        925 (0x039d),  (0x), K32EnumPageFilesA, 0x0003be30, None
        926 (0x039e),  (0x), K32EnumPageFilesW, 0x0003be50, None
        927 (0x039f),  (0x), K32EnumProcessModules, 0x000218a0, None
        928 (0x03a0),  (0x), K32EnumProcessModulesEx, 0x0003be70, None
        929 (0x03a1),  (0x), K32EnumProcesses, 0x0003be90, None
        930 (0x03a2),  (0x), K32GetDeviceDriverBaseNameA, 0x0003beb0, None
        931 (0x03a3),  (0x), K32GetDeviceDriverBaseNameW, 0x0003bed0, None
        932 (0x03a4),  (0x), K32GetDeviceDriverFileNameA, 0x0003bef0, None
        933 (0x03a5),  (0x), K32GetDeviceDriverFileNameW, 0x0003bf10, None
        934 (0x03a6),  (0x), K32GetMappedFileNameA, 0x0003bf30, None
        935 (0x03a7),  (0x), K32GetMappedFileNameW, 0x0003bf50, None
        936 (0x03a8),  (0x), K32GetModuleBaseNameA, 0x0003bf70, None
        937 (0x03a9),  (0x), K32GetModuleBaseNameW, 0x0003bf90, None
        938 (0x03aa),  (0x), K32GetModuleFileNameExA, 0x0003bfb0, None
        939 (0x03ab),  (0x), K32GetModuleFileNameExW, 0x00024ab0, None
        940 (0x03ac),  (0x), K32GetModuleInformation, 0x0001f890, None
        941 (0x03ad),  (0x), K32GetPerformanceInfo, 0x0003bfd0, None
        942 (0x03ae),  (0x), K32GetProcessImageFileNameA, 0x0003bff0, None
        943 (0x03af),  (0x), K32GetProcessImageFileNameW, 0x00020820, None
        944 (0x03b0),  (0x), K32GetProcessMemoryInfo, 0x0003c010, None
        945 (0x03b1),  (0x), K32GetWsChanges, 0x0003c050, None
        946 (0x03b2),  (0x), K32GetWsChangesEx, 0x0003c030, None
        947 (0x03b3),  (0x), K32InitializeProcessForWsWatch, 0x0003c070, None
        948 (0x03b4),  (0x), K32QueryWorkingSet, 0x0003c0b0, None
        949 (0x03b5),  (0x), K32QueryWorkingSetEx, 0x0003c090, None
        950 (0x03b6),  (0x), LCIDToLocaleName, 0x00020e00, None
        951 (0x03b7),  (0x), LCMapStringA, 0x0003c0d0, None
        952 (0x03b8),  (0x), LCMapStringEx, 0x000162b0, None
        953 (0x03b9),  (0x), LCMapStringW, 0x00018c70, None
        954 (0x03ba),  (0x), LZClose, 0x0003d780, None
        955 (0x03bb),  (0x), LZCloseFile, 0x0003d840, None
        956 (0x03bc),  (0x), LZCopy, 0x00038120, None
        957 (0x03bd),  (0x), LZCreateFileW, 0x0003d910, None
        958 (0x03be),  (0x), LZDone, 0x00038220, None
        959 (0x03bf),  (0x), LZInit, 0x0003da50, None
        960 (0x03c0),  (0x), LZOpenFileA, 0x0003dc00, None
        961 (0x03c1),  (0x), LZOpenFileW, 0x0003dcf0, None
        962 (0x03c2),  (0x), LZRead, 0x0003ddb0, None
        963 (0x03c3),  (0x), LZSeek, 0x0003e020, None
        964 (0x03c4),  (0x), LZStart, 0x00021ba0, None
        *   0965 (0x03c5),  (0x), LeaveCriticalSection, NTDLL.RtlLeaveCriticalSection, None
        *   0966 (0x03c6),  (0x), LeaveCriticalSectionWhenCallbackReturns, NTDLL.TpCallbackLeaveCriticalSectionOnCompletion, None
        967 (0x03c7),  (0x), LoadAppInitDlls, 0x00018760, None
        968 (0x03c8),  (0x), LoadEnclaveData, api-ms-win-core-enclave-l1-1-0.LoadEnclaveData, None
        *   0969 (0x03c9),  (0x), LoadLibraryA, 0x00020cb0, None
        *   0970 (0x03ca),  (0x), LoadLibraryExA, 0x00020380, None
        *   0971 (0x03cb),  (0x), LoadLibraryExW, 0x0001b590, None
        *   0972 (0x03cc),  (0x), LoadLibraryW, 0x000206a0, None
        *   973 (0x03cd),  (0x), LoadModule, 0x00067240, None
        *   974 (0x03ce),  (0x), LoadPackagedLibrary, 0x000257e0, None
        975 (0x03cf),  (0x), LoadResource, 0x0001bb30, None
        976 (0x03d0),  (0x), LoadStringBaseExW, 0x0003c0f0, None
        977 (0x03d1),  (0x), LoadStringBaseW, 0x00039320, None
        *   978 (0x03d2),  (0x), LocalAlloc, 0x00018c90, None
        979 (0x03d3),  (0x), LocalCompact, 0x00039170, None
        980 (0x03d4),  (0x), LocalFileTimeToFileTime, 0x00025660, None
        981 (0x03d5),  (0x), LocalFileTimeToLocalSystemTime, api-ms-win-core-timezone-l1-1-1.LocalFileTimeToLocalSystemTime, None
        *   982 (0x03d6),  (0x), LocalFlags, 0x000686d0, None
        *   983 (0x03d7),  (0x), LocalFree, 0x00018330, None
        *   984 (0x03d8),  (0x), LocalHandle, 0x00039220, None
        *   985 (0x03d9),  (0x), LocalLock, 0x0003c110, None
        *   986 (0x03da),  (0x), LocalReAlloc, 0x00020520, None
        987 (0x03db),  (0x), LocalShrink, 0x00039170, None
        *   988 (0x03dc),  (0x), LocalSize, 0x0001bbf0, None
        989 (0x03dd),  (0x), LocalSystemTimeToLocalFileTime, api-ms-win-core-timezone-l1-1-1.LocalSystemTimeToLocalFileTime, None
        *   990 (0x03de),  (0x), LocalUnlock, 0x0003c130, None
        991 (0x03df),  (0x), LocaleNameToLCID, 0x0001e840, None
        992 (0x03e0),  (0x), LocateXStateFeature, 0x0003c150, None
        993 (0x03e1),  (0x), LockFile, 0x00025670, None
        994 (0x03e2),  (0x), LockFileEx, 0x00025680, None
        995 (0x03e3),  (0x), LockResource, 0x0001bb90, None
        *   996 (0x03e4),  (0x), MapUserPhysicalPages, 0x0003c170, None
        *   997 (0x03e5),  (0x), MapUserPhysicalPagesScatter, 0x000446c0, None
        *   998 (0x03e6),  (0x), MapViewOfFile, 0x0001dfb0, None
        *   999 (0x03e7),  (0x), MapViewOfFileEx, 0x0001d1b0, None
        *   1000 (0x03e8),  (0x), MapViewOfFileExNuma, 0x0003c190, None
        *   1001 (0x03e9),  (0x), MapViewOfFileFromApp, api-ms-win-core-memory-l1-1-1.MapViewOfFileFromApp, None
        *   1002 (0x03ea),  (0x), Module32First, 0x00064fb0, None
        *   1003 (0x03eb),  (0x), Module32FirstW, 0x0001e390, None
        *   1004 (0x03ec),  (0x), Module32Next, 0x000650f0, None
        *   1005 (0x03ed),  (0x), Module32NextW, 0x0001a770, None
        *   1006 (0x03ee),  (0x), MoveFileA, 0x00064020, None
        *   1007 (0x03ef),  (0x), MoveFileExA, 0x00064050, None
        *   1008 (0x03f0),  (0x), MoveFileExW, 0x00021450, None
        *   1009 (0x03f1),  (0x), MoveFileTransactedA, 0x00064080, None
        *   1010 (0x03f2),  (0x), MoveFileTransactedW, 0x00024570, None
        *   1011 (0x03f3),  (0x), MoveFileW, 0x00023050, None
        *   1012 (0x03f4),  (0x), MoveFileWithProgressA, 0x00064160, None
        *   1013 (0x03f5),  (0x), MoveFileWithProgressW, 0x0003c1b0, None
        1014 (0x03f6),  (0x), MulDiv, 0x000257c0, None
        1015 (0x03f7),  (0x), MultiByteToWideChar, 0x00015df0, None
        1016 (0x03f8),  (0x), NeedCurrentDirectoryForExePathA, 0x0003c1d0, None
        1017 (0x03f9),  (0x), NeedCurrentDirectoryForExePathW, 0x0003c1f0, None
        1018 (0x03fa),  (0x), NlsCheckPolicy, 0x00025a10, None
        1019 (0x03fb),  (0x), NlsGetCacheUpdateCount, 0x00025a20, None
        1020 (0x03fc),  (0x), NlsUpdateLocale, 0x00025a30, None
        1021 (0x03fd),  (0x), NlsUpdateSystemLocale, 0x00025a40, None
        1022 (0x03fe),  (0x), NormalizeString, 0x0003c210, None
        1023 (0x03ff),  (0x), NotifyMountMgr, 0x0003c230, None
        1024 (0x0400),  (0x), NotifyUILanguageChange, 0x0004eab0, None
        1025 (0x0401),  (0x), NtVdm64CreateProcessInternalW, 0x0003a8a0, None
        1026 (0x0402),  (0x), OOBEComplete, 0x0001f240, None
        *   1027 (0x0403),  (0x), OfferVirtualMemory, api-ms-win-core-memory-l1-1-2.OfferVirtualMemory, None
        1028 (0x0404),  (0x), OpenConsoleW, 0x0006a1b0, None
        1029 (0x0405),  (0x), OpenConsoleWStub, 0x0003c250, None
        *   1030 (0x0406),  (0x), OpenEventA, 0x000251c0, None
        *   1031 (0x0407),  (0x), OpenEventW, 0x000251d0, None
        *   1032 (0x0408),  (0x), OpenFile, 0x00062b50, None
        *   1033 (0x0409),  (0x), OpenFileById, 0x0003c260, None
        1034 (0x040a),  (0x), OpenFileMappingA, 0x00021dd0, None
        *   1035 (0x040b),  (0x), OpenFileMappingW, 0x00020ee0, None
        *   1036 (0x040c),  (0x), OpenJobObjectA, 0x0005c9e0, None
        1037 (0x040d),  (0x), OpenJobObjectW, 0x0005ca60, None
        *   1038 (0x040e),  (0x), OpenMutexA, 0x0001c7e0, None
        *   1039 (0x040f),  (0x), OpenMutexW, 0x000251e0, None
        1040 (0x0410),  (0x), OpenPackageInfoByFullName, kernelbase.OpenPackageInfoByFullName, None
        1041 (0x0411),  (0x), OpenPrivateNamespaceA, 0x000624e0, None
        1042 (0x0412),  (0x), OpenPrivateNamespaceW, 0x00022a50, None
        *   1043 (0x0413),  (0x), OpenProcess, 0x0001b5b0, None
        1044 (0x0414),  (0x), OpenProcessToken, api-ms-win-core-processthreads-l1-1-0.OpenProcessToken, None
        1045 (0x0415),  (0x), OpenProfileUserMapping, 0x00021ba0, None
        *   1046 (0x0416),  (0x), OpenSemaphoreA, 0x00063820, None
        *   1047 (0x0417),  (0x), OpenSemaphoreW, 0x000251f0, None
        1048 (0x0418),  (0x), OpenState, kernelbase.OpenState, None
        1049 (0x0419),  (0x), OpenStateExplicit, kernelbase.OpenStateExplicit, None
        *   1050 (0x041a),  (0x), OpenThread, 0x0001d010, None
        1051 (0x041b),  (0x), OpenThreadToken, api-ms-win-core-processthreads-l1-1-0.OpenThreadToken, None
        *   1052 (0x041c),  (0x), OpenWaitableTimerA, 0x00063890, None
        *   1053 (0x041d),  (0x), OpenWaitableTimerW, 0x00025200, None
        1054 (0x041e),  (0x), OutputDebugStringA, 0x00024a90, None
        1055 (0x041f),  (0x), OutputDebugStringW, 0x0001d8d0, None
        1056 (0x0420),  (0x), PackageFamilyNameFromFullName, kernelbase.PackageFamilyNameFromFullName, None
        1057 (0x0421),  (0x), PackageFamilyNameFromId, kernelbase.PackageFamilyNameFromId, None
        1058 (0x0422),  (0x), PackageFullNameFromId, kernelbase.PackageFullNameFromId, None
        1059 (0x0423),  (0x), PackageIdFromFullName, kernelbase.PackageIdFromFullName, None
        1060 (0x0424),  (0x), PackageNameAndPublisherIdFromFamilyName, kernelbase.PackageNameAndPublisherIdFromFamilyName, None
        1061 (0x0425),  (0x), ParseApplicationUserModelId, kernelbase.ParseApplicationUserModelId, None
        *   1062 (0x0426),  (0x), PeekConsoleInputA, 0x00025ae0, None
        *   1063 (0x0427),  (0x), PeekConsoleInputW, 0x00025af0, None
        1064 (0x0428),  (0x), PeekNamedPipe, 0x0003c280, None
        1065 (0x0429),  (0x), PostQueuedCompletionStatus, 0x0001bb70, None
        1066 (0x042a),  (0x), PowerClearRequest, 0x00020490, None
        1067 (0x042b),  (0x), PowerCreateRequest, 0x0001f5c0, None
        1068 (0x042c),  (0x), PowerSetRequest, 0x000203a0, None
        *   1069 (0x042d),  (0x), PrefetchVirtualMemory, api-ms-win-core-memory-l1-1-1.PrefetchVirtualMemory, None
        *   1070 (0x042e),  (0x), PrepareTape, 0x00043d70, None
        1071 (0x042f),  (0x), PrivCopyFileExW, 0x00022df0, None
        1072 (0x0430),  (0x), PrivMoveFileIdentityW, 0x00064270, None
        *   1073 (0x0431),  (0x), Process32First, 0x00065220, None
        *   1074 (0x0432),  (0x), Process32FirstW, 0x00022e50, None
        *   1075 (0x0433),  (0x), Process32Next, 0x00065320, None
        *   1076 (0x0434),  (0x), Process32NextW, 0x00022bf0, None
        1077 (0x0435),  (0x), ProcessIdToSessionId, 0x0001cfb0, None
        1078 (0x0436),  (0x), PssCaptureSnapshot, 0x0003c2a0, None
        1079 (0x0437),  (0x), PssDuplicateSnapshot, 0x0003c2c0, None
        1080 (0x0438),  (0x), PssFreeSnapshot, 0x0003c2e0, None
        1081 (0x0439),  (0x), PssQuerySnapshot, 0x0003c300, None
        1082 (0x043a),  (0x), PssWalkMarkerCreate, 0x0003c320, None
        1083 (0x043b),  (0x), PssWalkMarkerFree, 0x0003c340, None
        1084 (0x043c),  (0x), PssWalkMarkerGetPosition, 0x0003c360, None
        1085 (0x043d),  (0x), PssWalkMarkerRewind, 0x0003c380, None
        1086 (0x043e),  (0x), PssWalkMarkerSeek, 0x0003c3a0, None
        1087 (0x043f),  (0x), PssWalkMarkerSeekToBeginning, 0x0003c380, None
        1088 (0x0440),  (0x), PssWalkMarkerSetPosition, 0x0003c3a0, None
        1089 (0x0441),  (0x), PssWalkMarkerTell, 0x0003c360, None
        1090 (0x0442),  (0x), PssWalkSnapshot, 0x0003c3c0, None
        *   1091 (0x0443),  (0x), PulseEvent, 0x0001ca70, None
        1092 (0x0444),  (0x), PurgeComm, 0x000258e0, None
        *   1093 (0x0445),  (0x), QueryActCtxSettingsW, 0x0003c3e0, None
        *   1094 (0x0446),  (0x), QueryActCtxSettingsWWorker, 0x00012b70, None
        *   1095 (0x0447),  (0x), QueryActCtxW, 0x0001e760, None
        *   1096 (0x0448),  (0x), QueryActCtxWWorker, 0x000124d0, None
        1097 (0x0449),  (0x), QueryDepthSList, NTDLL.RtlQueryDepthSList, None
        *   1098 (0x044a),  (0x), QueryDosDeviceA, 0x000654c0, None
        *   1099 (0x044b),  (0x), QueryDosDeviceW, 0x00025690, None
        *   1100 (0x044c),  (0x), QueryFullProcessImageNameA, 0x0003c400, None
        *   1101 (0x044d),  (0x), QueryFullProcessImageNameW, 0x0001d030, None
        1102 (0x044e),  (0x), QueryIdleProcessorCycleTime, 0x000226c0, None
        1103 (0x044f),  (0x), QueryIdleProcessorCycleTimeEx, 0x0003c420, None
        1104 (0x0450),  (0x), QueryInformationJobObject, 0x0001e010, None
        1105 (0x0451),  (0x), QueryIoRateControlInformationJobObject, 0x0005cb30, None
        *   1106 (0x0452),  (0x), QueryMemoryResourceNotification, 0x0003c440, None
        *   1107 (0x0453),  (0x), QueryPerformanceCounter, 0x000161f0, None
        *   1108 (0x0454),  (0x), QueryPerformanceFrequency, 0x0001b670, None
        *   1109 (0x0455),  (0x), QueryProcessAffinityUpdateMode, 0x0003c460, None
        1110 (0x0456),  (0x), QueryProcessCycleTime, 0x000226e0, None
        *   1111 (0x0457),  (0x), QueryProtectedPolicy, api-ms-win-core-processthreads-l1-1-2.QueryProtectedPolicy, None
        1112 (0x0458),  (0x), QueryThreadCycleTime, 0x000010e0, None
        1113 (0x0459),  (0x), QueryThreadProfiling, 0x00044870, None
        1114 (0x045a),  (0x), QueryThreadpoolStackInformation, 0x0003c480, None
        *   1115 (0x045b),  (0x), QueryUmsThreadInformation, 0x00042bb0, None
        1116 (0x045c),  (0x), QueryUnbiasedInterruptTime, 0x0001d890, None
        *   1117 (0x045d),  (0x), QueueUserAPC, 0x0001e8a0, None
        1118 (0x045e),  (0x), QueueUserWorkItem, 0x00021770, None
        1119 (0x045f),  (0x), QuirkGetData2Worker, 0x00071690, None
        1120 (0x0460),  (0x), QuirkGetDataWorker, 0x00071760, None
        1121 (0x0461),  (0x), QuirkIsEnabled2Worker, 0x00071820, None
        1122 (0x0462),  (0x), QuirkIsEnabled3Worker, 0x00016340, None
        1123 (0x0463),  (0x), QuirkIsEnabledForPackage2Worker, 0x00071970, None
        1124 (0x0464),  (0x), QuirkIsEnabledForPackage3Worker, 0x00009c60, None
        1125 (0x0465),  (0x), QuirkIsEnabledForPackage4Worker, 0x00009dd0, None
        1126 (0x0466),  (0x), QuirkIsEnabledForPackageWorker, 0x00009060, None
        1127 (0x0467),  (0x), QuirkIsEnabledForProcessWorker, 0x0001fba0, None
        1128 (0x0468),  (0x), QuirkIsEnabledWorker, 0x00009120, None
        1129 (0x0469),  (0x), RaiseException, 0x00020470, None
        1130 (0x046a),  (0x), RaiseFailFastException, kernelbase.RaiseFailFastException, None
        1131 (0x046b),  (0x), RaiseInvalid16BitExeError, 0x0003aab0, None
        1132 (0x046c),  (0x), ReOpenFile, 0x0003c4c0, None
        *   1133 (0x046d),  (0x), ReadConsoleA, 0x00025b00, None
        *   1134 (0x046e),  (0x), ReadConsoleInputA, 0x00025b10, None
        *   1135 (0x046f),  (0x), ReadConsoleInputExA, kernelbase.ReadConsoleInputExA, None
        *   1136 (0x0470),  (0x), ReadConsoleInputExW, kernelbase.ReadConsoleInputExW, None
        *   1137 (0x0471),  (0x), ReadConsoleInputW, 0x00025b20, None
        *   1138 (0x0472),  (0x), ReadConsoleOutputA, 0x00025c70, None
        *   1139 (0x0473),  (0x), ReadConsoleOutputAttribute, 0x00025c80, None
        *   1140 (0x0474),  (0x), ReadConsoleOutputCharacterA, 0x00025c90, None
        *   1141 (0x0475),  (0x), ReadConsoleOutputCharacterW, 0x00025ca0, None
        *   1142 (0x0476),  (0x), ReadConsoleOutputW, 0x00025cb0, None
        *   1143 (0x0477),  (0x), ReadConsoleW, 0x00025b30, None
        *   1144 (0x0478),  (0x), ReadDirectoryChangesExW, 0x0003c4e0, None
        *   1145 (0x0479),  (0x), ReadDirectoryChangesW, 0x00024a70, None
        1146 (0x047a),  (0x), ReadFile, 0x000256a0, None
        1147 (0x047b),  (0x), ReadFileEx, 0x000256b0, None
        1148 (0x047c),  (0x), ReadFileScatter, 0x000256c0, None
        1149 (0x047d),  (0x), ReadProcessMemory, 0x0001ccb0, None
        1150 (0x047e),  (0x), ReadThreadProfilingData, 0x000448b0, None
        *   1151 (0x047f),  (0x), ReclaimVirtualMemory, api-ms-win-core-memory-l1-1-2.ReclaimVirtualMemory, None
        1152 (0x0480),  (0x), RegCloseKey, 0x000249e0, None
        1153 (0x0481),  (0x), RegCopyTreeW, 0x0003c500, None
        1154 (0x0482),  (0x), RegCreateKeyExA, 0x0003c520, None
        1155 (0x0483),  (0x), RegCreateKeyExW, 0x0003c540, None
        1156 (0x0484),  (0x), RegDeleteKeyExA, 0x0003c560, None
        1157 (0x0485),  (0x), RegDeleteKeyExW, 0x0003c580, None
        1158 (0x0486),  (0x), RegDeleteTreeA, 0x0003c5a0, None
        1159 (0x0487),  (0x), RegDeleteTreeW, 0x0003c5c0, None
        1160 (0x0488),  (0x), RegDeleteValueA, 0x0003c5e0, None
        1161 (0x0489),  (0x), RegDeleteValueW, 0x0003c600, None
        1162 (0x048a),  (0x), RegDisablePredefinedCacheEx, 0x0003c620, None
        1163 (0x048b),  (0x), RegEnumKeyExA, 0x0003c640, None
        1164 (0x048c),  (0x), RegEnumKeyExW, 0x0003c690, None
        1165 (0x048d),  (0x), RegEnumValueA, 0x0003c6e0, None
        1166 (0x048e),  (0x), RegEnumValueW, 0x0003c730, None
        1167 (0x048f),  (0x), RegFlushKey, 0x0003c780, None
        1168 (0x0490),  (0x), RegGetKeySecurity, 0x0003c7a0, None
        1169 (0x0491),  (0x), RegGetValueA, 0x0003c7c0, None
        1170 (0x0492),  (0x), RegGetValueW, 0x000225b0, None
        1171 (0x0493),  (0x), RegLoadKeyA, 0x0003c7e0, None
        1172 (0x0494),  (0x), RegLoadKeyW, 0x0003c800, None
        1173 (0x0495),  (0x), RegLoadMUIStringA, 0x0003c820, None
        1174 (0x0496),  (0x), RegLoadMUIStringW, 0x0003c840, None
        1175 (0x0497),  (0x), RegNotifyChangeKeyValue, 0x0003c860, None
        1176 (0x0498),  (0x), RegOpenCurrentUser, 0x00022a90, None
        1177 (0x0499),  (0x), RegOpenKeyExA, 0x0003c880, None
        1178 (0x049a),  (0x), RegOpenKeyExW, 0x000211c0, None
        1179 (0x049b),  (0x), RegOpenUserClassesRoot, 0x00022a70, None
        1180 (0x049c),  (0x), RegQueryInfoKeyA, 0x0003c8a0, None
        1181 (0x049d),  (0x), RegQueryInfoKeyW, 0x0003c920, None
        1182 (0x049e),  (0x), RegQueryValueExA, 0x0003c9a0, None
        1183 (0x049f),  (0x), RegQueryValueExW, 0x0003c9c0, None
        1184 (0x04a0),  (0x), RegRestoreKeyA, 0x0003c9e0, None
        1185 (0x04a1),  (0x), RegRestoreKeyW, 0x0003ca00, None
        1186 (0x04a2),  (0x), RegSaveKeyExA, 0x0003ca20, None
        1187 (0x04a3),  (0x), RegSaveKeyExW, 0x0003ca40, None
        1188 (0x04a4),  (0x), RegSetKeySecurity, 0x0003ca60, None
        1189 (0x04a5),  (0x), RegSetValueExA, 0x0003ca80, None
        1190 (0x04a6),  (0x), RegSetValueExW, 0x0003caa0, None
        1191 (0x04a7),  (0x), RegUnLoadKeyA, 0x0003cac0, None
        1192 (0x04a8),  (0x), RegUnLoadKeyW, 0x0003cae0, None
        1193 (0x04a9),  (0x), RegisterApplicationRecoveryCallback, 0x00021e50, None
        1194 (0x04aa),  (0x), RegisterApplicationRestart, 0x00021ae0, None
        *   1195 (0x04ab),  (0x), RegisterBadMemoryNotification, 0x0003cb00, None
        1196 (0x04ac),  (0x), RegisterConsoleIME, 0x0006a880, None
        1197 (0x04ad),  (0x), RegisterConsoleOS2, 0x0006a8b0, None
        1198 (0x04ae),  (0x), RegisterConsoleVDM, 0x0006a2f0, None
        1199 (0x04af),  (0x), RegisterWaitForInputIdle, 0x000201a0, None
        *   1200 (0x04b0),  (0x), RegisterWaitForSingleObject, 0x00015ab0, None
        1201 (0x04b1),  (0x), RegisterWaitForSingleObjectEx, 0x0003cb20, None
        1202 (0x04b2),  (0x), RegisterWaitUntilOOBECompleted, 0x0001f180, None
        1203 (0x04b3),  (0x), RegisterWowBaseHandlers, 0x000391f0, None
        1204 (0x04b4),  (0x), RegisterWowExec, 0x000423b0, None
        *   1205 (0x04b5),  (0x), ReleaseActCtx, 0x000219e0, None
        *   1206 (0x04b6),  (0x), ReleaseActCtxWorker, 0x0001dfd0, None
        *   1207 (0x04b7),  (0x), ReleaseMutex, 0x00025210, None
        *   1208 (0x04b8),  (0x), ReleaseMutexWhenCallbackReturns, NTDLL.TpCallbackReleaseMutexOnCompletion, None
        *   1209 (0x04b9),  (0x), ReleaseSRWLockExclusive, NTDLL.RtlReleaseSRWLockExclusive, None
        *   1210 (0x04ba),  (0x), ReleaseSRWLockShared, NTDLL.RtlReleaseSRWLockShared, None
        *   1211 (0x04bb),  (0x), ReleaseSemaphore, 0x00025220, None
        *   1212 (0x04bc),  (0x), ReleaseSemaphoreWhenCallbackReturns, NTDLL.TpCallbackReleaseSemaphoreOnCompletion, None
        *   1213 (0x04bd),  (0x), RemoveDirectoryA, 0x000256d0, None
        *   1214 (0x04be),  (0x), RemoveDirectoryTransactedA, 0x00038520, None
        *   1215 (0x04bf),  (0x), RemoveDirectoryTransactedW, 0x00063390, None
        *   1216 (0x04c0),  (0x), RemoveDirectoryW, 0x000256e0, None
        *   1217 (0x04c1),  (0x), RemoveDllDirectory, api-ms-win-core-libraryloader-l1-1-0.RemoveDllDirectory, None
        1218 (0x04c2),  (0x), RemoveLocalAlternateComputerNameA, 0x0005bd10, None
        1219 (0x04c3),  (0x), RemoveLocalAlternateComputerNameW, 0x0005bd70, None
        1220 (0x04c4),  (0x), RemoveSecureMemoryCacheCallback, 0x00039200, None
        1221 (0x04c5),  (0x), RemoveVectoredContinueHandler, NTDLL.RtlRemoveVectoredContinueHandler, None
        1222 (0x04c6),  (0x), RemoveVectoredExceptionHandler, NTDLL.RtlRemoveVectoredExceptionHandler, None
        *   1223 (0x04c7),  (0x), ReplaceFile, 0x0003cb40, None
        *   1224 (0x04c8),  (0x), ReplaceFileA, 0x000630d0, None
        *   1225 (0x04c9),  (0x), ReplaceFileW, 0x0003cb40, None
        1226 (0x04ca),  (0x), ReplacePartitionUnit, 0x0003ac60, None
        1227 (0x04cb),  (0x), RequestDeviceWakeup, 0x00039ca0, None
        1228 (0x04cc),  (0x), RequestWakeupLatency, 0x00039ca0, None
        *   1229 (0x04cd),  (0x), ResetEvent, 0x00025230, None
        *   1230 (0x04ce),  (0x), ResetWriteWatch, 0x00018310, None
        *   1231 (0x04cf),  (0x), ResizePseudoConsole, 0x00025b40, None
        1232 (0x04d0),  (0x), ResolveDelayLoadedAPI, NTDLL.LdrResolveDelayLoadedAPI, None
        1233 (0x04d1),  (0x), ResolveDelayLoadsFromDll, NTDLL.LdrResolveDelayLoadsFromDll, None
        1234 (0x04d2),  (0x), ResolveLocaleName, 0x000211a0, None
        1235 (0x04d3),  (0x), RestoreLastError, NTDLL.RtlRestoreLastWin32Error, None
        *   1236 (0x04d4),  (0x), ResumeThread, 0x0001e880, None
        1237 (0x04d5),  (0x), RtlAddFunctionTable, 0x00021b60, None
        1238 (0x04d6),  (0x), RtlCaptureContext, 0x00024e80, None
        1239 (0x04d7),  (0x), RtlCaptureStackBackTrace, 0x000225f0, None
        1240 (0x04d8),  (0x), RtlCompareMemory, 0x0003cb60, None
        1241 (0x04d9),  (0x), RtlCopyMemory, 0x0003cb80, None
        1242 (0x04da),  (0x), RtlDeleteFunctionTable, 0x0003cba0, None
        1243 (0x04db),  (0x), RtlFillMemory, 0x0003cbc0, None
        1244 (0x04dc),  (0x), RtlInstallFunctionTableCallback, 0x0003cbf0, None
        1245 (0x04dd),  (0x), RtlLookupFunctionEntry, 0x0001dab0, None
        1246 (0x04de),  (0x), RtlMoveMemory, 0x00024eb0, None
        1247 (0x04df),  (0x), RtlPcToFileHeader, 0x0001db80, None
        1248 (0x04e0),  (0x), RtlRaiseException, 0x0003cc10, None
        1249 (0x04e1),  (0x), RtlRestoreContext, 0x0003cc30, None
        1250 (0x04e2),  (0x), RtlUnwind, 0x0003cc50, None
        1251 (0x04e3),  (0x), RtlUnwindEx, 0x000201b0, None
        1252 (0x04e4),  (0x), RtlVirtualUnwind, 0x00001010, None
        1253 (0x04e5),  (0x), RtlZeroMemory, NTDLL.RtlZeroMemory, None
        *   1254 (0x04e6),  (0x), ScrollConsoleScreenBufferA, 0x00025cc0, None
        *   1255 (0x04e7),  (0x), ScrollConsoleScreenBufferW, 0x00025cd0, None
        1256 (0x04e8),  (0x), SearchPathA, 0x0003cc70, None
        1257 (0x04e9),  (0x), SearchPathW, 0x00022990, None
        1258 (0x04ea),  (0x), SetCachedSigningLevel, 0x0003cc90, None
        1259 (0x04eb),  (0x), SetCalendarInfoA, 0x0004c780, None
        1260 (0x04ec),  (0x), SetCalendarInfoW, 0x0003ccb0, None
        1261 (0x04ed),  (0x), SetComPlusPackageInstallStatus, 0x00044490, None
        1262 (0x04ee),  (0x), SetCommBreak, 0x000258f0, None
        1263 (0x04ef),  (0x), SetCommConfig, 0x00025900, None
        1264 (0x04f0),  (0x), SetCommMask, 0x00025910, None
        1265 (0x04f1),  (0x), SetCommState, 0x00025920, None
        1266 (0x04f2),  (0x), SetCommTimeouts, 0x00025930, None
        1267 (0x04f3),  (0x), SetComputerNameA, 0x0003ccd0, None
        1268 (0x04f4),  (0x), SetComputerNameEx2W, 0x0003ccf0, None
        1269 (0x04f5),  (0x), SetComputerNameExA, 0x0003cd10, None
        1270 (0x04f6),  (0x), SetComputerNameExW, 0x0003cd30, None
        1271 (0x04f7),  (0x), SetComputerNameW, 0x0003cd50, None
        *   1272 (0x04f8),  (0x), SetConsoleActiveScreenBuffer, 0x00025ce0, None
        *   1273 (0x04f9),  (0x), SetConsoleCP, 0x00025cf0, None
        *   1274 (0x04fa),  (0x), SetConsoleCtrlHandler, 0x00025b50, None
        *   1275 (0x04fb),  (0x), SetConsoleCursor, 0x0006a3a0, None
        *   1276 (0x04fc),  (0x), SetConsoleCursorInfo, 0x00025d00, None
        *   1277 (0x04fd),  (0x), SetConsoleCursorMode, 0x0006a910, None
        *   1278 (0x04fe),  (0x), SetConsoleCursorPosition, 0x00025d10, None
        *   1279 (0x04ff),  (0x), SetConsoleDisplayMode, 0x00025fb0, None
        *   1280 (0x0500),  (0x), SetConsoleFont, 0x0006ace0, None
        *   1281 (0x0501),  (0x), SetConsoleHardwareState, 0x0006a400, None
        *   1282 (0x0502),  (0x), SetConsoleHistoryInfo, 0x00025fc0, None
        *   1283 (0x0503),  (0x), SetConsoleIcon, 0x0006ad40, None
        *   1284 (0x0504),  (0x), SetConsoleInputExeNameA, kernelbase.SetConsoleInputExeNameA, None
        *   1285 (0x0505),  (0x), SetConsoleInputExeNameW, kernelbase.SetConsoleInputExeNameW, None
        *   1286 (0x0506),  (0x), SetConsoleKeyShortcuts, 0x0006a460, None
        *   1287 (0x0507),  (0x), SetConsoleLocalEUDC, 0x0006a980, None
        *   1288 (0x0508),  (0x), SetConsoleMaximumWindowSize, 0x00021ba0, None
        *   1289 (0x0509),  (0x), SetConsoleMenuClose, 0x0006a4f0, None
        *   1290 (0x050a),  (0x), SetConsoleMode, 0x00025b60, None
        *   1291 (0x050b),  (0x), SetConsoleNlsMode, 0x0006aa40, None
        *   1292 (0x050c),  (0x), SetConsoleNumberOfCommandsA, 0x00025fd0, None
        *   1293 (0x050d),  (0x), SetConsoleNumberOfCommandsW, 0x00025fe0, None
        *   1294 (0x050e),  (0x), SetConsoleOS2OemFormat, 0x0006aaa0, None
        *   1295 (0x050f),  (0x), SetConsoleOutputCP, 0x00025d20, None
        *   1296 (0x0510),  (0x), SetConsolePalette, 0x0006a550, None
        *   1297 (0x0511),  (0x), SetConsoleScreenBufferInfoEx, 0x00025d30, None
        *   1298 (0x0512),  (0x), SetConsoleScreenBufferSize, 0x00025d40, None
        *   1299 (0x0513),  (0x), SetConsoleTextAttribute, 0x00025d50, None
        *   1300 (0x0514),  (0x), SetConsoleTitleA, 0x00025d60, None
        *   1301 (0x0515),  (0x), SetConsoleTitleW, 0x00025d70, None
        *   1302 (0x0516),  (0x), SetConsoleWindowInfo, 0x00025d80, None
        *   1303 (0x0517),  (0x), SetCriticalSectionSpinCount, NTDLL.RtlSetCriticalSectionSpinCount, None
        *   1304 (0x0518),  (0x), SetCurrentConsoleFontEx, 0x00025ff0, None
        *   1305 (0x0519),  (0x), SetCurrentDirectoryA, 0x0003cd70, None
        *   1306 (0x051a),  (0x), SetCurrentDirectoryW, 0x00021b20, None
        1307 (0x051b),  (0x), SetDefaultCommConfigA, 0x0003ec10, None
        1308 (0x051c),  (0x), SetDefaultCommConfigW, 0x0003ecc0, None
        *   1309 (0x051d),  (0x), SetDefaultDllDirectories, api-ms-win-core-libraryloader-l1-1-0.SetDefaultDllDirectories, None
        1310 (0x051e),  (0x), SetDllDirectoryA, 0x00066fe0, None
        1311 (0x051f),  (0x), SetDllDirectoryW, 0x00021220, None
        1312 (0x0520),  (0x), SetDynamicTimeZoneInformation, 0x0003cd90, None
        1313 (0x0521),  (0x), SetEndOfFile, 0x000256f0, None
        1314 (0x0522),  (0x), SetEnvironmentStringsA, 0x000688d0, None
        1315 (0x0523),  (0x), SetEnvironmentStringsW, 0x0003cdb0, None
        *   1316 (0x0524),  (0x), SetEnvironmentVariableA, 0x0001e800, None
        *   1317 (0x0525),  (0x), SetEnvironmentVariableW, 0x00021180, None
        1318 (0x0526),  (0x), SetErrorMode, 0x0001cfd0, None
        *   1319 (0x0527),  (0x), SetEvent, 0x00025240, None
        *   1320 (0x0528),  (0x), SetEventWhenCallbackReturns, NTDLL.TpCallbackSetEventOnCompletion, None
        1321 (0x0529),  (0x), SetFileApisToANSI, 0x0003cdd0, None
        1322 (0x052a),  (0x), SetFileApisToOEM, 0x0003cdf0, None
        *   1323 (0x052b),  (0x), SetFileAttributesA, 0x00025700, None
        *   1324 (0x052c),  (0x), SetFileAttributesTransactedA, 0x00064730, None
        *   1325 (0x052d),  (0x), SetFileAttributesTransactedW, 0x00064790, None
        *   1326 (0x052e),  (0x), SetFileAttributesW, 0x00025710, None
        *   1327 (0x052f),  (0x), SetFileBandwidthReservation, 0x000388d0, None
        *   1328 (0x0530),  (0x), SetFileCompletionNotificationModes, 0x0001e700, None
        1329 (0x0531),  (0x), SetFileInformationByHandle, 0x00025720, None
        1330 (0x0532),  (0x), SetFileIoOverlappedRange, 0x0003ce10, None
        1331 (0x0533),  (0x), SetFilePointer, 0x00025730, None
        1332 (0x0534),  (0x), SetFilePointerEx, 0x00025740, None
        *   1333 (0x0535),  (0x), SetFileShortNameA, 0x00038a10, None
        *   1334 (0x0536),  (0x), SetFileShortNameW, 0x00038a60, None
        1335 (0x0537),  (0x), SetFileTime, 0x00025750, None
        1336 (0x0538),  (0x), SetFileValidData, 0x00025760, None
        1337 (0x0539),  (0x), SetFirmwareEnvironmentVariableA, 0x00067b80, None
        1338 (0x053a),  (0x), SetFirmwareEnvironmentVariableExA, 0x00067ba0, None
        1339 (0x053b),  (0x), SetFirmwareEnvironmentVariableExW, 0x00067cd0, None
        1340 (0x053c),  (0x), SetFirmwareEnvironmentVariableW, 0x00067db0, None
        1341 (0x053d),  (0x), SetHandleCount, 0x00021aa0, None
        *   1342 (0x053e),  (0x), SetHandleInformation, 0x000250d0, None
        1343 (0x053f),  (0x), SetInformationJobObject, 0x0001dec0, None
        1344 (0x0540),  (0x), SetIoRateControlInformationJobObject, 0x0005ceb0, None
        1345 (0x0541),  (0x), SetLastConsoleEventActive, kernelbase.SetLastConsoleEventActive, None
        1346 (0x0542),  (0x), SetLastError, 0x00016290, None
        1347 (0x0543),  (0x), SetLocalPrimaryComputerNameA, 0x0005bfc0, None
        1348 (0x0544),  (0x), SetLocalPrimaryComputerNameW, 0x0005c020, None
        1349 (0x0545),  (0x), SetLocalTime, 0x0003ce30, None
        1350 (0x0546),  (0x), SetLocaleInfoA, 0x0004c870, None
        1351 (0x0547),  (0x), SetLocaleInfoW, 0x0003ce50, None
        1352 (0x0548),  (0x), SetMailslotInfo, 0x000636f0, None
        1353 (0x0549),  (0x), SetMessageWaitingIndicator, 0x00039ca0, None
        1354 (0x054a),  (0x), SetNamedPipeAttribute, 0x00039780, None
        1355 (0x054b),  (0x), SetNamedPipeHandleState, 0x00022700, None
        *   1356 (0x054c),  (0x), SetPriorityClass, 0x00021310, None
        *   1357 (0x054d),  (0x), SetProcessAffinityMask, 0x00067780, None
        *   1358 (0x054e),  (0x), SetProcessAffinityUpdateMode, 0x000249c0, None
        1359 (0x054f),  (0x), SetProcessDEPPolicy, 0x00022910, None
        1360 (0x0550),  (0x), SetProcessDefaultCpuSets, api-ms-win-core-processthreads-l1-1-3.SetProcessDefaultCpuSets, None
        1361 (0x0551),  (0x), SetProcessDynamicEHContinuationTargets, api-ms-win-core-processthreads-l1-1-4.SetProcessDynamicEHContinuationTargets, None
        *   1362 (0x0552),  (0x), SetProcessDynamicEnforcedCetCompatibleRanges, api-ms-win-core-processthreads-l1-1-4.SetProcessDynamicEnforcedCetCompatibleRanges, None
        *   1363 (0x0553),  (0x), SetProcessInformation, 0x00025080, None
        *   1364 (0x0554),  (0x), SetProcessMitigationPolicy, api-ms-win-core-processthreads-l1-1-1.SetProcessMitigationPolicy, None
        1365 (0x0555),  (0x), SetProcessPreferredUILanguages, 0x0003ce70, None
        *   1366 (0x0556),  (0x), SetProcessPriorityBoost, 0x00021b40, None
        *   1367 (0x0557),  (0x), SetProcessShutdownParameters, 0x00020ec0, None
        1368 (0x0558),  (0x), SetProcessWorkingSetSize, 0x000446f0, None
        1369 (0x0559),  (0x), SetProcessWorkingSetSizeEx, 0x0003ce90, None
        *   1370 (0x055a),  (0x), SetProtectedPolicy, api-ms-win-core-processthreads-l1-1-2.SetProtectedPolicy, None
        *   1371 (0x055b),  (0x), SetSearchPathMode, 0x00039620, None
        *   1372 (0x055c),  (0x), SetStdHandle, 0x000209d0, None
        *   1373 (0x055d),  (0x), SetStdHandleEx, 0x0003ceb0, None
        *   1374 (0x055e),  (0x), SetSystemFileCacheSize, 0x0003ced0, None
        1375 (0x055f),  (0x), SetSystemPowerState, 0x00039ce0, None
        1376 (0x0560),  (0x), SetSystemTime, 0x0003cef0, None
        1377 (0x0561),  (0x), SetSystemTimeAdjustment, 0x00038310, None
        *   1378 (0x0562),  (0x), SetTapeParameters, 0x00043db0, None
        *   1379 (0x0563),  (0x), SetTapePosition, 0x00043e00, None
        1380 (0x0564),  (0x), SetTermsrvAppInstallMode, 0x00068eb0, None
        *   1381 (0x0565),  (0x), SetThreadAffinityMask, 0x0001f8b0, None
        1382 (0x0566),  (0x), SetThreadContext, 0x0003cf10, None
        *   1383 (0x0567),  (0x), SetThreadDescription, api-ms-win-core-processthreads-l1-1-3.SetThreadDescription, None
        1384 (0x0568),  (0x), SetThreadErrorMode, 0x0001c2a0, None
        1385 (0x0569),  (0x), SetThreadExecutionState, 0x000211e0, None
        1386 (0x056a),  (0x), SetThreadGroupAffinity, 0x00021330, None
        *   1387 (0x056b),  (0x), SetThreadIdealProcessor, 0x00024500, None
        *   1388 (0x056c),  (0x), SetThreadIdealProcessorEx, 0x0003cf30, None
        *   1389 (0x056d),  (0x), SetThreadInformation, 0x00025090, None
        1390 (0x056e),  (0x), SetThreadLocale, 0x0001a8e0, None
        1391 (0x056f),  (0x), SetThreadPreferredUILanguages, 0x0001e130, None
        1392 (0x0570),  (0x), SetThreadPriority, 0x0001bdc0, None
        *   1393 (0x0571),  (0x), SetThreadPriorityBoost, 0x00021bb0, None
        1394 (0x0572),  (0x), SetThreadSelectedCpuSets, api-ms-win-core-processthreads-l1-1-3.SetThreadSelectedCpuSets, None
        *   1395 (0x0573),  (0x), SetThreadStackGuarantee, 0x0001eb50, None
        1396 (0x0574),  (0x), SetThreadToken, api-ms-win-core-processthreads-l1-1-0.SetThreadToken, None
        1397 (0x0575),  (0x), SetThreadUILanguage, 0x0001cdd0, None
        1398 (0x0576),  (0x), SetThreadpoolStackInformation, 0x0003cf50, None
        1399 (0x0577),  (0x), SetThreadpoolThreadMaximum, NTDLL.TpSetPoolMaxThreads, None
        1400 (0x0578),  (0x), SetThreadpoolThreadMinimum, 0x000218e0, None
        1401 (0x0579),  (0x), SetThreadpoolTimer, NTDLL.TpSetTimer, None
        1402 (0x057a),  (0x), SetThreadpoolTimerEx, NTDLL.TpSetTimerEx, None
        1403 (0x057b),  (0x), SetThreadpoolWait, NTDLL.TpSetWait, None
        1404 (0x057c),  (0x), SetThreadpoolWaitEx, NTDLL.TpSetWaitEx, None
        1405 (0x057d),  (0x), SetTimeZoneInformation, 0x0003cf90, None
        1406 (0x057e),  (0x), SetTimerQueueTimer, 0x00044750, None
        *   1407 (0x057f),  (0x), SetUmsThreadInformation, 0x00042c00, None
        1408 (0x0580),  (0x), SetUnhandledExceptionFilter, 0x000205c0, None
        1409 (0x0581),  (0x), SetUserGeoID, 0x00055130, None
        1410 (0x0582),  (0x), SetUserGeoName, 0x00055150, None
        1411 (0x0583),  (0x), SetVDMCurrentDirectories, 0x00042420, None
        *   1412 (0x0584),  (0x), SetVolumeLabelA, 0x00067ec0, None
        *   1413 (0x0585),  (0x), SetVolumeLabelW, 0x00067f70, None
        *   1414 (0x0586),  (0x), SetVolumeMountPointA, 0x00066a40, None
        *   1415 (0x0587),  (0x), SetVolumeMountPointW, 0x00023b80, None
        *   1416 (0x0588),  (0x), SetVolumeMountPointWStub, 0x0003cfb0, None
        *   1417 (0x0589),  (0x), SetWaitableTimer, 0x00025250, None
        *   1418 (0x058a),  (0x), SetWaitableTimerEx, api-ms-win-core-synch-l1-1-0.SetWaitableTimerEx, None
        1419 (0x058b),  (0x), SetXStateFeaturesMask, 0x0003cfc0, None
        1420 (0x058c),  (0x), SetupComm, 0x00025940, None
        1421 (0x058d),  (0x), ShowConsoleCursor, 0x0006a5c0, None
        *   1422 (0x058e),  (0x), SignalObjectAndWait, 0x0003cfe0, None
        1423 (0x058f),  (0x), SizeofResource, 0x0001bbb0, None
        *   1424 (0x0590),  (0x), Sleep, 0x0001b570, None
        *   1425 (0x0591),  (0x), SleepConditionVariableCS, api-ms-win-core-synch-l1-2-0.SleepConditionVariableCS, None
        *   1426 (0x0592),  (0x), SleepConditionVariableSRW, api-ms-win-core-synch-l1-2-0.SleepConditionVariableSRW, None
        *   1427 (0x0593),  (0x), SleepEx, 0x00025260, None
        1428 (0x0594),  (0x), SortCloseHandle, 0x00020620, None
        1429 (0x0595),  (0x), SortGetHandle, 0x0000a190, None
        1430 (0x0596),  (0x), StartThreadpoolIo, NTDLL.TpStartAsyncIoOperation, None
        1431 (0x0597),  (0x), SubmitThreadpoolWork, NTDLL.TpPostWork, None
        *   1432 (0x0598),  (0x), SuspendThread, 0x00020f40, None
        *   1433 (0x0599),  (0x), SwitchToFiber, 0x00025a00, None
        *   1434 (0x059a),  (0x), SwitchToThread, 0x0001bbd0, None
        1435 (0x059b),  (0x), SystemTimeToFileTime, 0x0001fe90, None
        1436 (0x059c),  (0x), SystemTimeToTzSpecificLocalTime, 0x00022970, None
        1437 (0x059d),  (0x), SystemTimeToTzSpecificLocalTimeEx, api-ms-win-core-timezone-l1-1-0.SystemTimeToTzSpecificLocalTimeEx, None
        1438 (0x059e),  (0x), TerminateJobObject, 0x00021850, None
        *   1439 (0x059f),  (0x), TerminateProcess, 0x00020f20, None
        *   1440 (0x05a0),  (0x), TerminateThread, 0x0003d000, None
        1441 (0x05a1),  (0x), TermsrvAppInstallMode, 0x00022e10, None
        1442 (0x05a2),  (0x), TermsrvConvertSysRootToUserDir, 0x00069270, None
        1443 (0x05a3),  (0x), TermsrvCreateRegEntry, 0x0001db60, None
        1444 (0x05a4),  (0x), TermsrvDeleteKey, 0x0001e7a0, None
        1445 (0x05a5),  (0x), TermsrvDeleteValue, 0x0001e780, None
        1446 (0x05a6),  (0x), TermsrvGetPreSetValue, 0x0001bf10, None
        1447 (0x05a7),  (0x), TermsrvGetWindowsDirectoryA, 0x000228f0, None
        1448 (0x05a8),  (0x), TermsrvGetWindowsDirectoryW, 0x0001cee0, None
        1449 (0x05a9),  (0x), TermsrvOpenRegEntry, 0x00017170, None
        1450 (0x05aa),  (0x), TermsrvOpenUserClasses, 0x0001db20, None
        1451 (0x05ab),  (0x), TermsrvRestoreKey, 0x00069ec0, None
        1452 (0x05ac),  (0x), TermsrvSetKeySecurity, 0x0001c2c0, None
        1453 (0x05ad),  (0x), TermsrvSetValueKey, 0x0001c280, None
        1454 (0x05ae),  (0x), TermsrvSyncUserIniFileExt, 0x00069ee0, None
        *   1455 (0x05af),  (0x), Thread32First, 0x00022760, None
        *   1456 (0x05b0),  (0x), Thread32Next, 0x00021c80, None
        *   1457 (0x05b1),  (0x), TlsAlloc, 0x0001cff0, None
        *   1458 (0x05b2),  (0x), TlsFree, 0x0001db40, None
        *   1459 (0x05b3),  (0x), TlsGetValue, 0x00015b20, None
        *   1460 (0x05b4),  (0x), TlsSetValue, 0x00016170, None
        *   1461 (0x05b5),  (0x), Toolhelp32ReadProcessMemory, 0x0003d430, None
        1462 (0x05b6),  (0x), TransactNamedPipe, 0x0003d020, None
        1463 (0x05b7),  (0x), TransmitCommChar, 0x00025950, None
        *   1464 (0x05b8),  (0x), TryAcquireSRWLockExclusive, NTDLL.RtlTryAcquireSRWLockExclusive, None
        *   1465 (0x05b9),  (0x), TryAcquireSRWLockShared, NTDLL.RtlTryAcquireSRWLockShared, None
        *   1466 (0x05ba),  (0x), TryEnterCriticalSection, NTDLL.RtlTryEnterCriticalSection, None
        1467 (0x05bb),  (0x), TrySubmitThreadpoolCallback, 0x00021ab0, None
        1468 (0x05bc),  (0x), TzSpecificLocalTimeToSystemTime, 0x0003d040, None
        1469 (0x05bd),  (0x), TzSpecificLocalTimeToSystemTimeEx, api-ms-win-core-timezone-l1-1-0.TzSpecificLocalTimeToSystemTimeEx, None
        1470 (0x05be),  (0x), UTRegister, 0x00039650, None
        1471 (0x05bf),  (0x), UTUnRegister, 0x00038220, None
        *   1472 (0x05c0),  (0x), UmsThreadYield, 0x00042c40, None
        1473 (0x05c1),  (0x), UnhandledExceptionFilter, 0x0003d060, None
        1474 (0x05c2),  (0x), UnlockFile, 0x00025770, None
        1475 (0x05c3),  (0x), UnlockFileEx, 0x00025780, None
        *   1476 (0x05c4),  (0x), UnmapViewOfFile, 0x0001e7c0, None
        *   1477 (0x05c5),  (0x), UnmapViewOfFileEx, api-ms-win-core-memory-l1-1-1.UnmapViewOfFileEx, None
        1478 (0x05c6),  (0x), UnregisterApplicationRecoveryCallback, 0x000445e0, None
        1479 (0x05c7),  (0x), UnregisterApplicationRestart, 0x0003d080, None
        1480 (0x05c8),  (0x), UnregisterBadMemoryNotification, 0x0003d0a0, None
        1481 (0x05c9),  (0x), UnregisterConsoleIME, 0x0006a880, None
        *   1482 (0x05ca),  (0x), UnregisterWait, 0x00013770, None
        1483 (0x05cb),  (0x), UnregisterWaitEx, 0x00021930, None
        1484 (0x05cc),  (0x), UnregisterWaitUntilOOBECompleted, 0x00068860, None
        1485 (0x05cd),  (0x), UpdateCalendarDayOfWeek, 0x00008230, None
        *   1486 (0x05ce),  (0x), UpdateProcThreadAttribute, api-ms-win-core-processthreads-l1-1-0.UpdateProcThreadAttribute, None
        1487 (0x05cf),  (0x), UpdateResourceA, 0x0004a900, None
        1488 (0x05d0),  (0x), UpdateResourceW, 0x0004aab0, None
        1489 (0x05d1),  (0x), VDMConsoleOperation, 0x0006ae00, None
        1490 (0x05d2),  (0x), VDMOperationStarted, 0x000426f0, None
        1491 (0x05d3),  (0x), VerLanguageNameA, 0x00021b80, None
        1492 (0x05d4),  (0x), VerLanguageNameW, 0x00020cd0, None
        1493 (0x05d5),  (0x), VerSetConditionMask, NTDLL.VerSetConditionMask, None
        1494 (0x05d6),  (0x), VerifyConsoleIoHandle, 0x00021720, None
        1495 (0x05d7),  (0x), VerifyScripts, 0x0003d0c0, None
        1496 (0x05d8),  (0x), VerifyVersionInfoA, 0x00022d40, None
        1497 (0x05d9),  (0x), VerifyVersionInfoW, 0x00018c20, None
        *   1498 (0x05da),  (0x), VirtualAlloc, 0x00018cd0, None
        *   1499 (0x05db),  (0x), VirtualAllocEx, 0x0003d0e0, None
        *   1500 (0x05dc),  (0x), VirtualAllocExNuma, 0x00024a00, None
        *   1501 (0x05dd),  (0x), VirtualFree, 0x0001a900, None
        *   1502 (0x05de),  (0x), VirtualFreeEx, 0x0003d100, None
        *   1503 (0x05df),  (0x), VirtualLock, 0x00024b10, None
        *   1504 (0x05e0),  (0x), VirtualProtect, 0x0001c430, None
        *   1505 (0x05e1),  (0x), VirtualProtectEx, 0x0003d120, None
        *   1506 (0x05e2),  (0x), VirtualQuery, 0x0001c960, None
        *   1507 (0x05e3),  (0x), VirtualQueryEx, 0x0001d7b0, None
        *   1508 (0x05e4),  (0x), VirtualUnlock, 0x0001cdb0, None
        *   1509 (0x05e5),  (0x), WTSGetActiveConsoleSessionId, 0x00020c60, None
        1510 (0x05e6),  (0x), WaitCommEvent, 0x00025960, None
        1511 (0x05e7),  (0x), WaitForDebugEvent, 0x0003d140, None
        1512 (0x05e8),  (0x), WaitForDebugEventEx, api-ms-win-core-debug-l1-1-2.WaitForDebugEventEx, None
        *   1513 (0x05e9),  (0x), WaitForMultipleObjects, 0x00025270, None
        *   1514 (0x05ea),  (0x), WaitForMultipleObjectsEx, 0x00025280, None
        *   1515 (0x05eb),  (0x), WaitForSingleObject, 0x00025290, None
        *   1516 (0x05ec),  (0x), WaitForSingleObjectEx, 0x000252a0, None
        1517 (0x05ed),  (0x), WaitForThreadpoolIoCallbacks, NTDLL.TpWaitForIoCompletion, None
        1518 (0x05ee),  (0x), WaitForThreadpoolTimerCallbacks, NTDLL.TpWaitForTimer, None
        1519 (0x05ef),  (0x), WaitForThreadpoolWaitCallbacks, NTDLL.TpWaitForWait, None
        1520 (0x05f0),  (0x), WaitForThreadpoolWorkCallbacks, NTDLL.TpWaitForWork, None
        1521 (0x05f1),  (0x), WaitNamedPipeA, 0x000621e0, None
        1522 (0x05f2),  (0x), WaitNamedPipeW, 0x0003d160, None
        *   1523 (0x05f3),  (0x), WakeAllConditionVariable, NTDLL.RtlWakeAllConditionVariable, None
        *   1524 (0x05f4),  (0x), WakeConditionVariable, NTDLL.RtlWakeConditionVariable, None
        1525 (0x05f5),  (0x), WerGetFlags, 0x00044600, None
        1526 (0x05f6),  (0x), WerGetFlagsWorker, 0x00044600, None
        1527 (0x05f7),  (0x), WerRegisterAdditionalProcess, 0x0003d180, None
        1528 (0x05f8),  (0x), WerRegisterAppLocalDump, 0x0003d1a0, None
        1529 (0x05f9),  (0x), WerRegisterCustomMetadata, 0x0003d1c0, None
        1530 (0x05fa),  (0x), WerRegisterExcludedMemoryBlock, 0x0003d1e0, None
        1531 (0x05fb),  (0x), WerRegisterFile, 0x00020c40, None
        1532 (0x05fc),  (0x), WerRegisterFileWorker, 0x00044610, None
        1533 (0x05fd),  (0x), WerRegisterMemoryBlock, 0x00020ea0, None
        1534 (0x05fe),  (0x), WerRegisterMemoryBlockWorker, 0x00044620, None
        1535 (0x05ff),  (0x), WerRegisterRuntimeExceptionModule, 0x00021040, None
        1536 (0x0600),  (0x), WerRegisterRuntimeExceptionModuleWorker, 0x00044630, None
        1537 (0x0601),  (0x), WerSetFlags, 0x0001d390, None
        1538 (0x0602),  (0x), WerSetFlagsWorker, 0x0001d390, None
        1539 (0x0603),  (0x), WerUnregisterAdditionalProcess, 0x0003d200, None
        1540 (0x0604),  (0x), WerUnregisterAppLocalDump, 0x0003d220, None
        1541 (0x0605),  (0x), WerUnregisterCustomMetadata, 0x0003d240, None
        1542 (0x0606),  (0x), WerUnregisterExcludedMemoryBlock, 0x0003d260, None
        1543 (0x0607),  (0x), WerUnregisterFile, 0x00020c20, None
        1544 (0x0608),  (0x), WerUnregisterFileWorker, 0x00044640, None
        1545 (0x0609),  (0x), WerUnregisterMemoryBlock, 0x00022360, None
        1546 (0x060a),  (0x), WerUnregisterMemoryBlockWorker, 0x00044650, None
        1547 (0x060b),  (0x), WerUnregisterRuntimeExceptionModule, 0x0003d280, None
        1548 (0x060c),  (0x), WerUnregisterRuntimeExceptionModuleWorker, 0x00044660, None
        1549 (0x060d),  (0x), WerpGetDebugger, 0x0006d860, None
        1550 (0x060e),  (0x), WerpInitiateRemoteRecovery, 0x00044670, None
        1551 (0x060f),  (0x), WerpLaunchAeDebug, 0x0006e250, None
        1552 (0x0610),  (0x), WerpNotifyLoadStringResourceWorker, 0x0001bde0, None
        1553 (0x0611),  (0x), WerpNotifyUseStringResourceWorker, 0x0001bde0, None
        1554 (0x0612),  (0x), WideCharToMultiByte, 0x00016110, None
        *   1555 (0x0613),  (0x), WinExec, 0x000677d0, None
        1556 (0x0614),  (0x), Wow64DisableWow64FsRedirection, 0x0003d2a0, None
        1557 (0x0615),  (0x), Wow64EnableWow64FsRedirection, 0x00021da0, None
        1558 (0x0616),  (0x), Wow64GetThreadContext, 0x0003d2c0, None
        1559 (0x0617),  (0x), Wow64GetThreadSelectorEntry, 0x00038400, None
        1560 (0x0618),  (0x), Wow64RevertWow64FsRedirection, 0x0003d2e0, None
        1561 (0x0619),  (0x), Wow64SetThreadContext, 0x0003d300, None
        1562 (0x061a),  (0x), Wow64SuspendThread, 0x0003d320, None
        *   1563 (0x061b),  (0x), WriteConsoleA, 0x00025b70, None
        *   1564 (0x061c),  (0x), WriteConsoleInputA, 0x00025d90, None
        *   1565 (0x061d),  (0x), WriteConsoleInputVDMA, 0x0006a600, None
        *   1566 (0x061e),  (0x), WriteConsoleInputVDMW, 0x0006a690, None
        *   1567 (0x061f),  (0x), WriteConsoleInputW, 0x00025da0, None
        *   1568 (0x0620),  (0x), WriteConsoleOutputA, 0x00025db0, None
        *   1569 (0x0621),  (0x), WriteConsoleOutputAttribute, 0x00025dc0, None
        *   1570 (0x0622),  (0x), WriteConsoleOutputCharacterA, 0x00025dd0, None
        *   1571 (0x0623),  (0x), WriteConsoleOutputCharacterW, 0x00025de0, None
        *   1572 (0x0624),  (0x), WriteConsoleOutputW, 0x00025df0, None
        *   1573 (0x0625),  (0x), WriteConsoleW, 0x00025b80, None
        *   1574 (0x0626),  (0x), WriteFile, 0x00025790, None
        *   1575 (0x0627),  (0x), WriteFileEx, 0x000257a0, None
        *   1576 (0x0628),  (0x), WriteFileGather, 0x000257b0, None
        1577 (0x0629),  (0x), WritePrivateProfileSectionA, 0x000610e0, None
        1578 (0x062a),  (0x), WritePrivateProfileSectionW, 0x00024520, None
        1579 (0x062b),  (0x), WritePrivateProfileStringA, 0x00061150, None
        1580 (0x062c),  (0x), WritePrivateProfileStringW, 0x000182c0, None
        1581 (0x062d),  (0x), WritePrivateProfileStructA, 0x000611c0, None
        1582 (0x062e),  (0x), WritePrivateProfileStructW, 0x00061330, None
        1583 (0x062f),  (0x), WriteProcessMemory, 0x0003d340, None
        1584 (0x0630),  (0x), WriteProfileSectionA, 0x000614a0, None
        1585 (0x0631),  (0x), WriteProfileSectionW, 0x000614b0, None
        1586 (0x0632),  (0x), WriteProfileStringA, 0x000614c0, None
        1587 (0x0633),  (0x), WriteProfileStringW, 0x000614d0, None
        *   1588 (0x0634),  (0x), WriteTapemark, 0x00043e70, None
        *   1589 (0x0635),  (0x), ZombifyActCtx, 0x0003d360, None
        *   1590 (0x0636),  (0x), ZombifyActCtxWorker, 0x00044410, None
        1591 (0x0637),  (0x), __C_specific_handler, NTDLL.__C_specific_handler, None
        1592 (0x0638),  (0x), __chkstk, NTDLL.__chkstk, None
        1593 (0x0639),  (0x), __misaligned_access, NTDLL.__misaligned_access, None
        1594 (0x063a),  (0x), _hread, 0x00018490, None
        1595 (0x063b),  (0x), _hwrite, 0x00069ff0, None
        1596 (0x063c),  (0x), _lclose, 0x0001cdf0, None
        1597 (0x063d),  (0x), _lcreat, 0x00069f00, None
        1598 (0x063e),  (0x), _llseek, 0x00018460, None
        1599 (0x063f),  (0x), _local_unwind, NTDLL._local_unwind, None
        1600 (0x0640),  (0x), _lopen, 0x00069f70, None
        1601 (0x0641),  (0x), _lread, 0x00018490, None
        1602 (0x0642),  (0x), _lwrite, 0x00069ff0, None
        1603 (0x0643),  (0x), lstrcat, 0x00020880, None
        1604 (0x0644),  (0x), lstrcatA, 0x00020880, None
        1605 (0x0645),  (0x), lstrcatW, 0x0006a040, None
        1606 (0x0646),  (0x), lstrcmp, 0x0001cc40, None
        1607 (0x0647),  (0x), lstrcmpA, 0x0001cc40, None
        1608 (0x0648),  (0x), lstrcmpW, 0x0001bf40, None
        1609 (0x0649),  (0x), lstrcmpi, 0x0001bad0, None
        1610 (0x064a),  (0x), lstrcmpiA, 0x0001bad0, None
        1611 (0x064b),  (0x), lstrcmpiW, 0x00018370, None
        1612 (0x064c),  (0x), lstrcpy, 0x0001eac0, None
        1613 (0x064d),  (0x), lstrcpyA, 0x0001eac0, None
        1614 (0x064e),  (0x), lstrcpyW, 0x00022610, None
        1615 (0x064f),  (0x), lstrcpyn, 0x0003d380, None
        1616 (0x0650),  (0x), lstrcpynA, 0x0003d380, None
        1617 (0x0651),  (0x), lstrcpynW, 0x00021730, None
        1618 (0x0652),  (0x), lstrlen, 0x0001b280, None
        1619 (0x0653),  (0x), lstrlenA, 0x0001b280, None
        1620 (0x0654),  (0x), lstrlenW, 0x000175e0, None
        1621 (0x0655),  (0x), timeBeginPeriod, 0x0001e150, None
        1622 (0x0656),  (0x), timeEndPeriod, 0x0001d1d0, None
        1623 (0x0657),  (0x), timeGetDevCaps, 0x00022880, None
        1624 (0x0658),  (0x), timeGetSystemTime, 0x0006a090, None
        1625 (0x0659),  (0x), timeGetTime, 0x0001c1e0, None
        1626 (0x065a),  (0x), uaw_lstrcmpW, 0x0001bf40, None
        1627 (0x065b),  (0x), uaw_lstrcmpiW, 0x00018370, None
        1628 (0x065c),  (0x), uaw_lstrlenW, 0x00037c10, None
        1629 (0x065d),  (0x), uaw_wcschr, 0x00037c60, None
        1630 (0x065e),  (0x), uaw_wcscpy, 0x00037c90, None
        1631 (0x065f),  (0x), uaw_wcsicmp, 0x00037cc0, None
        1632 (0x0660),  (0x), uaw_wcslen, 0x00037ce0, None
        1633 (0x0661),  (0x), uaw_wcsrchr, 0x00037d10, None
         
         */


        [DllImport("kernel32", EntryPoint = "CreateRemoteThread")]
        public static extern int CreateRemoteThread(
                int hProcess,
                int lpThreadAttributes,
                int dwStackSize,
                int lpStartAddress,
                int lpParameter,
                int dwCreationFlags,
                ref int lpThreadId
        );


        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern int OpenProcess(
                int dwDesiredAccess,
                int bInheritHandle,
                int dwProcessId
        );
    }
}
