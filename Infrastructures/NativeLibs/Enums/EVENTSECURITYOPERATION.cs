namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines what component of the security descriptor that the EventAccessControl function modifies.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ne-evntcons-eventsecurityoperation
    /// </summary>
    public enum EVENTSECURITYOPERATION
    {
        EventSecuritySetDACL,
        EventSecuritySetSACL,
        EventSecurityAddDACL,
        EventSecurityAddSACL,
        EventSecurityMax
    }
}