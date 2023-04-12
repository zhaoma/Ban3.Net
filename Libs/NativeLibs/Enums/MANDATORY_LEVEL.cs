namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The MANDATORY_LEVEL enumeration lists the possible security levels.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-mandatory_level
    /// </summary>
    public enum MANDATORY_LEVEL
    {
        MandatoryLevelUntrusted = 0,
        MandatoryLevelLow,
        MandatoryLevelMedium,
        MandatoryLevelHigh,
        MandatoryLevelSystem,
        MandatoryLevelSecureProcess,
        MandatoryLevelCount
    }
}