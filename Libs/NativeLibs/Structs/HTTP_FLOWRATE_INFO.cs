using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The transfer rate of a response
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_flowrate_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_FLOWRATE_INFO
    {

        /// PVOID->void*
        public HTTP_PROPERTY_FLAGS Flags;

        /// ULONG->unsigned int
        public uint MaxBandwidth;

        /// ULONG->unsigned int
        public uint MaxPeakBandwidth;

        /// ULONG->unsigned int
        public uint BurstSize;
    }

}