using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct LARGE_INTEGER
    {
        [FieldOffset(0)]
        public LARGE_INTEGER_PART DUMMYSTRUCTNAME;

        [FieldOffset(0)]
        public LARGE_INTEGER_PART u;

        [FieldOffset(0)]
        public ulong QuadPart;
    }
}
