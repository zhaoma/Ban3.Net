namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines the data source for a data chunk.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_data_chunk_type
    /// </summary>
    public enum HTTP_DATA_CHUNK_TYPE
    {
        /// <summary>
        /// The data source is a memory data block. The union should be interpreted as a FromMemory structure.
        /// </summary>
        HttpDataChunkFromMemory,

        /// <summary>
        /// The data source is a file handle data block. The union should be interpreted as a FromFileHandle structure.
        /// </summary>
        HttpDataChunkFromFileHandle,

        /// <summary>
        /// The data source is a fragment cache data block. The union should be interpreted as a FromFragmentCache structure.
        /// </summary>
        HttpDataChunkFromFragmentCache,

        /// <summary>
        /// The data source is a fragment cache data block. The union should be interpreted as a FromFragmentCacheEx structure.
        /// Windows Server 2003 with SP1 and Windows XP with SP2:  This flag is not supported.
        /// </summary>
        HttpDataChunkFromFragmentCacheEx,

        /// <summary>
        /// The data source is a trailers data block. The union should be interpreted as a Trailers structure.
        /// Windows 10, version 2004 and prior:  This flag is not supported.
        /// </summary>
        HttpDataChunkTrailers,
        HttpDataChunkMaximum
    }
}