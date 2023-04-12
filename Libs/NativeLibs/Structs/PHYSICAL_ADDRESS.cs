using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PHYSICAL_ADDRESS
    {
        [FieldOffset(0)]
        public LARGE_INTEGER_PART DUMMYSTRUCTNAME;

        [FieldOffset(0)]
        public LARGE_INTEGER_PART u;

        [FieldOffset(0)]
        public int QuadPart;
    }
}
