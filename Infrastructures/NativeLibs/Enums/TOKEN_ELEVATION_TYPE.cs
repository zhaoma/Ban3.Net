namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TOKEN_ELEVATION_TYPE enumeration indicates the elevation type of token being queried by the GetTokenInformation function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-token_elevation_type
    /// </summary>
    public enum TOKEN_ELEVATION_TYPE
    {
        TokenElevationTypeDefault = 1,
        TokenElevationTypeFull,
        TokenElevationTypeLimited
    }
}