namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRUSTEE_TYPE enumeration contains values that indicate the type of trustee identified by a TRUSTEE structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ne-accctrl-trustee_type
    /// </summary>
    public enum TRUSTEE_TYPE
    {
        TRUSTEE_IS_UNKNOWN,
        TRUSTEE_IS_USER,
        TRUSTEE_IS_GROUP,
        TRUSTEE_IS_DOMAIN,
        TRUSTEE_IS_ALIAS,
        TRUSTEE_IS_WELL_KNOWN_GROUP,
        TRUSTEE_IS_DELETED,
        TRUSTEE_IS_INVALID,
        TRUSTEE_IS_COMPUTER
    }
}