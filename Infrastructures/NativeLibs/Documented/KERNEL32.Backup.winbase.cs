using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    /// This file is Backup parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-addintegritylabeltoboundarydescriptor
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         *
        39 (0x0027),  (0x), BackupRead, 0x0005d3a0, None
        40 (0x0028),  (0x), BackupSeek, 0x0005e560, None
        41 (0x0029),  (0x), BackupWrite, 0x0005e840, None
        107 (0x006b),  (0x), BindIoCompletionCallback, 0x00024a20, None
        165 (0x00a5),  (0x), ConvertFiberToThread, 0x000259a0, None
        168 (0x00a8),  (0x), ConvertThreadToFiber, 0x000259b0, None
        169 (0x00a9),  (0x), ConvertThreadToFiberEx, 0x000259c0, None
        182 (0x00b6),  (0x), CreateBoundaryDescriptorA, 0x000623f0, None
        196 (0x00c4),  (0x), CreateFiber, 0x000259d0, None
        197 (0x00c5),  (0x), CreateFiberEx, 0x000259e0, None
        213 (0x00d5),  (0x), CreateJobObjectA, 0x0005c930, None
        237 (0x00ed),  (0x), CreateSemaphoreA, 0x0001c540, None
        238 (0x00ee),  (0x), CreateSemaphoreExA, 0x0001c570, None
        245 (0x00f5),  (0x), CreateTapePartition, 0x00043c10, None
        256 (0x0100),  (0x), CreateUmsCompletionList, 0x00042820, None
        257 (0x0101),  (0x), CreateUmsThreadContext, 0x00042860, None
        278 (0x0116),  (0x), DeleteFiber, 0x000259f0, None
        288 (0x0120),  (0x), DeleteUmsCompletionList, 0x000428a0, None
        289 (0x0121),  (0x), DeleteUmsThreadContext, 0x000428e0, None
        292 (0x0124),  (0x), DequeueUmsCompletionListItems, 0x00042920, None
        315 (0x013b),  (0x), EnterUmsSchedulingMode, 0x00042980, None
        357 (0x0165),  (0x), EraseTape, 0x00043c70, None
        359 (0x0167),  (0x), ExecuteUmsThread, 0x00042a30, None
        445 (0x01bd),  (0x), GetActiveProcessorCount, 0x0001dc70, None
        446 (0x01be),  (0x), GetActiveProcessorGroupCount, 0x00067090, None
        552 (0x0228),  (0x), GetCurrentUmsThread, 0x00042a70, None
        634 (0x027a),  (0x), GetMaximumProcessorCount, 0x000670f0, None
        635 (0x027b),  (0x), GetMaximumProcessorGroupCount, 0x00022f80, None
        656 (0x0290),  (0x), GetNextUmsListItem, 0x00042ab0, None
        658 (0x0292),  (0x), GetNumaAvailableMemoryNode, 0x00039990, None
        659 (0x0293),  (0x), GetNumaAvailableMemoryNodeEx, 0x00068370, None
        661 (0x0295),  (0x), GetNumaNodeNumberFromHandle, 0x000399a0, None
        662 (0x0296),  (0x), GetNumaNodeProcessorMask, 0x00068400, None
        664 (0x0298),  (0x), GetNumaProcessorNode, 0x00039a00, None
        665 (0x0299),  (0x), GetNumaProcessorNodeEx, 0x00068480, None
        666 (0x029a),  (0x), GetNumaProximityNode, 0x00039a70, None
        698 (0x02ba),  (0x), GetProcessAffinityMask, 0x0001c8d0, None
        708 (0x02c4),  (0x), GetProcessIoCounters, 0x00020580, None
        763 (0x02fb),  (0x), GetTapeParameters, 0x00068650, None
        764 (0x02fc),  (0x), GetTapePosition, 0x00043cb0, None
        765 (0x02fd),  (0x), GetTapeStatus, 0x00043d40, None
        796 (0x031c),  (0x), GetUmsCompletionListEvent, 0x00042af0, None
        797 (0x031d),  (0x), GetUmsSystemThreadInformation, 0x00042b30, None
        
        1036 (0x040c),  (0x), OpenJobObjectA, 0x0005c9e0, None
        1070 (0x042e),  (0x), PrepareTape, 0x00043d70, None
        1091 (0x0443),  (0x), PulseEvent, 0x0001ca70, None
        1100 (0x044c),  (0x), QueryFullProcessImageNameA, 0x0003c400, None
        1101 (0x044d),  (0x), QueryFullProcessImageNameW, 0x0001d030, None
        1115 (0x045b),  (0x), QueryUmsThreadInformation, 0x00042bb0, None
        1200 (0x04b0),  (0x), RegisterWaitForSingleObject, 0x00015ab0, None
        1316 (0x0524),  (0x), SetEnvironmentVariableA, 0x0001e800, None
        1317 (0x0525),  (0x), SetEnvironmentVariableW, 0x00021180, None
        1357 (0x054d),  (0x), SetProcessAffinityMask, 0x00067780, None
        1378 (0x0562),  (0x), SetTapeParameters, 0x00043db0, None
        1379 (0x0563),  (0x), SetTapePosition, 0x00043e00, None
        1381 (0x0565),  (0x), SetThreadAffinityMask, 0x0001f8b0, None
        1407 (0x057f),  (0x), SetUmsThreadInformation, 0x00042c00, None
        1433 (0x0599),  (0x), SwitchToFiber, 0x00025a00, None
        1472 (0x05c0),  (0x), UmsThreadYield, 0x00042c40, None
        1482 (0x05ca),  (0x), UnregisterWait, 0x00013770, None
        1555 (0x0613),  (0x), WinExec, 0x000677d0, None
        1588 (0x0634),  (0x), WriteTapemark, 0x00043e70, None
         *
         */

        /// <summary>
        /// BackupRead
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToRead"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <param name="bAbort"></param>
        /// <param name="bProcessSecurity"></param>
        /// <param name="lpContext"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern bool BackupRead(
            IntPtr hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            out uint lpNumberOfBytesRead,
            bool bAbort,
            bool bProcessSecurity,
            ref IntPtr lpContext);

        /// <summary>
        /// BackupWrite
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToWrite"></param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <param name="bAbort"></param>
        /// <param name="bProcessSecurity"></param>
        /// <param name="lpContext"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern bool BackupWrite(
            IntPtr hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            bool bAbort,
            bool bProcessSecurity,
            ref IntPtr lpContext);
    }
}
