using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACL structure is the header of an access control list (ACL). 
    /// A complete ACL consists of an ACL structure followed by an ordered list of zero or more access control entries (ACEs).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-acl
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACL
    {
        /*
            winnt.h
            typedef struct _ACL {
              BYTE AclRevision;
              BYTE Sbz1;
              WORD AclSize;
              WORD AceCount;
              WORD Sbz2;
            } ACL;
     
         */

        /// <summary>
        /// Specifies the revision level of the ACL. 
        /// This value should be ACL_REVISION, unless the ACL contains an object-specific ACE, 
        /// in which case this value must be ACL_REVISION_DS. 
        /// All ACEs in an ACL must be at the same revision level.
        /// </summary>
        public byte AclRevision;

        /// <summary>
        /// Specifies a zero byte of padding that aligns the AclRevision member on a 16-bit boundary.
        /// </summary>
        public byte Sbz1;

        /// <summary>
        /// Specifies the size, in bytes, of the ACL. This value includes both the ACL structure and all the ACEs.
        /// </summary>
        public ushort AclSize;

        /// <summary>
        /// Specifies the number of ACEs stored in the ACL.
        /// </summary>
        public ushort AceCount;

        /// <summary>
        /// Specifies two zero-bytes of padding that align the ACL structure on a 32-bit boundary.
        /// </summary>
        public ushort Sbz2;
    }

}
