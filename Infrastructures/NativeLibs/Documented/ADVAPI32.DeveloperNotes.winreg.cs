using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winreg.h This header is used by multiple technologies.
    ///     Developer Notes
    ///     Hyper-V WMI Provider
    ///     Security and Identity
    ///     System Services
    /// This file is Developer Notes parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/
    /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regclosekey
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1607 (0x0647),  (0x), RegCloseKey, 0x0001eaf0, None
        1608 (0x0648),  (0x), RegConnectRegistryA, 0x000445e0, None
        1609 (0x0649),  (0x), RegConnectRegistryExA, 0x00044600, None
        1610 (0x064a),  (0x), RegConnectRegistryExW, 0x00024bf0, None
        1611 (0x064b),  (0x), RegConnectRegistryW, 0x00024bd0, None
        1612 (0x064c),  (0x), RegCopyTreeA, 0x00044880, None
        1613 (0x064d),  (0x), RegCopyTreeW, 0x000357c0, None
        1614 (0x064e),  (0x), RegCreateKeyA, 0x00022e20, None
        1615 (0x064f),  (0x), RegCreateKeyExA, 0x0001ef20, None
        1616 (0x0650),  (0x), RegCreateKeyExW, 0x0001ec00, None
        1617 (0x0651),  (0x), RegCreateKeyTransactedA, 0x000448e0, None
        1618 (0x0652),  (0x), RegCreateKeyTransactedW, 0x000237d0, None
        1619 (0x0653),  (0x), RegCreateKeyW, 0x0001f430, None
        1620 (0x0654),  (0x), RegDeleteKeyA, 0x0001f080, None
        1621 (0x0655),  (0x), RegDeleteKeyExA, 0x000357e0, None
        1622 (0x0656),  (0x), RegDeleteKeyExW, 0x000223f0, None
        1623 (0x0657),  (0x), RegDeleteKeyTransactedA, 0x00044ac0, None
        1624 (0x0658),  (0x), RegDeleteKeyTransactedW, 0x00022b50, None
        1625 (0x0659),  (0x), RegDeleteKeyValueA, 0x00035800, None
        1626 (0x065a),  (0x), RegDeleteKeyValueW, 0x00035820, None
        1627 (0x065b),  (0x), RegDeleteKeyW, 0x0001f0d0, None
        1628 (0x065c),  (0x), RegDeleteTreeA, 0x00035840, None
        1629 (0x065d),  (0x), RegDeleteTreeW, 0x00024590, None
        1630 (0x065e),  (0x), RegDeleteValueA, 0x000204a0, None
        1631 (0x065f),  (0x), RegDeleteValueW, 0x00020210, None
        1632 (0x0660),  (0x), RegDisablePredefinedCache, 0x00020530, None
        1633 (0x0661),  (0x), RegDisablePredefinedCacheEx, 0x00035860, None
        1634 (0x0662),  (0x), RegDisableReflectionKey, 0x000212a0, None
        1635 (0x0663),  (0x), RegEnableReflectionKey, 0x000212a0, None
        1636 (0x0664),  (0x), RegEnumKeyA, 0x00022e70, None
        1637 (0x0665),  (0x), RegEnumKeyExA, 0x00022a80, None
        1638 (0x0666),  (0x), RegEnumKeyExW, 0x0001eaa0, None
        1639 (0x0667),  (0x), RegEnumKeyW, 0x0001eb30, None
        1640 (0x0668),  (0x), RegEnumValueA, 0x00022a60, None
        1641 (0x0669),  (0x), RegEnumValueW, 0x0001eb70, None
        1642 (0x066a),  (0x), RegFlushKey, 0x00020670, None
        1643 (0x066b),  (0x), RegGetKeySecurity, 0x00035870, None
        1644 (0x066c),  (0x), RegGetValueA, 0x00035890, None
        1645 (0x066d),  (0x), RegGetValueW, 0x00020120, None
        1646 (0x066e),  (0x), RegLoadAppKeyA, 0x000358b0, None
        1647 (0x066f),  (0x), RegLoadAppKeyW, 0x000358d0, None
        1648 (0x0670),  (0x), RegLoadKeyA, 0x000358f0, None
        1649 (0x0671),  (0x), RegLoadKeyW, 0x00035910, None
        1650 (0x0672),  (0x), RegLoadMUIStringA, 0x00035930, None
        1651 (0x0673),  (0x), RegLoadMUIStringW, 0x00035950, None
        1652 (0x0674),  (0x), RegNotifyChangeKeyValue, 0x00020050, None
        1653 (0x0675),  (0x), RegOpenCurrentUser, 0x00020480, None
        1654 (0x0676),  (0x), RegOpenKeyA, 0x000200b0, None
        1655 (0x0677),  (0x), RegOpenKeyExA, 0x0001ebe0, None
        1656 (0x0678),  (0x), RegOpenKeyExW, 0x0001e980, None
        1657 (0x0679),  (0x), RegOpenKeyTransactedA, 0x00044940, None
        1658 (0x067a),  (0x), RegOpenKeyTransactedW, 0x00023830, None
        1659 (0x067b),  (0x), RegOpenKeyW, 0x0001ed00, None
        1660 (0x067c),  (0x), RegOpenUserClassesRoot, 0x00035970, None
        1661 (0x067d),  (0x), RegOverridePredefKey, 0x00044990, None
        1662 (0x067e),  (0x), RegQueryInfoKeyA, 0x0001fac0, None
        1663 (0x067f),  (0x), RegQueryInfoKeyW, 0x0001ead0, None
        1664 (0x0680),  (0x), RegQueryMultipleValuesA, 0x00035990, None
        1665 (0x0681),  (0x), RegQueryMultipleValuesW, 0x000359b0, None
        1666 (0x0682),  (0x), RegQueryReflectionKey, 0x00036140, None
        1667 (0x0683),  (0x), RegQueryValueA, 0x000120a0, None
        1668 (0x0684),  (0x), RegQueryValueExA, 0x0001ea20, None
        1669 (0x0685),  (0x), RegQueryValueExW, 0x0001e8b0, None
        1670 (0x0686),  (0x), RegQueryValueW, 0x0001edb0, None
        1671 (0x0687),  (0x), RegRenameKey, 0x00044a50, None
        1672 (0x0688),  (0x), RegReplaceKeyA, 0x00044de0, None
        1673 (0x0689),  (0x), RegReplaceKeyW, 0x00045790, None
        1674 (0x068a),  (0x), RegRestoreKeyA, 0x000359d0, None
        1675 (0x068b),  (0x), RegRestoreKeyW, 0x000359f0, None
        1676 (0x068c),  (0x), RegSaveKeyA, 0x00045020, None
        1677 (0x068d),  (0x), RegSaveKeyExA, 0x00035a10, None
        1678 (0x068e),  (0x), RegSaveKeyExW, 0x00035a30, None
        1679 (0x068f),  (0x), RegSaveKeyW, 0x00045190, None
        1680 (0x0690),  (0x), RegSetKeySecurity, 0x00035a50, None
        1681 (0x0691),  (0x), RegSetKeyValueA, 0x00035a70, None
        1682 (0x0692),  (0x), RegSetKeyValueW, 0x00024510, None
        1683 (0x0693),  (0x), RegSetValueA, 0x000452d0, None
        1684 (0x0694),  (0x), RegSetValueExA, 0x00020090, None
        1685 (0x0695),  (0x), RegSetValueExW, 0x0001ebc0, None
        1686 (0x0696),  (0x), RegSetValueW, 0x000453c0, None
        1687 (0x0697),  (0x), RegUnLoadKeyA, 0x00035a90, None
        1688 (0x0698),  (0x), RegUnLoadKeyW, 0x00035ab0, None
         
         */

        /// <summary>
        /// Closes a handle to the specified registry key.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regclosekey
        /// </summary>
        /// <param name="hKey">
        /// A handle to the open key to be closed. 
        /// The handle must have been opened by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, RegOpenKeyTransacted, or RegConnectRegistry function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCloseKey(
            IntPtr hKey
            );

        /// <summary>
        /// Establishes a connection to a predefined registry key on another computer.
        /// </summary>
        /// <param name="lpMachineName">
        /// The name of the remote computer. The string has the following form:\\computername
        /// The caller must have access to the remote computer or the function fails.
        /// If this parameter is NULL, the local computer name is used.
        /// </param>
        /// <param name="hKey">
        /// A predefined registry handle. 
        /// This parameter can be one of the following predefined keys on the remote computer.
        /// HKEY_LOCAL_MACHINE HKEY_PERFORMANCE_DATA HKEY_USERS
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a key handle identifying the predefined handle on the remote computer.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegConnectRegistryA(
            [MarshalAs(UnmanagedType.LPStr)] string lpMachineName,
            IntPtr hKey,
            IntPtr phkResult
            );

        /// almost same as RegConnectRegistryA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegConnectRegistryW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpMachineName,
            IntPtr hKey,
            IntPtr phkResult
            );

        /// <summary>
        /// Copies the specified registry key, along with its values and subkeys, to the specified destination key.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcopytreea
        /// </summary>
        /// <param name="hKeySrc">
        /// A handle to an open registry key. The key must have been opened with the KEY_READ access right.
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key. This key must be a subkey of the key identified by the hKeySrc parameter. This parameter can also be NULL.
        /// </param>
        /// <param name="hKeyDest">
        /// A handle to the destination key. The calling process must have KEY_CREATE_SUB_KEY access to the key.
        /// This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the predefined keys.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCopyTreeA(
            IntPtr hKeySrc,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            IntPtr hKeyDest
            );

        /// almost same as RegCopyTreeA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCopyTreeW(
            IntPtr hKeySrc,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            IntPtr hKeyDest
            );

        /// <summary>
        /// Creates the specified registry key. If the key already exists in the registry, the function opens it.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcreatekeya
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key. The calling process must have KEY_CREATE_SUB_KEY access to the key.
        /// Access for key creation is checked against the security descriptor of the registry key, not the access mask specified when the handle was obtained.
        /// </param>
        /// <param name="lpSubKey">
        /// The name of a key that this function opens or creates. This key must be a subkey of the key identified by the hKey parameter.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key. 
        /// If the key is not one of the predefined registry keys, call the RegCloseKey function after you have finished using the handle.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCreateKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            ref IntPtr phkResult
            );

        /// almost same as RegCreateKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCreateKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            ref IntPtr phkResult
            );

        /// <summary>
        /// Creates the specified registry key. If the key already exists, the function opens it. Note that key names are not case sensitive.
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="lpSubKey">
        /// The name of a subkey that this function opens or creates.
        /// The subkey specified must be a subkey of the key identified by the hKey parameter; it can be up to 32 levels deep in the registry tree.
        /// </param>
        /// <param name="Reserved">This parameter is reserved and must be zero.</param>
        /// <param name="lpClass">The user-defined class type of this key. This parameter may be ignored. This parameter can be NULL.</param>
        /// <param name="dwOptions"></param>
        /// <param name="samDesired"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="phkResult"></param>
        /// <param name="lpdwDisposition"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCreateKeyExA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            uint Reserved,
            [MarshalAs(UnmanagedType.LPStr)] string lpClass,
            ulong dwOptions,
            uint samDesired,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            ref IntPtr phkResult,
            ref uint lpdwDisposition
            );

        /// almost same as RegCreateKeyExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCreateKeyExW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            uint Reserved,
            [MarshalAs(UnmanagedType.LPWStr)] string lpClass,
            ulong dwOptions,
            uint samDesired,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            ref IntPtr phkResult,
            ref uint lpdwDisposition
            );

        /// <summary>
        /// Creates the specified registry key and associates it with a transaction. 
        /// If the key already exists, the function opens it. 
        /// Note that key names are not case sensitive.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="Reserved"></param>
        /// <param name="lpClass"></param>
        /// <param name="dwOptions"></param>
        /// <param name="samDesired"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="phkResult"></param>
        /// <param name="lpdwDisposition"></param>
        /// <param name="hTransaction"></param>
        /// <param name="pExtendedParemeter"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCreateKeyTransactedA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            uint Reserved,
            [MarshalAs(UnmanagedType.LPStr)] string lpClass,
            ulong dwOptions,
            RegKeyDesired samDesired,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            ref IntPtr phkResult,
            ref uint lpdwDisposition,
            IntPtr hTransaction,
            IntPtr pExtendedParemeter
            );

        /// almost same as RegCreateKeyTransactedA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegCreateKeyTransactedW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            uint Reserved,
            [MarshalAs(UnmanagedType.LPWStr)] string lpClass,
            ulong dwOptions,
            RegKeyDesired samDesired,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            ref IntPtr phkResult,
            ref uint lpdwDisposition,
            IntPtr hTransaction,
            IntPtr pExtendedParemeter
            );

        /// <summary>
        /// Deletes a subkey and its values. Note that key names are not case sensitive.
        /// 64-bit Windows:  On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view. 
        /// To enable an application to delete an entry in the alternate registry view, use the RegDeleteKeyEx function.
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="lpSubKey">
        /// The name of the key to be deleted. 
        /// It must be a subkey of the key that hKey identifies, but it cannot have subkeys. 
        /// This parameter cannot be NULL.
        /// The function opens the subkey with the DELETE access right.
        /// Key names are not case sensitive.
        /// </param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey
            );

        /// almost same as RegDeleteKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="lpSubKey">The name of the key to be deleted. </param>
        /// <param name="samDesired">
        /// An access mask the specifies the platform-specific view of the registry.
        /// </param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyExA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            RegKeyDesired samDesired,
            uint Reserved = 0
            );

        /// almost same as RegDeleteKeyExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyExW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            RegKeyDesired samDesired,
            uint Reserved = 0
            );

        /// <summary>
        /// Deletes a subkey and its values from the specified platform-specific view of the registry as a transacted operation. 
        /// Note that key names are not case sensitive.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="samDesired"></param>
        /// <param name="Reserved"></param>
        /// <param name="hTransaction"></param>
        /// <param name="pExtendedParemeter"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyTransactedA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            RegKeyDesired samDesired,
            uint Reserved,
            IntPtr hTransaction,
            IntPtr pExtendedParemeter
            );

        /// almost same as RegDeleteKeyTransactedA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyTransactedW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            RegKeyDesired samDesired,
            uint Reserved,
            IntPtr hTransaction,
            IntPtr pExtendedParemeter
            );

        /// <summary>
        /// Removes the specified value from the specified registry key and subkey.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="lpValueName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyValueA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName
            );

        /// almost same as RegDeleteKeyValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteKeyValueW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValueName
            );

        /// <summary>
        /// Deletes the subkeys and values of the specified key recursively.
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="lpSubKey">
        /// The name of the key. This key must be a subkey of the key identified by the hKey parameter. 
        /// If this parameter is NULL, the subkeys and values of hKey are deleted.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteTreeA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey
            );

        /// almost same as RegDeleteTreeA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteTreeW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey
            );

        /// <summary>
        /// Removes a named value from the specified registry key. Note that value names are not case sensitive.
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="lpValueName">
        /// The registry value to be removed. 
        /// If this parameter is NULL or an empty string, the value set by the RegSetValueEx function is removed.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteValueA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName
            );

        /// almost same as RegDeleteValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDeleteValueW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValueName
            );

        /// <summary>
        /// Disables handle caching of the predefined registry handle for HKEY_CURRENT_USER for the current process. 
        /// This function does not work on a remote computer.
        /// To disables handle caching of all predefined registry handles, use the RegDisablePredefinedCacheEx function.
        /// </summary>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDisablePredefinedCache();

        /// <summary>
        /// Disables handle caching for all predefined registry handles for the current process.
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDisablePredefinedCacheEx();

        /// <summary>
        /// Disables registry reflection for the specified key. 
        /// Disabling reflection for a key does not affect reflection of any subkeys.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regdisablereflectionkey
        /// </summary>
        /// <param name="hBase">A handle to an open registry key.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegDisableReflectionKey(
            IntPtr hBase
            );

        /// <summary>
        /// Restores registry reflection for the specified disabled key. 
        /// Restoring reflection for a key does not affect reflection of any subkeys.
        /// </summary>
        /// <param name="hBase">A handle to the registry key that was previously disabled using the RegDisableReflectionKey function.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnableReflectionKey(
            IntPtr hBase
            );

        /// <summary>
        /// Enumerates the subkeys of the specified open registry key. 
        /// The function retrieves the name of one subkey each time it is called.
        /// Note  This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the RegEnumKeyEx function.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="dwIndex"></param>
        /// <param name="lpName"></param>
        /// <param name="cchName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnumKeyA(
            IntPtr hKey,
            uint dwIndex,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpName,
            uint cchName
            );

        /// almost same as RegEnumKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnumKeyW(
            IntPtr hKey,
            uint dwIndex,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpName,
            uint cchName
            );

        /// <summary>
        /// Enumerates the subkeys of the specified open registry key. 
        /// The function retrieves information about one subkey each time it is called.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="dwIndex"></param>
        /// <param name="lpName"></param>
        /// <param name="lpcchName"></param>
        /// <param name="lpReserved">This parameter is reserved and must be NULL.</param>
        /// <param name="lpClass">A pointer to a buffer that receives the user-defined class of the enumerated subkey. This parameter can be NULL.</param>
        /// <param name="lpcchClass"></param>
        /// <param name="lpftLastWriteTime">A pointer to FILETIME structure that receives the time at which the enumerated subkey was last written. This parameter can be NULL.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnumKeyExA(
            IntPtr hKey,
            uint dwIndex,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpName,
            ref uint lpcchName,
            ref uint lpReserved,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpClass,
            ref uint lpcchClass,
            ref FILETIME lpftLastWriteTime
            );

        /// almost same as RegEnumKeyExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnumKeyExW(
            IntPtr hKey,
            uint dwIndex,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpName,
            ref uint lpcchName,
            ref uint lpReserved,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpClass,
            ref uint lpcchClass,
            ref FILETIME lpftLastWriteTime
            );

        /// <summary>
        /// Enumerates the values for the specified open registry key. 
        /// The function copies one indexed value name and data block for the key each time it is called.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="dwIndex"></param>
        /// <param name="lpValueName"></param>
        /// <param name="lpcchValueName"></param>
        /// <param name="lpReserved">This parameter is reserved and must be NULL.</param>
        /// <param name="lpType"></param>
        /// <param name="lpData"></param>
        /// <param name="lpcbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnumValueA(
            IntPtr hKey,
            uint dwIndex,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpValueName,
            ref uint lpcchValueName,
            ref uint lpReserved,
            ref uint lpType,
            ref byte lpData,
            ref uint lpcbData
            );

        /// almost same as RegEnumValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegEnumValueW(
            IntPtr hKey,
            uint dwIndex,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpValueName,
            ref uint lpcchValueName,
            ref uint lpReserved,
            ref uint lpType,
            ref byte lpData,
            ref uint lpcbData
            );

        /// <summary>
        /// Writes all the attributes of the specified open registry key into the registry.
        /// </summary>
        /// <param name="hKey"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegFlushKey(
            IntPtr hKey
            );

        /// <summary>
        /// Retrieves the type and data for the specified registry value.
        /// </summary>
        /// <param name="hkey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="lpValue"></param>
        /// <param name="dwFlags"></param>
        /// <param name="pdwType"></param>
        /// <param name="pvData"></param>
        /// <param name="pcbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegGetValueA(
            IntPtr hkey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValue,
            uint dwFlags,
            ref uint pdwType,
            IntPtr pvData,
            ref uint pcbData);

        /// almost same as RegGetValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegGetValueW(
            IntPtr hkey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValue,
            uint dwFlags,
            ref uint pdwType,
            IntPtr pvData,
            ref uint pcbData);

        /// <summary>
        /// Loads the specified registry hive as an application hive.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regloadappkeya
        /// </summary>
        /// <param name="lpFile">
        /// The name of the hive file. 
        /// This hive must have been created with the RegSaveKey or RegSaveKeyEx function. 
        /// If the file does not exist, an empty hive file is created with the specified name.
        /// </param>
        /// <param name="phkResult">Pointer to the handle for the root key of the loaded hive.</param>
        /// <param name="samDesired">A mask that specifies the access rights requested for the returned root key.</param>
        /// <param name="dwOptions"></param>
        /// <param name="Reserved"></param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegLoadAppKeyA(
            [MarshalAs(UnmanagedType.LPStr)] string lpFile,
            ref IntPtr phkResult,
            uint samDesired,
            uint dwOptions,
            uint Reserved
            );

        /// almost same as RegLoadAppKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegLoadAppKeyW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpFile,
            ref IntPtr phkResult,
            uint samDesired,
            uint dwOptions,
            uint Reserved
            );

        /// <summary>
        /// Creates a subkey under HKEY_USERS or HKEY_LOCAL_MACHINE and loads the data from the specified registry hive into that subkey.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="lpFile"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegLoadKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpFile
            );

        /// almost same as RegLoadKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegLoadKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpFile
            );

        /// <summary>
        /// Loads the specified string from the specified key and subkey.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="pszValue"></param>
        /// <param name="pszOutBuf"></param>
        /// <param name="cbOutBuf"></param>
        /// <param name="pcbData"></param>
        /// <param name="Flags"></param>
        /// <param name="pszDirectory"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegLoadMUIStringA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string pszValue,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pszOutBuf,
            uint cbOutBuf,
            ref uint pcbData,
            uint Flags,
            [MarshalAs(UnmanagedType.LPStr)] string pszDirectory
            );

        /// almost same as RegLoadMUIStringA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegLoadMUIStringW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string pszValue,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszOutBuf,
            uint cbOutBuf,
            ref uint pcbData,
            uint Flags,
            [MarshalAs(UnmanagedType.LPWStr)] string pszDirectory
            );

        /// <summary>
        /// Notifies the caller about changes to the attributes or contents of a specified registry key.
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="bWatchSubtree">
        /// If this parameter is TRUE, the function reports changes in the specified key and its subkeys. 
        /// If the parameter is FALSE, the function reports changes only in the specified key.
        /// </param>
        /// <param name="dwNotifyFilter">
        /// A value that indicates the changes that should be reported. This parameter can be one or more of the [Enums/RegNotifyFilter].
        /// </param>
        /// <param name="hEvent">
        /// A handle to an event. If the fAsynchronous parameter is TRUE, 
        /// the function returns immediately and changes are reported by signaling this event. 
        /// If fAsynchronous is FALSE, hEvent is ignored.
        /// </param>
        /// <param name="fAsynchronous">
        /// If this parameter is TRUE, the function returns immediately and reports changes by signaling the specified event. 
        /// If this parameter is FALSE, the function does not return until a change has occurred.
        /// If hEvent does not specify a valid event, the fAsynchronous parameter cannot be TRUE.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegNotifyChangeKeyValue(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree,
            ulong dwNotifyFilter,
            IntPtr hEvent,
            [MarshalAs(UnmanagedType.Bool)] bool fAsynchronous
            );

        /// <summary>
        /// Retrieves a handle to the HKEY_CURRENT_USER key for the user the current thread is impersonating.
        /// </summary>
        /// <param name="samDesired">A mask that specifies the desired access rights to the key.</param>
        /// <param name="phkResult">A pointer to a variable that receives a handle to the opened key.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenCurrentUser(
            uint samDesired,
            ref IntPtr phkResult
            );

        /// <summary>
        /// Opens the specified registry key.
        /// Note  This function is provided only for compatibility with 16-bit versions of Windows. 
        /// Applications should use the RegOpenKeyEx function.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="phkResult"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            ref IntPtr phkResult
            );

        /// amost same as RegOpenKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            ref IntPtr phkResult
            );

        /// <summary>
        /// Opens the specified registry key. Note that key names are not case sensitive.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="ulOptions"></param>
        /// <param name="samDesired"></param>
        /// <param name="phkResult"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenKeyExA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            uint ulOptions,
            uint samDesired,
            ref IntPtr phkResult
            );

        /// amost same as RegOpenKeyExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenKeyExW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            uint ulOptions,
            uint samDesired,
            ref IntPtr phkResult
            );

        /// <summary>
        /// Opens the specified registry key and associates it with a transaction. 
        /// Note that key names are not case sensitive.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="ulOptions"></param>
        /// <param name="samDesired"></param>
        /// <param name="phkResult"></param>
        /// <param name="hTransaction"></param>
        /// <param name="pExtendedParemeter"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenKeyTransactedA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            uint ulOptions,
            uint samDesired,
            ref IntPtr phkResult,
            IntPtr hTransaction,
            IntPtr pExtendedParemeter
            );

        /// amost same as RegOpenKeyTransactedA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenKeyTransactedW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            uint ulOptions,
            uint samDesired,
            ref IntPtr phkResult,
            IntPtr hTransaction,
            IntPtr pExtendedParemeter
            );

        /// <summary>
        /// Retrieves a handle to the HKEY_CLASSES_ROOT key for a specified user.
        /// </summary>
        /// <param name="hToken"></param>
        /// <param name="dwOptions"></param>
        /// <param name="samDesired"></param>
        /// <param name="phkResult"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOpenUserClassesRoot(
            IntPtr hToken,
            uint dwOptions,
            uint samDesired,
            ref IntPtr phkResult
            );

        /// <summary>
        /// Maps a predefined registry key to the specified registry key.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="hNewHKey"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegOverridePredefKey(
            IntPtr hKey,
            IntPtr hNewHKey
            );

        /// <summary>
        /// Retrieves information about the specified registry key.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpClass"></param>
        /// <param name="lpcchClass"></param>
        /// <param name="lpReserved"></param>
        /// <param name="lpcSubKeys"></param>
        /// <param name="lpcbMaxSubKeyLen"></param>
        /// <param name="lpcbMaxClassLen"></param>
        /// <param name="lpcValues"></param>
        /// <param name="lpcbMaxValueNameLen"></param>
        /// <param name="lpcbMaxValueLen"></param>
        /// <param name="lpcbSecurityDescriptor"></param>
        /// <param name="lpftLastWriteTime"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryInfoKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpClass,
            ref uint lpcchClass,
            ref uint lpReserved,
            ref uint lpcSubKeys,
            ref uint lpcbMaxSubKeyLen,
            ref uint lpcbMaxClassLen,
            ref uint lpcValues,
            ref uint lpcbMaxValueNameLen,
            ref uint lpcbMaxValueLen,
            ref uint lpcbSecurityDescriptor,
            FILETIME lpftLastWriteTime
            );
        /// amost same as RegQueryInfoKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryInfoKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpClass,
            ref uint lpcchClass,
            ref uint lpReserved,
            ref uint lpcSubKeys,
            ref uint lpcbMaxSubKeyLen,
            ref uint lpcbMaxClassLen,
            ref uint lpcValues,
            ref uint lpcbMaxValueNameLen,
            ref uint lpcbMaxValueLen,
            ref uint lpcbSecurityDescriptor,
            FILETIME lpftLastWriteTime
            );

        /// <summary>
        /// Retrieves the type and data for a list of value names associated with an open registry key.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="val_list"></param>
        /// <param name="num_vals"></param>
        /// <param name="lpValueBuf"></param>
        /// <param name="ldwTotsize"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryMultipleValuesA(
            IntPtr hKey,
            ref VALENTA[] val_list,
            uint num_vals,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpValueBuf,
            ref uint ldwTotsize);

        /// amost same as RegQueryMultipleValuesA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryMultipleValuesW(
            IntPtr hKey,
            ref VALENTW[] val_list,
            uint num_vals,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpValueBuf,
            ref uint ldwTotsize);

        /// <summary>
        /// Determines whether reflection has been disabled or enabled for the specified key.
        /// </summary>
        /// <param name="hBase"></param>
        /// <param name="bIsReflectionDisabled">
        /// A value that indicates whether reflection has been disabled through RegDisableReflectionKey or enabled through RegEnableReflectionKey.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryMultipleValuesW(
            IntPtr hBase,
            ref bool bIsReflectionDisabled
            );


        /// <summary>
        /// Retrieves the data associated with the default or unnamed value of a specified registry key. 
        /// The data must be a null-terminated string.
        /// Note  This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the RegQueryValueEx function.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="lpData"></param>
        /// <param name="lpcbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryValueA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpData,
            ref int lpcbData
            );

        /// amost same as RegQueryValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryValueW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpData,
            ref int lpcbData
            );

        /// <summary>
        /// Retrieves the type and data for the specified value name associated with an open registry key.
        /// Warning
        /// If the value being queried is a string (REG_SZ, REG_MULTI_SZ, and REG_EXPAND_SZ) the value 
        /// returned is NOT guaranteed to be null-terminated. 
        /// Use the RegGetValue function if you want to ensure returned string values are null-terminated. 
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpValueName"></param>
        /// <param name="lpReserved"></param>
        /// <param name="lpType"></param>
        /// <param name="lpData"></param>
        /// <param name="lpcbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryValueExA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
            uint lpReserved,
            ref uint lpType,
            ref byte lpData,
            ref uint lpcbData
            );

        /// amost same as RegQueryValueExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegQueryValueExW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValueName,
            uint lpReserved,
            ref uint lpType,
            ref byte lpData,
            ref uint lpcbData
            );

        /// <summary>
        /// Changes the name of the specified registry key.
        /// </summary>
        /// <param name="hKey">A handle to the key to be renamed.</param>
        /// <param name="lpValueName">The name of the subkey to be renamed.</param>
        /// <param name="lpNewKeyName">The new name of the key. The new name must not already exist.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegRenameKey(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValueName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpNewKeyName
            );

        /// <summary>
        /// Replaces the file backing a registry key and all its subkeys with another file, 
        /// so that when the system is next started, the key and subkeys will have the values stored in the new file.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="lpNewFile"></param>
        /// <param name="lpOldFile"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegReplaceKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpNewFile,
            [MarshalAs(UnmanagedType.LPStr)] string lpOldFile
            );

        /// amost same as RegReplaceKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegReplaceKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpNewFile,
            [MarshalAs(UnmanagedType.LPWStr)] string lpOldFile
            );

        /// <summary>
        /// Reads the registry information in a specified file and copies it over the specified key. 
        /// This registry information may be in the form of a key and multiple levels of subkeys.
        /// 
        /// Applications that back up or restore system state including system files 
        /// and registry hives should use the Volume Shadow Copy Service instead of the registry functions.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpFile"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegRestoreKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpFile,
            RegRestoreFlags dwFlags
            );

        /// amost same as RegRestoreKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegRestoreKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpFile,
            RegRestoreFlags dwFlags
            );

        /// <summary>
        /// Saves the specified key and all of its subkeys and values to a new file, in the standard format.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpFile"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSaveKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpFile,
            SECURITY_ATTRIBUTES lpSecurityAttributes
            );

        /// amost same as RegSaveKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSaveKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpFile,
            SECURITY_ATTRIBUTES lpSecurityAttributes
            );

        /// <summary>
        /// Saves the specified key and all of its subkeys and values to a registry file, in the specified format.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpFile"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSaveKeyExA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpFile,
            SECURITY_ATTRIBUTES lpSecurityAttributes,
            REG_SAVE_FLAGS Flags
            );

        /// amost same as RegSaveKeyExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSaveKeyExW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpFile,
            SECURITY_ATTRIBUTES lpSecurityAttributes,
            REG_SAVE_FLAGS Flags
            );

        /// <summary>
        /// Sets the data for the specified value in the specified registry key and subkey.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="lpValueName"></param>
        /// <param name="dwType"></param>
        /// <param name="lpData"></param>
        /// <param name="cbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSetKeyValueA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
            uint dwType,
            IntPtr lpData,
            uint cbData
            );

        /// amost same as RegSetKeyValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSetKeyValueW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValueName,
            uint dwType,
            IntPtr lpData,
            uint cbData
            );

        /// <summary>
        /// Sets the data for the default or unnamed value of a specified registry key. 
        /// The data must be a text string.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <param name="dwType"></param>
        /// <param name="lpData"></param>
        /// <param name="cbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSetValueA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey,
            uint dwType,
            IntPtr lpData,
            uint cbData
            );

        /// amost same as RegSetValueA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSetValueW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey,
            uint dwType,
            IntPtr lpData,
            uint cbData
            );

        /// <summary>
        /// Sets the data and type of a specified value under a registry key.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpValueName"></param>
        /// <param name="Reserved"></param>
        /// <param name="dwType"></param>
        /// <param name="lpData"></param>
        /// <param name="cbData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSetValueExA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
            uint Reserved,
            uint dwType,
            IntPtr lpData,
            uint cbData
            );

        /// amost same as RegSetValueExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegSetValueExW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpValueName,
            uint Reserved,
            uint dwType,
            IntPtr lpData,
            uint cbData
            );

        /// <summary>
        /// Unloads the specified registry key and its subkeys from the registry.
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="lpSubKey"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegUnLoadKeyA(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpSubKey
            );

        /// almost same as RegUnLoadKeyA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegUnLoadKeyW(
            IntPtr hKey,
            [MarshalAs(UnmanagedType.LPWStr)] string lpSubKey
            );

    }
}
