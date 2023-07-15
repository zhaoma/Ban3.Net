using System;
using System.Runtime.InteropServices;
using System.Text;
using Ban3.Infrastructures.NativeLibs.Structs;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winefs.h This header is used by Data Access and Storage.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1030 (0x0406),  (0x), AddUsersToEncryptedFile, 0x00033610, None
        1241 (0x04d9),  (0x), DuplicateEncryptionInfoFile, 0x00033800, None
        1271 (0x04f7),  (0x), EncryptionDisable, 0x000339d0, None
        1308 (0x051c),  (0x), FreeEncryptionCertificateHashList, 0x00033ba0, None
        1586 (0x0632),  (0x), QueryRecoveryAgentsOnEncryptedFile, 0x00033d90, None
        1603 (0x0643),  (0x), QueryUsersOnEncryptedFile, 0x00033df0, None
        1706 (0x06aa),  (0x), RemoveUsersFromEncryptedFile, 0x00033e80, None
        1762 (0x06e2),  (0x), SetUserFileEncryptionKey, 0x00033ef0, None
         
         */

        /// <summary>
        /// Adds user keys to the specified encrypted file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-adduserstoencryptedfile
        /// </summary>
        /// <param name="lpFileName">The name of the encrypted file.</param>
        /// <param name="EncryptionCertificates">
        /// A pointer to an ENCRYPTION_CERTIFICATE_LIST structure that contains the list of new user keys to be added to the file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern uint AddUsersToEncryptedFile(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpFileName,
            ENCRYPTION_CERTIFICATE_LIST EncryptionCertificates
            );

        /// <summary>
        /// Copies the EFS metadata from one file or directory to another.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-duplicateencryptioninfofile
        /// </summary>
        /// <param name="SrcFileName">
        /// The name of the file or directory from which the EFS metadata is to be copied. This source file or directory must be encrypted.
        /// </param>
        /// <param name="DstFileName">
        /// The name of the file or directory to which the EFS metadata is to be copied.
        /// This destination file or directory does not have to be encrypted before the call to this function; 
        /// however if this function completes successfully, it will be encrypted.
        /// </param>
        /// <param name="dwCreationDistribution">
        /// Describes how the destination file or directory identified by the DstFileName parameter value is to be opened.
        /// CREATE_ALWAYS=2;    Always create the destination file or directory. Any value passed in this parameter other than CREATE_NEW will be processed as CREATE_ALWAYS.
        /// CREATE_NEW=1;       Create the destination file or directory only if it does not already exist. If it does exist, and this value is specified, this function will fail.
        /// </param>
        /// <param name="dwAttributes">
        /// The file attributes of the destination file or directory. The FILE_READ_ONLY attribute is currently not processed by this function.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure that specifies the security attributes of the destination file or directory, 
        /// if it does not already exist. If you specify NULL, the file or directory gets a default security descriptor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint DuplicateEncryptionInfoFile(
            [MarshalAs(UnmanagedType.LPWStr)] string SrcFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string DstFileName,
            uint dwCreationDistribution,
            uint dwAttributes,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes);

        /// <summary>
        /// Disables or enables encryption of the specified directory and the files in it. 
        /// It does not affect encryption of subdirectories below the indicated directory.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-encryptiondisable
        /// </summary>
        /// <param name="DirPath">The name of the directory for which to enable or disable encryption.</param>
        /// <param name="Disable">Indicates whether to disable encryption (TRUE) or enable it (FALSE).</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EncryptionDisable(
            [MarshalAs(UnmanagedType.LPWStr)] string DirPath,
            [MarshalAs(UnmanagedType.Bool)] bool Disable
            );

        /// <summary>
        /// Frees a certificate hash list.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-freeencryptioncertificatehashlist
        /// </summary>
        /// <param name="pUsers">
        /// A pointer to a certificate hash list structure, ENCRYPTION_CERTIFICATE_HASH_LIST, 
        /// which was returned by the QueryUsersOnEncryptedFile or QueryRecoveryAgentsOnEncryptedFile function.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void FreeEncryptionCertificateHashList(
            ref ENCRYPTION_CERTIFICATE_HASH_LIST pUsers
            );

        /// <summary>
        /// Retrieves a list of recovery agents for the specified file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-queryrecoveryagentsonencryptedfile
        /// </summary>
        /// <param name="lpFileName">The name of the file.</param>
        /// <param name="pRecoveryAgents">
        /// A pointer to a ENCRYPTION_CERTIFICATE_HASH_LIST structure that receives a list of recovery agents.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a system error code. 
        /// For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryRecoveryAgentsOnEncryptedFile(
            [MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
            ref IntPtr pRecoveryAgents
            );

        /// <summary>
        /// Retrieves a list of users for the specified file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-queryusersonencryptedfile
        /// </summary>
        /// <param name="lpFileName">The name of the file.</param>
        /// <param name="pUsers">
        /// A pointer to a ENCRYPTION_CERTIFICATE_HASH_LIST structure that receives the list of users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint QueryUsersOnEncryptedFile(
            [MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
            ref IntPtr pUsers
            );

        /// <summary>
        /// Removes specified certificate hashes from a specified file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-removeusersfromencryptedfile
        /// </summary>
        /// <param name="lpFileName">The name of the file.</param>
        /// <param name="pHashes">
        /// A pointer to an ENCRYPTION_CERTIFICATE_HASH_LIST structure that contains a list of certificate hashes to be removed from the file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RemoveUsersFromEncryptedFile(
            [MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
            ref ENCRYPTION_CERTIFICATE_HASH_LIST pHashes
            );

        /// <summary>
        /// Sets the user's current key to the specified certificate.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-setuserfileencryptionkey
        /// </summary>
        /// <param name="pEncryptionCertificate">
        /// A pointer to a certificate that will be the user's key. This parameter is a pointer to an ENCRYPTION_CERTIFICATE structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint SetUserFileEncryptionKey(
            ref ENCRYPTION_CERTIFICATE pEncryptionCertificate
            );
    }
}
