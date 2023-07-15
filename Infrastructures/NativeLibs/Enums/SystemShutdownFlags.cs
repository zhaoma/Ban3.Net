using System;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// One or more bit flags that specify options for the shutdown.
    /// </summary>
    [Flags]
    public enum SystemShutdownFlags:uint
    {
        /// <summary>
        /// All sessions are forcefully logged off. 
        /// If this flag is not set and users other than the current user are logged on to the computer specified by the lpMachineName parameter, 
        /// this function fails with a return value of ERROR_SHUTDOWN_USERS_LOGGED_ON.
        /// </summary>
        SHUTDOWN_FORCE_OTHERS=0x00000001,

        /// <summary>
        /// Specifies that the originating session is logged off forcefully. If this flag is not set, 
        /// the originating session is shut down interactively, 
        /// so a shutdown is not guaranteed even if the function returns successfully.
        /// </summary>
        SHUTDOWN_FORCE_SELF=0x00000002,

        /// <summary>
        /// Overrides the grace period so that the computer is shut down immediately.
        /// </summary>
        SHUTDOWN_GRACE_OVERRIDE=0x00000020,

        /// <summary>
        /// Beginning with InitiateShutdown running on Windows 8, 
        /// you must include the SHUTDOWN_HYBRID flag with one or more of the flags in this table to specify options for the shutdown.
        /// 
        /// Beginning with Windows 8, InitiateShutdown always initiate a full system shutdown if the SHUTDOWN_HYBRID flag is absent.
        /// </summary>
        SHUTDOWN_HYBRID=0x00000200,

        /// <summary>
        /// The computer installs any updates before starting the shutdown.
        /// </summary>
        SHUTDOWN_INSTALL_UPDATES=0x00000040,

        /// <summary>
        /// The computer is shut down but is not powered down or rebooted.
        /// </summary>
        SHUTDOWN_NOREBOOT=0x00000010,

        /// <summary>
        /// The computer is shut down and powered down.
        /// </summary>
        SHUTDOWN_POWEROFF=0x00000008,

        /// <summary>
        /// The computer is shut down and rebooted.
        /// </summary>
        SHUTDOWN_RESTART=0x00000004,

        /// <summary>
        /// The system is rebooted using the ExitWindowsEx function with the EWX_RESTARTAPPS flag.
        /// This restarts any applications that have been registered for restart using the RegisterApplicationRestart function.
        /// </summary>
        SHUTDOWN_RESTARTAPPS=0x00000080
    }
}
