using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_LOGGING_INFO structure is used to enable server side logging on a URL Group or on a server session.
    /// This structure must be used when setting or querying the HttpServerLoggingProperty on a URL Group or server session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_logging_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_LOGGING_INFO
    {

        /// ULONG->unsigned int
        public HTTP_PROPERTY_FLAGS Flags;

        /// ULONG->unsigned int
        public uint LoggingFlags;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string SoftwareName;

        /// USHORT->unsigned short
        public ushort SoftwareNameLength;

        /// USHORT->unsigned short
        public ushort DirectoryNameLength;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string DirectoryName;

        /// ULONG->unsigned int
        public HTTP_LOGGING_TYPE Format;

        /// ULONG->unsigned int
        public uint Fields;

        /// PVOID->void*
        public System.IntPtr pExtFields;

        /// USHORT->unsigned short
        public ushort NumOfExtFields;

        /// USHORT->unsigned short
        public ushort MaxRecordSize;

        /// ULONG->unsigned int
        public HTTP_LOGGING_ROLLOVER_TYPE RolloverType;

        /// ULONG->unsigned int
        public uint RolloverSize;

        /// PSECURITY_DESCRIPTOR->PVOID->void*
        public System.IntPtr pSecurityDescriptor;
    }

}