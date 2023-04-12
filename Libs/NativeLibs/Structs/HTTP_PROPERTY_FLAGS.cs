using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_PROPERTY_FLAGS structure is used by the property configuration structures to enable or disable a property on a configuration object when setting property configurations.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_property_flags
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_PROPERTY_FLAGS
    {

        /// Present : 1
        public uint bitvector1;

        public uint Present
        {
            get
            {
                return ((uint)((this.bitvector1 & 1u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }
    }
}