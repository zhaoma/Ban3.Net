using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// provided for compatibility with 16-bit versions of Windows. 
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-_lclose
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         
        _hread
        _hwrite
        _lclose
        _lcreat
        _llseek
        _lopen
        _lread
        _lwrite

         */

        /// <summary>
        /// The _lclose function closes the specified file so that it is no longer available for reading or writing. 
        /// This function is provided for compatibility with 16-bit versions of Windows. 
        /// Win32-based applications should use the CloseHandle function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-_lclose
        /// </summary>
        /// <param name="hFile"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int _lclose(
            int hFile
            );

        /// <summary>
        /// Creates or opens the specified file. This documentation is included only for troubleshooting existing code.
        /// </summary>
        /// <param name="lpPathName"></param>
        /// <param name="hFile"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int _lcreat(
            string lpPathName,
            int hFile
            );

        /// <summary>
        /// Repositions the file pointer for the specified file.
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lOffset"></param>
        /// <param name="iOrigin"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int _llseek(
            int hFile, 
            int lOffset, 
            int iOrigin
            );

        /// <summary>
        /// The _lopen function opens an existing file and sets the file pointer to the beginning of the file. 
        /// This function is provided for compatibility with 16-bit versions of Windows. 
        /// Win32-based applications should use the CreateFile function.
        /// </summary>
        /// <param name="lpPathName"></param>
        /// <param name="iReadWrite"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int _lopen(
            string lpPathName,
            int iReadWrite
            );

        /// <summary>
        /// The _lread function reads data from the specified file. 
        /// This function is provided for compatibility with 16-bit versions of Windows. 
        /// Win32-based applications should use the ReadFile function.
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="uBytes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint _lread(
            int hFile,
            byte[] lpBuffer,
            uint uBytes
            );

        /// <summary>
        /// Writes data to the specified file.
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="uBytes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint _lwrite(
            int hFile,
            byte[] lpBuffer,
            uint uBytes
            );
    }
}
