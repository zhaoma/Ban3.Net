using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RIP_INFO
    {

        /// DWORD->unsigned int
        public uint dwError;

        /// DWORD->unsigned int
        public uint dwType;
    }

}