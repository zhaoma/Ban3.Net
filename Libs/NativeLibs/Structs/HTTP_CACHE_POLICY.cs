using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_CACHE_POLICY structure is used to define a cache policy associated with a cached response fragment.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_cache_policy
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_CACHE_POLICY
    {
        /// ULONG->unsigned int
        public HTTP_CACHE_POLICY_TYPE Policy;

        /// ULONG->unsigned int
        public uint SecondsToLive;
    }
}