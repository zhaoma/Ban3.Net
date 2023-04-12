using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LOAD_DLL_DEBUG_INFO
    {

        /// HANDLE->void*
        public System.IntPtr hFile;

        /// LPVOID->void*
        public System.IntPtr lpBaseOfDll;

        /// DWORD->unsigned int
        public uint dwDebugInfoFileOffset;

        /// DWORD->unsigned int
        public uint nDebugInfoSize;

        /// LPVOID->void*
        public System.IntPtr lpImageName;

        /// WORD->unsigned short
        public ushort fUnicode;
    }

}