namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines constants that specify an identifier for an HTTP feature.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_feature_id
    /// </summary>
    public enum HTTP_FEATURE_ID:uint
    {
        /// <summary>
        /// Specifies an unknown feature.
        /// </summary>
        HttpFeatureUnknown = 0,

        /// <summary>
        /// Specifies HTTP response trailers.
        /// </summary>
        HttpFeatureResponseTrailers = 1,

        /// <summary>
        /// Specifies HTTP API timings.
        /// </summary>
        HttpFeatureApiTimings = 2,

        /// <summary>
        /// Specifies a request for delegation.
        /// </summary>
        HttpFeatureDelegateEx = 3,
        HttpFeatureHttp3,
        HttpFeatureLast,

        /// <summary>
        /// Specifies the maximum number of supported features.
        /// </summary>
        HttpFeaturemax = 0xFFFFFFFF
    }
}