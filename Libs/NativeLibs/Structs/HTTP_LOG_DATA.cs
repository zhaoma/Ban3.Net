using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_LOG_DATA structure contains a value that specifies the type of the log data.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_log_data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_LOG_DATA
    {

        /// ULONG->unsigned int
        public HTTP_LOG_DATA_TYPE Type;
    }

}