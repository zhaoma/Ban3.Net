using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SID_AND_ATTRIBUTES structure represents a security identifier (SID) and its attributes.
    /// SIDs are used to uniquely identify users or groups.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid_and_attributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SID_AND_ATTRIBUTES
    {
        public SID Sid;

        public uint Attributes;
    }
}