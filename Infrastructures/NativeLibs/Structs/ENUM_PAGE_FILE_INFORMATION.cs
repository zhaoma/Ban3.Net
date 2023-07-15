using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a pagefile.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-enum_page_file_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENUM_PAGE_FILE_INFORMATION
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public uint cb;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public uint Reserved;

        /// <summary>
        /// The total size of the pagefile, in pages.
        /// </summary>
        public uint TotalSize;

        /// <summary>
        /// The current pagefile usage, in pages.
        /// </summary>
        public uint TotalInUse;

        /// <summary>
        /// The peak pagefile usage, in pages.
        /// </summary>
        public uint PeakUsage;
    }
}