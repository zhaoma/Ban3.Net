using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// wincrypt.h This header is used by Security and Identity.
    /// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptacquirecertificateprivatekey
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1195 (0x04ab),  (0x), CryptAcquireContextA, 0x0001fb00, None
        1196 (0x04ac),  (0x), CryptAcquireContextW, 0x0001f330, None
        1197 (0x04ad),  (0x), CryptContextAddRef, 0x00034b10, None
        1198 (0x04ae),  (0x), CryptCreateHash, 0x0001eee0, None
        1199 (0x04af),  (0x), CryptDecrypt, 0x00024550, None
        1200 (0x04b0),  (0x), CryptDeriveKey, 0x00034b30, None
        1201 (0x04b1),  (0x), CryptDestroyHash, 0x0001f310, None
        1202 (0x04b2),  (0x), CryptDestroyKey, 0x0001f370, None
        1203 (0x04b3),  (0x), CryptDuplicateHash, 0x00034b50, None
        1204 (0x04b4),  (0x), CryptDuplicateKey, 0x00034b70, None
        1205 (0x04b5),  (0x), CryptEncrypt, 0x00034b90, None
        1206 (0x04b6),  (0x), CryptEnumProviderTypesA, 0x00034bb0, None
        1207 (0x04b7),  (0x), CryptEnumProviderTypesW, 0x00034bd0, None
        1208 (0x04b8),  (0x), CryptEnumProvidersA, 0x00034bf0, None
        1209 (0x04b9),  (0x), CryptEnumProvidersW, 0x00034c10, None
        1210 (0x04ba),  (0x), CryptExportKey, 0x0001efe0, None
        1211 (0x04bb),  (0x), CryptGenKey, 0x000245b0, None
        1212 (0x04bc),  (0x), CryptGenRandom, 0x000202c0, None
        1213 (0x04bd),  (0x), CryptGetDefaultProviderA, 0x00034c30, None
        1214 (0x04be),  (0x), CryptGetDefaultProviderW, 0x00020140, None
        1215 (0x04bf),  (0x), CryptGetHashParam, 0x0001ec40, None
        1216 (0x04c0),  (0x), CryptGetKeyParam, 0x00034c50, None
        1217 (0x04c1),  (0x), CryptGetProvParam, 0x00034c70, None
        1218 (0x04c2),  (0x), CryptGetUserKey, 0x00034c90, None
        1219 (0x04c3),  (0x), CryptHashData, 0x0001f000, None
        1220 (0x04c4),  (0x), CryptHashSessionKey, 0x00034cb0, None
        1221 (0x04c5),  (0x), CryptImportKey, 0x0001efc0, None
        1222 (0x04c6),  (0x), CryptReleaseContext, 0x0001f490, None
        1223 (0x04c7),  (0x), CryptSetHashParam, 0x0001f4d0, None
        1224 (0x04c8),  (0x), CryptSetKeyParam, 0x00034cd0, None
        1225 (0x04c9),  (0x), CryptSetProvParam, 0x00034cf0, None
        1226 (0x04ca),  (0x), CryptSetProviderA, 0x00034d10, None
        1227 (0x04cb),  (0x), CryptSetProviderExA, 0x00034d30, None
        1228 (0x04cc),  (0x), CryptSetProviderExW, 0x00034d50, None
        1229 (0x04cd),  (0x), CryptSetProviderW, 0x00034d70, None
        1230 (0x04ce),  (0x), CryptSignHashA, 0x00034d90, None
        1231 (0x04cf),  (0x), CryptSignHashW, 0x00034db0, None
        1232 (0x04d0),  (0x), CryptVerifySignatureA, 0x00034dd0, None
        1233 (0x04d1),  (0x), CryptVerifySignatureW, 0x0001f350, None
         
         */
    }
}
