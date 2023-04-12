namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_CACHE_POLICY_TYPE enumeration type defines available cache policies.
    /// It is used to restrict the values of the Policy member of the HTTP_CACHE_POLICY structure,
    /// which in turn is used in the pCachePolicy parameter of the HttpAddFragmentToCache function to specify how a response fragment is cached.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_cache_policy_type
    /// </summary>
    public enum HTTP_CACHE_POLICY_TYPE
    {
        /// <summary>
        /// Do not cache this value at all.
        /// </summary>
        HttpCachePolicyNocache,

        /// <summary>
        /// Cache this value until the user provides a different one.
        /// </summary>
        HttpCachePolicyUserInvalidates,

        /// <summary>
        /// Cache this value for a specified time and then remove it from the cache.
        /// </summary>
        HttpCachePolicyTimeToLive,

        /// <summary>
        /// Terminates the enumeration; not used to determine policy.
        /// </summary>
        HttpCachePolicyMaximum
    }
}