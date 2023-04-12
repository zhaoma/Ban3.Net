using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the pointer input type.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_type_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTER_TYPE_INFO
    {
        /// UINT->unsigned int
        public uint type;

        /// Anonymous_f385d0f1_0669_495c_a447_7f73dbe69570
        public POINTER_TYPE_INFO_UNION Union1;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct POINTER_TYPE_INFO_UNION
    {

        /// UINT->unsigned int
        [FieldOffset(0)]
        public uint touchInfo;

        /// UINT->unsigned int
        [FieldOffset(0)]
        public uint penInfo;
    }
}