using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winreg.h This header is used by multiple technologies.
    ///     Developer Notes
    ///     Hyper-V WMI Provider
    ///     Security and Identity
    ///     System Services
    /// This file is System Services parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-abortsystemshutdowna
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1005 (0x03ed),  (0x), AbortSystemShutdownA, 0x00043be0, None
        1006 (0x03ee),  (0x), AbortSystemShutdownW, 0x00043c50, None
        1402 (0x057a),  (0x), InitiateShutdownA, 0x00043cb0, None
        1403 (0x057b),  (0x), InitiateShutdownW, 0x00023940, None
        1404 (0x057c),  (0x), InitiateSystemShutdownA, 0x00043d80, None
        1405 (0x057d),  (0x), InitiateSystemShutdownExA, 0x00043e60, None
        1406 (0x057e),  (0x), InitiateSystemShutdownExW, 0x00045690, None
        1407 (0x057f),  (0x), InitiateSystemShutdownW, 0x00043f40, None

         */

        /// <summary>
        /// Stops a system shutdown that has been initiated.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-abortsystemshutdowna
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer where the shutdown is to be stopped. 
        /// If lpMachineName is NULL or an empty string, the function stops the shutdown on the local computer.
        /// </param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AbortSystemShutdownA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMachineName
            );

        /// almost same as AbortSystemShutdownA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AbortSystemShutdownW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMachineName
            );

        /// <summary>
        /// Initiates a shutdown and restart of the specified computer, 
        /// and restarts any applications that have been registered for restart.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-initiateshutdowna
        /// </summary>
        /// <param name="lpMachineName">The name of the computer to be shut down. If the value of this parameter is NULL, the local computer is shut down.</param>
        /// <param name="lpMessage">The message to be displayed in the interactive shutdown dialog box.</param>
        /// <param name="dwGracePeriod">
        /// The number of seconds to wait before shutting down the computer. 
        /// If the value of this parameter is zero, the computer is shut down immediately. 
        /// This value is limited to MAX_SHUTDOWN_TIMEOUT.
        /// If the value of this parameter is greater than zero, 
        /// and the dwShutdownFlags parameter specifies the flag SHUTDOWN_GRACE_OVERRIDE, 
        /// the function fails and returns the error code ERROR_BAD_ARGUMENTS.
        /// </param>
        /// <param name="dwShutdownFlags">
        /// One or more bit flags that specify options for the shutdown. The following values are defined.
        /// </param>
        /// <param name="dwReason"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint InitiateShutdownA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMachineName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMessage,
            uint dwGracePeriod,
            uint dwShutdownFlags,
            uint dwReason
            );

        /// almost same as InitiateShutdownA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint InitiateShutdownW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMachineName,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMessage,
            uint dwGracePeriod,
            uint dwShutdownFlags,
            uint dwReason
            );

        /// <summary>
        /// Initiates a shutdown and optional restart of the specified computer.
        /// To record a reason for the shutdown in the event log, call the InitiateSystemShutdownEx function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-initiatesystemshutdowna
        /// </summary>
        /// <param name="lpMachineName">The network name of the computer to be shut down. If lpMachineName is NULL or an empty string, the function shuts down the local computer.</param>
        /// <param name="lpMessage">
        /// The message to be displayed in the shutdown dialog box. 
        /// This parameter can be NULL if no message is required.
        /// Windows Server 2003 and Windows XP:  This string is also stored as a comment in the event log entry.
        /// Windows Server 2003 and Windows XP with SP1:  The string is limited to 3072 TCHARs.
        /// </param>
        /// <param name="dwTimeout">
        /// The length of time that the shutdown dialog box should be displayed, in seconds. 
        /// While this dialog box is displayed, the shutdown can be stopped by the AbortSystemShutdown function.
        /// If dwTimeout is not zero, InitiateSystemShutdown displays a dialog box on the specified computer.
        /// If dwTimeout is zero, the computer shuts down without displaying the dialog box, and the shutdown cannot be stopped by AbortSystemShutdown.
        /// </param>
        /// <param name="bForceAppsClosed">
        /// If this parameter is TRUE, applications with unsaved changes are to be forcibly closed. Note that this can result in data loss.
        /// If this parameter is FALSE, the system displays a dialog box instructing the user to close the applications.
        /// </param>
        /// <param name="bRebootAfterShutdown">
        /// If this parameter is TRUE, the computer is to restart immediately after shutting down. 
        /// If this parameter is FALSE, the system flushes all caches to disk and safely powers down the system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitiateSystemShutdownA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMachineName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMessage, 
            uint dwTimeout, 
            [MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed, 
            [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown
            );

        /// almost same as InitiateSystemShutdownA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitiateSystemShutdownW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMachineName,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMessage,
            uint dwTimeout,
            [MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed,
            [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown
            );

        /// <summary>
        /// Initiates a shutdown and optional restart of the specified computer, 
        /// and optionally records the reason for the shutdown.
        /// </summary>
        /// <param name="lpMachineName">The network name of the computer to be shut down. If lpMachineName is NULL or an empty string, the function shuts down the local computer.</param>
        /// <param name="lpMessage">The message to be displayed in the shutdown dialog box. This parameter can be NULL if no message is required.</param>
        /// <param name="dwTimeout">The length of time that the shutdown dialog box should be displayed, in seconds.</param>
        /// <param name="bForceAppsClosed">
        /// If this parameter is TRUE, applications with unsaved changes are to be forcibly closed. 
        /// If this parameter is FALSE, the system displays a dialog box instructing the user to close the applications.
        /// </param>
        /// <param name="bRebootAfterShutdown">
        /// If this parameter is TRUE, the computer is to restart immediately after shutting down. 
        /// If this parameter is FALSE, the system flushes all caches to disk and safely powers down the system.
        /// </param>
        /// <param name="dwReason">The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes(Enums).</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitiateSystemShutdownExA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMachineName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMessage,
            uint dwTimeout,
            [MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed,
            [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown,
            uint dwReason
            );

        /// almost same as InitiateSystemShutdownExA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitiateSystemShutdownExW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMachineName,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpMessage,
            uint dwTimeout,
            [MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed,
            [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown,
            uint dwReason
            );
    }
}
