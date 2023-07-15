
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    /// This file is Data Exchange parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         
        5 (0x0005),  (0x), AddAtomA, 0x0005a800, None
        6 (0x0006),  (0x), AddAtomW, 0x000128f0, None
        275 (0x0113),  (0x), DeleteAtom, 0x00012860, None
        381 (0x017d),  (0x), FindAtomA, 0x00015820, None
        382 (0x017e),  (0x), FindAtomW, 0x00012d10, None
        454 (0x01c6),  (0x), GetAtomNameA, 0x0005a820, None
        455 (0x01c7),  (0x), GetAtomNameW, 0x00012630, None
        822 (0x0336),  (0x), GlobalAddAtomA, 0x00012660, None
        823 (0x0337),  (0x), GlobalAddAtomExA, 0x0005a850, None
        824 (0x0338),  (0x), GlobalAddAtomExW, 0x00013190, None
        825 (0x0339),  (0x), GlobalAddAtomW, 0x00012910, None
        828 (0x033c),  (0x), GlobalDeleteAtom, 0x00012850, None
        829 (0x033d),  (0x), GlobalFindAtomA, 0x0005a870, None
        830 (0x033e),  (0x), GlobalFindAtomW, 0x00012e00, None
        834 (0x0342),  (0x), GlobalGetAtomNameA, 0x0005a890, None
        835 (0x0343),  (0x), GlobalGetAtomNameW, 0x00012680, None
        867 (0x0363),  (0x), InitAtomTable, 0x0005a8c0, None

         */

        /// <summary>
        /// AddAtomA;AddAtomW
        /// </summary>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern ushort AddAtom(
            string lpString);

        /// <summary>
        /// Decrements the reference count of a local string atom. 
        /// If the atom's reference count is reduced to zero, 
        /// DeleteAtom removes the string associated with the atom from the local atom table.
        /// </summary>
        /// <param name="nAtom"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern ushort DeleteAtom(
            ushort nAtom);


        [DllImport(Dll, SetLastError = true)]
        public static extern ushort FindAtom(
            string lpString);


        [DllImport(Dll, SetLastError = true)]
        public static extern ushort GetAtomName(
            ushort nAtom,
            ref string lpBuffer,
            int nSize);

        [DllImport(Dll, SetLastError = true)]
        public static extern ushort GlobalAddAtom(
            string lpString);

        [DllImport(Dll, SetLastError = true)]
        public static extern ushort GlobalAddAtomEx(
            string lpString,
            int flags);

        [DllImport(Dll, SetLastError = true)]
        public static extern ushort GlobalDeleteAtom(
            ushort nAtom);

        [DllImport(Dll, SetLastError = true)]
        public static extern ushort GlobalFindAtom(
            string lpString);

        [DllImport(Dll, SetLastError = true)]
        public static extern ushort GlobalGetAtomName(
            ushort nAtom,
            ref string lpBuffer,
            int nSize);

        /// <summary>
        /// The number of hash buckets to use for the atom table. 
        /// If this parameter is zero, the default number of hash buckets are created.
        /// </summary>
        /// <param name="nSize"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool InitAtomTable(
            int nSize
            );
    }
}
