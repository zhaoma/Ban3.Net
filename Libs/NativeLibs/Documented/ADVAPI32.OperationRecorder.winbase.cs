using Ban3.Infrastructures.NativeLibs.Structs;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    ///     Application Installation and Servicing
    ///     Application Recovery and Restart
    ///     Backup
    ///     Data Access and Storage
    ///     Data Exchange
    ///     Developer Notes
    ///     eventlogprov
    ///     Hardware Counter Profiling
    ///     Internationalization for Windows Applications
    ///     Menus and Other Resources
    ///     Operation Recorder
    ///     Remote Desktop Services
    ///     Security and Identity
    ///     System Services
    ///     Window Stations and Desktops
    ///     Windows and Messages
    /// This file is Operation Recorder parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/_oprec/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1546 (0x060a),  (0x), OperationEnd, 0x00036160, None
        1547 (0x060b),  (0x), OperationStart, 0x00036210, None
         
         */

        /// <summary>
        /// Notifies the system that the application is about to end an operation
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-operationend
        /// </summary>
        /// <param name="OperationStartParams">
        /// An _OPERATION_END_PARAMETERS structure that specifies VERSION, OPERATION_ID and FLAGS.
        /// </param>
        /// <returns>
        /// TRUE for all valid parameters and FALSE otherwise. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool OperationEnd(
            OPERATION_END_PARAMETERS OperationStartParams
        );

        /// <summary>
        /// Notifies the system that the application is about to start an operation.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-operationstart
        /// </summary>
        /// <param name="OperationStartParams">
        /// An _OPERATION_START_PARAMETERS structure that specifies VERSION, OPERATION_ID and FLAGS.
        /// </param>
        /// <returns>
        /// TRUE for all valid parameters and FALSE otherwise. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool OperationStart(
            OPERATION_START_PARAMETERS OperationStartParams
        );
    }
}
