using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// securitybaseapi.h This header is used by multiple technologies.
    ///     Event Tracing
    ///     Security and Identity
    /// This file is Event Tracing parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/
    /// https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-cveeventwrite
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         *
        1234 (0x04d2),  (0x), CveEventWrite, KERNELBASE.CveEventWrite, None
         *
         */

        /// <summary>
        /// A tracing function for publishing events when an attempted security vulnerability exploit is detected in your user-mode application.
        /// https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-cveeventwrite
        /// </summary>
        /// <param name="CveId">
        /// A pointer to the CVE ID associated with the vulnerability for which this event is being raised.
        /// </param>
        /// <param name="AdditionalDetails">
        /// A pointer to a string giving additional details that the event producer may want to provide to the consumer of this event.
        /// </param>
        /// <returns>
        /// Returns ERROR_SUCCESS if successful or one of the following values on error.
        /// ERROR_INVALID_PARAMETER
        /// ERROR_ARITHMETIC_OVERFLOW
        /// ERROR_MORE_DATA
        /// ERROR_NOT_ENOUGH_MEMORY
        /// STATUS_LOG_FILE_FULL
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int CveEventWrite(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string CveId,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string AdditionalDetails
        );

    }
}
