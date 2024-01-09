//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 文件相关扩展方法(异步)
/// </summary>
public static partial class Helper
{
    /// 
    public static async Task<string> ReadFileAsync( this string filePath, string charset = "utf-8" )
    {
        using var sourceStream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            bufferSize: 4096,
            useAsync: true
        );

        var absoluteEncoding = Encoding.GetEncoding( charset );

        var sb = new StringBuilder();

        var buffer = new byte[0x1000];

        int numRead;

        while( ( numRead = await sourceStream.ReadAsync( buffer, 0, buffer.Length ) ) != 0 )
        {
            sb.Append( absoluteEncoding.GetString( buffer, 0, numRead ) );
        }

        return sb.ToString();
    }

    /// 
    public static async Task<bool> WriteFileAsync( this string filePath, string content, string charset = "utf-8" )
    {
        var bytes = Encoding.GetEncoding( charset ).GetBytes( content );
        return await WriteBytesAsync( filePath, bytes );
    }

    /// 
    public static async Task<bool> WriteBytesAsync( this string filePath, byte[] bytes )
    {
        try
        {
            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 4096,
                    useAsync: true );

            await sourceStream.WriteAsync( bytes, 0, bytes.Length );

            return true;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return false;
    }
}