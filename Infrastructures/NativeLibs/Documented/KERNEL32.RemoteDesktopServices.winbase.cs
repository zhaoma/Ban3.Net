using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    /// This file is Remote Desktop Services parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-wtsgetactiveconsolesessionid
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         *
        1509 (0x05e5),  (0x), WTSGetActiveConsoleSessionId, 0x00020c60, None
         *
         */

        /// <summary>
        /// Retrieves the session identifier of the console session.
        /// The console session is the session that is currently attached to the physical console.
        /// Note that it is not necessary that Remote Desktop Services be running for this function to succeed.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-wtsgetactiveconsolesessionid
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint WTSGetActiveConsoleSessionId();

    }
}
