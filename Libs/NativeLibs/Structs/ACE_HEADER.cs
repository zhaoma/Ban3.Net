using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACE_HEADER structure defines the type and size of an access control entry (ACE).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-ace_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACE_HEADER
    {
        /// <summary>
        /// An unsigned 8-bit integer that specifies the ACE types. 
        /// </summary>
        public ACE_TYPE AceType;

        /// <summary>
        /// An unsigned 8-bit integer that specifies a set of ACE type-specific control flags.
        /// This field can be a combination of the following values.
        /// </summary>
        public ACE_FLAGS AceFlags;

        /// <summary>
        /// An unsigned 16-bit integer that specifies the size, in bytes, of the ACE.
        /// The AceSize field can be greater than the sum of the individual fields, but MUST be a multiple of 4 to ensure alignment on a DWORD boundary.
        /// In cases where the AceSize field encompasses additional data for the callback ACEs types, that data is implementation-specific.
        /// Otherwise, this additional data is not interpreted and MUST be ignored.
        /// </summary>
        public ushort AceSize;
    }
}