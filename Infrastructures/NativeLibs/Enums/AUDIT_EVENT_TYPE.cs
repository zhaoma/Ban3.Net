namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The AUDIT_EVENT_TYPE enumeration type defines values that indicate the type of object being audited.
    /// The AccessCheckByTypeAndAuditAlarm and AccessCheckByTypeResultListAndAuditAlarm functions use these values.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-audit_event_type
    /// </summary>
    public enum AUDIT_EVENT_TYPE
    {
        AuditEventObjectAccess,
        AuditEventDirectoryServiceAccess
    }
}