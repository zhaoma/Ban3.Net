using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACCESS_DENIED_CALLBACK_ACE structure defines an access control entry (ACE) for the discretionary access control list (DACL) that controls access to an object.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_callback_ace
    /// </summary>
    public struct ACCESS_DENIED_CALLBACK_ACE
    {

        public ACE_HEADER Header;
        public ACCESS_MASK Mask;
        public uint SidStart;
    }
}