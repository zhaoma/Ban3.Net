namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The MSV1_0_LOGON_SUBMIT_TYPE enumeration indicates the kind of logon being requested.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-msv1_0_logon_submit_type
    /// </summary>
    public enum MSV1_0_LOGON_SUBMIT_TYPE
    {
        MsV1_0InteractiveLogon = 2,
        MsV1_0Lm20Logon,
        MsV1_0NetworkLogon,
        MsV1_0SubAuthLogon,
        MsV1_0WorkstationUnlockLogon = 7,
        MsV1_0S4ULogon = 12,
        MsV1_0VirtualLogon = 82,
        MsV1_0NoElevationLogon = 83,
        MsV1_0LuidLogon = 84
    }
}