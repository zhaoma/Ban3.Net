namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_LOGGING_TYPE enumeration defines the type of logging that is performed.
    /// This enumeration is used in the HTTP_LOGGING_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_logging_type
    /// </summary>
    public enum HTTP_LOGGING_TYPE
    {
        /// <summary>
        /// The log format is W3C style extended logging.
        /// </summary>
        HttpLoggingTypeW3C,

        /// <summary>
        /// The log format is IIS5/6 style logging.
        /// </summary>
        HttpLoggingTypeIIS,

        /// <summary>
        /// The log format is NCSA style logging. 
        /// </summary>
        HttpLoggingTypeNCSA,

        /// <summary>
        /// The log format is centralized binary logging.
        /// </summary>
        HttpLoggingTypeRaw
    }
}