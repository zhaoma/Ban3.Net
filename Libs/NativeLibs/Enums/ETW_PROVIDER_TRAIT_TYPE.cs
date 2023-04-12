namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the types of Provider Traits supported by Event Tracing for Windows (ETW).
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ne-evntcons-etw_provider_trait_type
    /// </summary>
    public enum ETW_PROVIDER_TRAIT_TYPE : byte
    {
        /// <summary>
        /// ETW Provider trait group.
        /// </summary>
        EtwProviderTraitTypeGroup,

        /// <summary>
        /// ETW Provider trait decode GUID.
        /// </summary>
        EtwProviderTraitDecodeGuid,

        /// <summary>
        /// ETW Provider trait type maximum.
        /// </summary>
        EtwProviderTraitTypeMax

    }
}