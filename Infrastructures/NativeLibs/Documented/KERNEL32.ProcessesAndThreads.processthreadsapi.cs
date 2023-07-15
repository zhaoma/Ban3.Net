using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// processthreadsapi.h This header is used by multiple technologies.
    ///     Processes and threads
    ///     Remote Desktop Services
    ///     Security and Identity
    /// This file is Processes and threads parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         *
        228 (0x00e4),  (0x), CreateProcessA, 0x0001cf20, None
        229 (0x00e5),  (0x), CreateProcessAsUserA, 0x0003b060, None
        230 (0x00e6),  (0x), CreateProcessAsUserW, 0x0001e280, None
        233 (0x00e9),  (0x), CreateProcessW, 0x0001d320, None
        235 (0x00eb),  (0x), CreateRemoteThread, 0x0003b1e0, None
        236 (0x00ec),  (0x), CreateRemoteThreadEx, api-ms-win-core-processthreads-l1-1-0.CreateRemoteThreadEx, None
        246 (0x00f6),  (0x), CreateThread, 0x0001bd70, None
        283 (0x011b),  (0x), DeleteProcThreadAttributeList, api-ms-win-core-processthreads-l1-1-0.DeleteProcThreadAttributeList, None
        360 (0x0168),  (0x), ExitProcess, 0x0001e860, None
        361 (0x0169),  (0x), ExitThread, NTDLL.RtlExitUserThread, None
        427 (0x01ab),  (0x), FlushProcessWriteBuffers, NTDLL.NtFlushProcessWriteBuffers, None
        545 (0x0221),  (0x), GetCurrentProcess, 0x00025040, None
        546 (0x0222),  (0x), GetCurrentProcessId, 0x00025050, None
        547 (0x0223),  (0x), GetCurrentProcessorNumber, NTDLL.RtlGetCurrentProcessorNumber, None
        548 (0x0224),  (0x), GetCurrentProcessorNumberEx, NTDLL.RtlGetCurrentProcessorNumberEx, None
        549 (0x0225),  (0x), GetCurrentThread, 0x00015e80, None
        550 (0x0226),  (0x), GetCurrentThreadId, 0x00015b30, None
        551 (0x0227),  (0x), GetCurrentThreadStackLimits, api-ms-win-core-processthreads-l1-1-0.GetCurrentThreadStackLimits, None
        583 (0x0247),  (0x), GetExitCodeProcess, 0x0001d820, None
        584 (0x0248),  (0x), GetExitCodeThread, 0x00020180, None
        686 (0x02ae),  (0x), GetPriorityClass, 0x00021880, None
        702 (0x02be),  (0x), GetProcessHandleCount, 0x0003b960, None
        705 (0x02c1),  (0x), GetProcessId, 0x0001d790, None
        706 (0x02c2),  (0x), GetProcessIdOfThread, 0x00020fa0, None
        707 (0x02c3),  (0x), GetProcessInformation, 0x00025060, None
        709 (0x02c5),  (0x), GetProcessMitigationPolicy, api-ms-win-core-processthreads-l1-1-1.GetProcessMitigationPolicy, None
        711 (0x02c7),  (0x), GetProcessPriorityBoost, 0x0003b9a0, None
        712 (0x02c8),  (0x), GetProcessShutdownParameters, 0x0003b9c0, None
        713 (0x02c9),  (0x), GetProcessTimes, 0x0001b2a0, None
        714 (0x02ca),  (0x), GetProcessVersion, 0x00022860, None
        731 (0x02db),  (0x), GetStartupInfoW, 0x0001dff0, None
        771 (0x0303),  (0x), GetThreadDescription, api-ms-win-core-processthreads-l1-1-3.GetThreadDescription, None
        774 (0x0306),  (0x), GetThreadIOPendingFlag, 0x0003bad0, None
        775 (0x0307),  (0x), GetThreadId, 0x000213d0, None
        776 (0x0308),  (0x), GetThreadIdealProcessorEx, 0x0003baf0, None
        777 (0x0309),  (0x), GetThreadInformation, 0x00025070, None
        780 (0x030c),  (0x), GetThreadPriority, 0x0001c040, None
        781 (0x030d),  (0x), GetThreadPriorityBoost, 0x0003bb10, None
        784 (0x0310),  (0x), GetThreadTimes, 0x00016210, None
        879 (0x036f),  (0x), InitializeProcThreadAttributeList, api-ms-win-core-processthreads-l1-1-0.InitializeProcThreadAttributeList, None
        907 (0x038b),  (0x), IsProcessCritical, api-ms-win-core-processthreads-l1-1-2.IsProcessCritical, None
        1043 (0x0413),  (0x), OpenProcess, 0x0001b5b0, None
        1050 (0x041a),  (0x), OpenThread, 0x0001d010, None
        1109 (0x0455),  (0x), QueryProcessAffinityUpdateMode, 0x0003c460, None
        1111 (0x0457),  (0x), QueryProtectedPolicy, api-ms-win-core-processthreads-l1-1-2.QueryProtectedPolicy, None
        1117 (0x045d),  (0x), QueueUserAPC, 0x0001e8a0, None
        1236 (0x04d4),  (0x), ResumeThread, 0x0001e880, None
        1356 (0x054c),  (0x), SetPriorityClass, 0x00021310, None
        1358 (0x054e),  (0x), SetProcessAffinityUpdateMode, 0x000249c0, None
        1362 (0x0552),  (0x), SetProcessDynamicEnforcedCetCompatibleRanges, api-ms-win-core-processthreads-l1-1-4.SetProcessDynamicEnforcedCetCompatibleRanges, None
        1363 (0x0553),  (0x), SetProcessInformation, 0x00025080, None
        1364 (0x0554),  (0x), SetProcessMitigationPolicy, api-ms-win-core-processthreads-l1-1-1.SetProcessMitigationPolicy, None
        1366 (0x0556),  (0x), SetProcessPriorityBoost, 0x00021b40, None
        1367 (0x0557),  (0x), SetProcessShutdownParameters, 0x00020ec0, None
        1370 (0x055a),  (0x), SetProtectedPolicy, api-ms-win-core-processthreads-l1-1-2.SetProtectedPolicy, None
        1383 (0x0567),  (0x), SetThreadDescription, api-ms-win-core-processthreads-l1-1-3.SetThreadDescription, None
        1387 (0x056b),  (0x), SetThreadIdealProcessor, 0x00024500, None
        1388 (0x056c),  (0x), SetThreadIdealProcessorEx, 0x0003cf30, None
        1389 (0x056d),  (0x), SetThreadInformation, 0x00025090, None
        1393 (0x0571),  (0x), SetThreadPriorityBoost, 0x00021bb0, None
        1395 (0x0573),  (0x), SetThreadStackGuarantee, 0x0001eb50, None
        1432 (0x0598),  (0x), SuspendThread, 0x00020f40, None
        1434 (0x059a),  (0x), SwitchToThread, 0x0001bbd0, None
        1439 (0x059f),  (0x), TerminateProcess, 0x00020f20, None
        1440 (0x05a0),  (0x), TerminateThread, 0x0003d000, None
        1457 (0x05b1),  (0x), TlsAlloc, 0x0001cff0, None
        1458 (0x05b2),  (0x), TlsFree, 0x0001db40, None
        1459 (0x05b3),  (0x), TlsGetValue, 0x00015b20, None
        1460 (0x05b4),  (0x), TlsSetValue, 0x00016170, None
        1486 (0x05ce),  (0x), UpdateProcThreadAttribute, api-ms-win-core-processthreads-l1-1-0.UpdateProcThreadAttribute, None
         *
         *
         *
         */
    }
}
