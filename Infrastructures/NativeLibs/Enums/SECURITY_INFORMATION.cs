using System;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// typedef ULONG SECURITY_INFORMATION, *PSECURITY_INFORMATION;
    /// A value of type SECURITY_INFORMATION is used to identify the object-related security information being set or queried.
    /// This security information includes:
    /// The owner of an object
    /// The primary group of an object
    /// The discretionary access-control list (DACL) of an object
    /// The system ACL (SACL) of an object
    /// Each item of security information is designated by a bit flag.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ifs/security-information
    /// https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/cca27429-5689-4a16-b2b4-9325d93e4ba2
    /// </summary>
    [Flags]
    public enum SECURITY_INFORMATION : uint
    {
        /// <summary>
        /// The owner identifier of the object is being referenced.
        /// </summary>
        OWNER_SECURITY_INFORMATION = 0x00000001,

        /// <summary>
        /// The primary group identifier of the object is being referenced.
        /// </summary>
        GROUP_SECURITY_INFORMATION = 0x00000002,

        /// <summary>
        /// The DACL of the object is being referenced.
        /// </summary>
        DACL_SECURITY_INFORMATION = 0x00000004,

        /// <summary>
        /// The SACL of the object is being referenced.
        /// </summary>
        SACL_SECURITY_INFORMATION = 0x00000008,

        /// <summary>
        /// The mandatory integrity label is being referenced.
        /// </summary>
        LABEL_SECURITY_INFORMATION = 0x00000010,

        /// <summary>
        /// The SACL inherits access control entries (ACEs) from the parent object.
        /// </summary>
        UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000,

        /// <summary>
        /// The DACL inherits ACEs from the parent object.
        /// </summary>
        UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,

        /// <summary>
        /// The SACL cannot inherit ACEs.
        /// </summary>
        PROTECTED_SACL_SECURITY_INFORMATION = 0x40000000,

        /// <summary>
        /// The DACL cannot inherit ACEs.
        /// </summary>
        PROTECTED_DACL_SECURITY_INFORMATION = 0x80000000,

        /// <summary>
        /// A SYSTEM_RESOURCE_ATTRIBUTE_ACE (section 2.4.4.15) is being referenced.
        /// </summary>
        ATTRIBUTE_SECURITY_INFORMATION = 0x00000020,

        /// <summary>
        /// A SYSTEM_SCOPED_POLICY_ID_ACE (section 2.4.4.16) is being referenced.
        /// </summary>
        SCOPE_SECURITY_INFORMATION = 0x00000040,

        /// <summary>
        /// Reserved.
        /// </summary>
        PROCESS_TRUST_LABEL_SECURITY_INFORMATION = 0x00000080,

        /// <summary>
        /// The security descriptor is being accessed for use in a backup operation.
        /// </summary>
        BACKUP_SECURITY_INFORMATION = 0x00010000

    }
}
