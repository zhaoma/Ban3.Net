using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_DATA_CHUNK structure represents an individual block of data either in memory, in a file, or in the HTTP Server API response-fragment cache.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_data_chunk
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DATA_CHUNK
    {
        /// PVOID->void*
        public HTTP_DATA_CHUNK_TYPE DataChunkType;

        /// Anonymous_2874442d_10e2_4db6_a93b_941bc88da8a1
        public HTTP_DATA_CHUNK_UNION Union1;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct HTTP_DATA_CHUNK_UNION
    {

        /// Anonymous_f39e7408_b244_4c19_82d6_e160a8461df0
        [FieldOffset(0)]
        public HTTP_DATA_CHUNK_FROMMEMORY FromMemory;

        /// Anonymous_6b2e8af6_cf71_4053_994c_b4a88166ea7a
        [FieldOffset(0)]
        public HTTP_DATA_CHUNK_FROMFILEHANDLE FromFileHandle;

        /// Anonymous_85406a61_62a8_4eb6_8f68_99975cdf9989
        [FieldOffset(0)]
        public HTTP_DATA_CHUNK_FROMFRAGMENTCACHE FromFragmentCache;

        /// Anonymous_abf5fa5e_0fd1_46cb_ac4d_ff4af89a58d2
        [FieldOffset(0)]
        public HTTP_DATA_CHUNK_FROMFRAGMENTCACHEEX FromFragmentCacheEx;

        /// Anonymous_3e4042da_b2cc_434e_ad04_9cfb0fa1ed64
        [FieldOffset(0)]
        public HTTP_DATA_CHUNK_TRAILERS Trailers;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DATA_CHUNK_FROMMEMORY
    {

        /// PVOID->void*
        public System.IntPtr pBuffer;

        /// ULONG->unsigned int
        public uint BufferLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DATA_CHUNK_FROMFILEHANDLE
    {

        /// ULONG->unsigned int
        public HTTP_BYTE_RANGE ByteRange;

        /// HANDLE->void*
        public System.IntPtr FileHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DATA_CHUNK_FROMFRAGMENTCACHE
    {

        /// USHORT->unsigned short
        public ushort FragmentNameLength;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pFragmentName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DATA_CHUNK_FROMFRAGMENTCACHEEX
    {

        /// ULONG->unsigned int
        public HTTP_BYTE_RANGE ByteRange;

        /// PCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pFragmentName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_DATA_CHUNK_TRAILERS
    {

        /// USHORT->unsigned short
        public ushort TrailerCount;

        /// PVOID->void*
        public System.IntPtr pTrailers;
    }
}