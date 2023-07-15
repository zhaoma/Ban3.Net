using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OBJECT_TYPE_LIST structure identifies an object type element in a hierarchy of object types. The AccessCheckByType functions use an array of OBJECT_TYPE_LIST structures to define a hierarchy of an object and its subobjects, such as property sets and properties.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-object_type_list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OBJECT_TYPE_LIST
    {    
        /// WORD->unsigned short
        public ushort Level;

        /// WORD->unsigned short
        public ushort Sbz;

        /// GUID*
        public System.IntPtr ObjectType;

    }
}