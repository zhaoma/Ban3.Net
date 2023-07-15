namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POLICY_AUDIT_EVENT_TYPE enumeration defines values that indicate the types of events the system can audit. The LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this enumeration when their InformationClass parameters are set to PolicyAuditEventsInformation.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_audit_event_type
    /// </summary>
    public enum POLICY_AUDIT_EVENT_TYPE
    {
        AuditCategorySystem = 0,
        AuditCategoryLogon,
        AuditCategoryObjectAccess,
        AuditCategoryPrivilegeUse,
        AuditCategoryDetailedTracking,
        AuditCategoryPolicyChange,
        AuditCategoryAccountManagement,
        AuditCategoryDirectoryServiceAccess,
        AuditCategoryAccountLogon
    }
}