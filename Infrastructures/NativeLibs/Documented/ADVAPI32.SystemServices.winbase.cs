using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    /// This file is System Services parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-backupeventloga
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1060 (0x0424),  (0x), BackupEventLogA, 0x0004f440, None
        1061 (0x0425),  (0x), BackupEventLogW, 0x0004f4c0, None
        1098 (0x044a),  (0x), ClearEventLogA, 0x0004f6c0, None
        1099 (0x044b),  (0x), ClearEventLogW, 0x0004f740, None
        1102 (0x044e),  (0x), CloseEventLog, 0x00023c30, None
        1323 (0x052b),  (0x), GetEventLogInformation, 0x00023b60, None
        1346 (0x0542),  (0x), GetNumberOfEventLogRecords, 0x0004f7d0, None
        1347 (0x0543),  (0x), GetOldestEventLogRecord, 0x0004f810, None
        1518 (0x05ee),  (0x), NotifyChangeEventLog, 0x0004f890, None
        1531 (0x05fb),  (0x), OpenBackupEventLogA, 0x0004f8d0, None
        1532 (0x05fc),  (0x), OpenBackupEventLogW, 0x0004f9a0, None
        1535 (0x05ff),  (0x), OpenEventLogA, 0x0004fa50, None
        1536 (0x0600),  (0x), OpenEventLogW, 0x00023b00, None
        1605 (0x0645),  (0x), ReadEventLogA, 0x0004fac0, None
        1606 (0x0646),  (0x), ReadEventLogW, 0x0004fb20, None
        1689 (0x0699),  (0x), RegisterEventSourceA, 0x00022eb0, None
        1690 (0x069a),  (0x), RegisterEventSourceW, 0x00020900, None
         
         */

        /// <summary>
        /// Saves the specified event log to a backup file. The function does not clear the event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-backupeventloga
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the open event log. The OpenEventLog function returns this handle.
        /// </param>
        /// <param name="lpBackupFileName">
        /// The absolute or relative path of the backup file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BackupEventLogA(
            IntPtr hEventLog,
            [MarshalAs(UnmanagedType.LPStr)] string lpBackupFileName
            );

        /// almost same as BackupEventLogA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BackupEventLogW(
            IntPtr hEventLog,
            [MarshalAs(UnmanagedType.LPWStr)] string lpBackupFileName
            );

        /// <summary>
        /// Clears the specified event log, and optionally saves the current copy of the log to a backup file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-cleareventloga
        /// </summary>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClearEventLogA(
            IntPtr hEventLog,
            [MarshalAs(UnmanagedType.LPStr)] string lpBackupFileName
            );

        /// almost same as ClearEventLogA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClearEventLogW(
            IntPtr hEventLog,
            [MarshalAs(UnmanagedType.LPWStr)] string lpBackupFileName
            );

        /// <summary>
        /// Closes the specified event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-closeeventlog
        /// </summary>
        /// <param name="hEventLog"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseEventLog(
            ref IntPtr hEventLog
            );

        /// <summary>
        /// Retrieves information about the specified event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-geteventloginformation
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the event log. The OpenEventLog or RegisterEventSource function returns this handle.
        /// </param>
        /// <param name="dwInfoLevel"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="cbBufSize"></param>
        /// <param name="pcbBytesNeeded"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetEventLogInformation(
            IntPtr hEventLog,
            uint dwInfoLevel,
            IntPtr lpBuffer,
            uint cbBufSize,
            ref uint pcbBytesNeeded
        );

        /// <summary>
        /// Retrieves the number of records in the specified event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumberofeventlogrecords
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the open event log. 
        /// The OpenEventLog or OpenBackupEventLog function returns this handle.
        /// </param>
        /// <param name="NumberOfRecords"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfEventLogRecords(
            IntPtr hEventLog,
            ref uint NumberOfRecords
        );


        /// <summary>
        /// Retrieves the absolute record number of the oldest record in the specified event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getoldesteventlogrecord
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the open event log. 
        /// The OpenEventLog or OpenBackupEventLog function returns this handle.
        /// </param>
        /// <param name="OldestRecord"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetOldestEventLogRecord(
            IntPtr hEventLog,
            ref uint OldestRecord
        );

        /// <summary>
        /// Enables an application to receive notification 
        /// when an event is written to the specified event log. 
        /// When the event is written to the log, 
        /// the specified event object is set to the signaled state.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-notifychangeeventlog
        /// </summary>
        /// <param name="hEventLog"></param>
        /// <param name="hEvent">
        /// A handle to a manual-reset or auto-reset event object. 
        /// Use the CreateEvent function to create the event object.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool NotifyChangeEventLog(
            IntPtr hEventLog,
            IntPtr hEvent
        );

        /// <summary>
        /// Opens a handle to a backup event log created by the BackupEventLog function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-openbackupeventloga
        /// </summary>
        /// <param name="lpUNCServerName"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenBackupEventLogA(
            [MarshalAs(UnmanagedType.LPStr)] string lpUNCServerName,
            [MarshalAs(UnmanagedType.LPStr)] string lpFileName
        );

        /// almost same as OpenBackupEventLogA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenBackupEventLogW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpUNCServerName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpFileName
        );

        /// <summary>
        /// Opens a handle to the specified event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-openeventloga
        /// </summary>
        /// <param name="lpUNCServerName">
        /// The Universal Naming Convention (UNC) name of the remote server on which the event log is to be opened.
        /// If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="lpSourceName">
        /// The name of the log.
        /// If you specify a custom log and it cannot be found, the event logging service opens the Application log;
        /// however, there will be no associated message or category string file.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenEventLogA(
            [MarshalAs(UnmanagedType.LPStr)] string lpUNCServerName,
            [MarshalAs(UnmanagedType.LPStr)] string lpSourceName
            );

        /// almost same as OpenEventLogA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenEventLogW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpUNCServerName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSourceName
        );

        /// <summary>
        /// Reads the specified number of entries from the specified event log.
        /// The function can be used to read log entries in chronological or reverse chronological order.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-readeventloga
        /// </summary>
        /// <param name="hEventLog"></param>
        /// <param name="dwReadFlags"></param>
        /// <param name="dwRecordOffset"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToRead"></param>
        /// <param name="pnBytesRead"></param>
        /// <param name="pnMinNumberOfBytesNeeded"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadEventLogA(
            System.IntPtr hEventLog,
            READ_EVENTLOG_FLAGS dwReadFlags, 
            uint dwRecordOffset, 
            System.IntPtr lpBuffer, 
            uint nNumberOfBytesToRead, 
            ref uint pnBytesRead, 
            ref uint pnMinNumberOfBytesNeeded
            );

        /// almost same as ReadEventLogA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadEventLogW(
            System.IntPtr hEventLog,
            READ_EVENTLOG_FLAGS dwReadFlags,
            uint dwRecordOffset,
            System.IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            ref uint pnBytesRead,
            ref uint pnMinNumberOfBytesNeeded
        );

        /// <summary>
        /// Retrieves a registered handle to the specified event log.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-registereventsourcea
        /// </summary>
        /// <param name="lpUNCServerName"></param>
        /// <param name="lpSourceName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr RegisterEventSourceA(
            [MarshalAs(UnmanagedType.LPStr)] string lpUNCServerName,
            [MarshalAs(UnmanagedType.LPStr)] string lpSourceName
            );

        /// almost same as RegisterEventSourceA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr RegisterEventSourceW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpUNCServerName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSourceName
            );
    }
}
