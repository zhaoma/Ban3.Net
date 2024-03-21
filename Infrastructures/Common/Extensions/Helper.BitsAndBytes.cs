//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 位与字节组相关
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// Gets the bit.获取取第index是否为1,index从0开始
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static bool GetBit( this byte b, int index )
    {
        return ( b & ( 1 << index ) ) > 0;
    }

    /// <summary>
    /// Sets the bit.将第index位设为1
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static byte SetBit( this byte b, int index )
    {
        b |= (byte)( 1 << index );
        return b;
    }

    /// <summary>
    /// 将第index位设为0
    /// Clears the bit.
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static byte ClearBit( this byte b, int index )
    {
        b &= (byte)( ( 1 << 8 ) - 1 - ( 1 << index ) );
        return b;
    }

    /// <summary>
    /// Reverses the bit.
    /// 将第index位取反
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static byte ReverseBit( this byte b, int index )
    {
        b ^= (byte)( 1 << index );
        return b;
    }

    /// <summary>
    /// String to Binary
    /// </summary>
    /// <param name="str">String</param>
    /// <returns>Binary</returns>
    public static string StringToBinary( string str )
    {
        string converted = string.Empty;
        byte[] byteArray = str.StringToBytes();

        for( int i = 0; i < byteArray.Length; i++ )
        {
            for( int j = 0; j < 8; j++ )
            {
                converted += ( byteArray[ i ] & 0x80 ) > 0 ? "1" : "0";
                byteArray[ i ] <<= 1;
            }
        }

        return converted;
    }

    /// <summary>
    /// UTF8转字符串为byte[]
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static byte[] StringToBytes( this string text )
    {
        return Encoding.UTF8.GetBytes( text );
    }

    /// <summary>
    /// byte[2]转字符串
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="isReverse"></param>
    /// <returns></returns>
    public static string BytesToString( this byte[] arr, bool isReverse )
    {
        try
        {
            byte hi = arr[ 0 ], lo = arr[ 1 ];
            return Convert.ToString( isReverse ? hi + lo * 0x100 : hi * 0x100 + lo, 16 ).ToUpper().PadLeft( 4, '0' );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return string.Empty;
    }

    /// <summary>
    /// 字节转16进制
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static string ByteToHex( this byte b )
    {
        return b.ToString( "X2" );
    }

    /// <summary>
    /// 字节组转16进制
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string BytesToHexString( this IEnumerable<byte> bytes )
    {
        var sb = new StringBuilder();
        foreach( byte b in bytes )
            sb.Append( b.ByteToHex() );
        return sb.ToString();
    }

    /// <summary>
    /// 字符串转16进制
    /// </summary>
    /// <param name="str"></param>
    /// <param name="ignoreChinese"></param>
    /// <returns></returns>
    public static string StringToHexString( this string str, bool ignoreChinese = false )
    {
        var s = new StringBuilder();

        foreach( short c in str.ToCharArray() )
        {
            if( !ignoreChinese && ( c <= 0 || c >= 127 ) )
            {
                s.Append( c.ToString( "X4" ) );
            }
            else
            {
                s.Append( (char)c );
            }
        }

        return s.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="ignoreChinese"></param>
    /// <returns></returns>
    public static byte[] HexStringToBytes( this string str, bool ignoreChinese = false )
    {
        var hex = str.StringToHexString( ignoreChinese );

        //清除所有空格
        hex = hex.Replace( " ", "" );
        //若字符个数为奇数，补一个0
        hex += hex.Length % 2 != 0 ? "0" : "";

        byte[] result = new byte[hex.Length / 2];
        for( int i = 0, c = result.Length; i < c; i++ )
        {
            result[ i ] = Convert.ToByte( hex.Substring( i * 2, 2 ), 16 );
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="crc"></param>
    /// <param name="polynomials"></param>
    /// <param name="reversal"></param>
    /// <returns></returns>
    public static byte[] CRC16(
        this byte[] data,
        ushort crc = 0xFFFF,
        ushort polynomials = 0xA001,
        bool reversal = true )
    {
        int len = data.Length;
        if( len > 0 )
        {
            for( int i = 0; i < len; i++ )
            {
                crc = (ushort)( crc ^ ( data[ i ] ) );
                for( int j = 0; j < 8; j++ )
                {
                    crc = ( crc & 1 ) != 0 ? (ushort)( ( crc >> 1 ) ^ polynomials ) : (ushort)( crc >> 1 );
                }
            }

            byte hi = (byte)( ( crc & 0xFF00 ) >> 8 );
            byte lo = (byte)( crc & 0x00FF );

            return reversal
                ? new byte[] { lo, hi }
                : new byte[] { hi, lo };
        }

        return new byte[] { 0, 0 };
    }
}