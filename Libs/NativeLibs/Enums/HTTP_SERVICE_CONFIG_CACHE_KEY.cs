namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Used in the HttpSetServiceConfiguration and HttpQueryServiceConfiguration functions.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_cache_key
    /// </summary>
    public enum HTTP_SERVICE_CONFIG_CACHE_KEY
    {
        MaxCacheResponseSize = 0,
        CacheRangeChunkSize
    }
}