using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The AUDIT_POLICY_INFORMATION structure specifies a security event type and when to audit that type.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-audit_policy_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AUDIT_POLICY_INFORMATION
    {
        /// GUID->_GUID
        public GUID AuditSubCategoryGuid;

        /// ULONG->unsigned int
        public uint AuditingInformation;

        /// GUID->_GUID
        public GUID AuditCategoryGuid;
    }
}