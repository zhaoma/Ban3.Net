/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（哈希）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Security.Cryptography;
using System.Text;
using Ban3.Infrastructures.Common.Enums;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 哈希方法
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 获取字符串MD5摘要
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string MD5String( this string plainText )
        {
            return Encoding.UTF8.GetString( HashType.MD5.GetHashedBytes( plainText ) );
        }

        /// <summary>
        /// 获取哈希之后的字符串
        /// </summary>
        /// <param name="type">哈希类型</param>
        /// <param name="source">源</param>
        /// <param name="key">key</param>
        /// <param name="isLower">是否是小写</param>
        /// <returns>哈希算法处理之后的字符串</returns>
        public static string GetHashedString( this HashType type, byte[] source, byte[] key, bool isLower = false )
        {
            if( source == null || source.Length == 0 )
            {
                return string.Empty;
            }

            var hashedBytes = GetHashedBytes( type, source, key );
            var sbText = new StringBuilder();
            if( isLower )
            {
                foreach( var b in hashedBytes )
                {
                    sbText.Append( b.ToString( "x2" ) );
                }
            }
            else
            {
                foreach( var b in hashedBytes )
                {
                    sbText.Append( b.ToString( "X2" ) );
                }
            }

            return sbText.ToString();
        }

        /// <summary>
        /// 计算字符串Hash值
        /// </summary>
        /// <param name="type">hash类型</param>
        /// <param name="str">要hash的字符串</param>
        /// <returns>hash过的字节数组</returns>
        public static byte[] GetHashedBytes( this HashType type, string str ) => GetHashedBytes( type, str, Encoding.UTF8 );

        /// <summary>
        /// 计算字符串Hash值
        /// </summary>
        /// <param name="type">hash类型</param>
        /// <param name="str">要hash的字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>hash过的字节数组</returns>
        public static byte[] GetHashedBytes( this HashType type, string str, Encoding encoding )
        {
            if( string.IsNullOrEmpty( str ) )
            {
                return Array.Empty<byte>();
            }

            var bytes = encoding.GetBytes( str );
            return GetHashedBytes( type, bytes );
        }

        /// <summary>
        /// 获取Hash后的字节数组
        /// </summary>
        /// <param name="type">哈希类型</param>
        /// <param name="key">key</param>
        /// <param name="bytes">原字节数组</param>
        /// <returns></returns>
        public static byte[] GetHashedBytes( this HashType type, byte[] bytes, byte[]? key = null )
        {
            if( bytes == null || bytes.Length == 0 )
            {
                return bytes;
            }

            HashAlgorithm algorithm = null;
            try
            {
                if( key == null )
                {
                    switch( type )
                    {
                        case HashType.SHA1:
                            algorithm = new SHA1Managed();
                            break;
                        case HashType.SHA256:
                            algorithm = new SHA256Managed();
                            break;
                        case HashType.SHA384:
                            algorithm = new SHA384Managed();
                            break;
                        case HashType.SHA512:
                            algorithm = new SHA512Managed();
                            break;
                        default:
                            algorithm = MD5.Create();
                            break;
                    }
                }
                else
                {
                    switch( type )
                    {
                        case HashType.SHA1:
                            algorithm = new HMACSHA1( key );
                            break;
                        case HashType.SHA256:
                            algorithm = new HMACSHA256( key );
                            break;
                        case HashType.SHA384:
                            algorithm = new HMACSHA384( key );
                            break;
                        case HashType.SHA512:
                            algorithm = new HMACSHA512( key );
                            break;
                        default:
                            algorithm = new HMACMD5( key );
                            break;
                    }
                }

                return algorithm.ComputeHash( bytes );
            }
            finally
            {
                algorithm.Dispose();
            }
        }
    }
}