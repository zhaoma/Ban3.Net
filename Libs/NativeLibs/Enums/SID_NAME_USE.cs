namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The SID_NAME_USE enumeration contains values that specify the type of a security identifier (SID).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-sid_name_use
    /// </summary>
    public enum SID_NAME_USE
    {
        SidTypeUser = 1,
        SidTypeGroup,
        SidTypeDomain,
        SidTypeAlias,
        SidTypeWellKnownGroup,
        SidTypeDeletedAccount,
        SidTypeInvalid,
        SidTypeUnknown,
        SidTypeComputer,
        SidTypeLabel,
        SidTypeLogonSession
    }
}