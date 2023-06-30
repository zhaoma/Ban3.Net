/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（文件）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 文件相关扩展方法
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static T? ReadFileAs<T>(this string path, string charset = "utf-8")
        =>
            path
                .ReadFile(charset)
                .JsonToObj<T>();

    /// <summary>
    /// 读文件(ReadToEnd)
    /// </summary>
    /// <param name="path"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static string ReadFile(this string path, string charset = "utf-8")
    {
        string result = string.Empty;

        if (File.Exists(path) && LockSlim.TryEnterReadLock(LockSlimTimeout))
        {
            try
            {
                var absoluteEncoding = Encoding.GetEncoding(charset);

                using var stream = new StreamReader(path, absoluteEncoding);

                result = stream.ReadToEnd();

                stream.Close();
            }
            finally
            {
                LockSlim.ExitReadLock();
            }
        }

        return result;
    }

    /// <summary>
    /// 按行读文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static List<string> ReadFile2Rows(this string path)
    {
        var result = new List<string>();

        if (File.Exists(path) && LockSlim.TryEnterReadLock(LockSlimTimeout))
        {
            try
            {
                Encoding absoluteEncoding = new UTF8Encoding();

                using var reader = new StreamReader(path, absoluteEncoding);

                while ((reader.ReadLine() ?? throw new InvalidOperationException()) is { } line)
                {
                    result.Add(line);
                }
            }
            finally
            {
                LockSlim.ExitReadLock();
            }
        }

        return result;
    }

    /// <summary>
    /// 读成字节数组(ReadAllBytes)
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static byte[]? ReadBytes(this string path)
    {
        byte[]? result = null;

        if (File.Exists(path) && LockSlim.TryEnterReadLock(LockSlimTimeout))
        {
            try
            {
                result = File.ReadAllBytes(path);
            }
            finally
            {
                LockSlim.ExitReadLock();
            }
        }

        return result;
    }

    /// <summary>
    /// 写入行数组
    /// </summary>
    /// <param name="path"></param>
    /// <param name="lines"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static string WriteRows2File(this string path, List<string> lines, string charset = "utf-8")
    {
        var sb = new StringBuilder();
        foreach (var l in lines)
        {
            sb.AppendLine(l);
        }

        return path.WriteFile(sb.ToString(), charset);
    }

    /// <summary>
    /// 写字符串
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static string WriteFile(this string path, string content, string charset = "utf-8")
    {
        string result = string.Empty;

        if (LockSlim.TryEnterWriteLock(LockSlimTimeout))
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding(charset);

                using var stream = new StreamWriter(path, false, encoding);

                stream.Write(content);
                stream.Close();

                result = path;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                LockSlim.ExitWriteLock();
            }
        }

        return result;
    }

    /// <summary>
    /// 写字节组
    /// </summary>
    /// <param name="path"></param>
    /// <param name="bytes"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static string WriteBytes(this string path, byte[] bytes, string charset = "utf-8")
    {
        string result = string.Empty;

        try
        {
            Encoding encoding = Encoding.GetEncoding(charset);

            var content = encoding.GetString(bytes);

            result = path.WriteFile(content, charset);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return result;
    }

    /// <summary>
    /// 文件是否需要更新(根据内容摘要比较结果)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <param name="content"></param>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static bool SaveFileOnDemand<T>(this string filePath, T content, out string timestamp)
    {
        try
        {
            timestamp = content!.ObjToJson().MD5String();

            var foundTimestamp = FilesTimestampDic.TryGetValue(filePath, out var ts);
            if (foundTimestamp && ts != null && ts.Equals(timestamp)) return true;

            if (!foundTimestamp)
            {
                ts = filePath.ReadFile().MD5String();
                if (ts.Equals(timestamp))
                {
                    return true;
                }
            }

            filePath.WriteFile(content!.ObjToJson());
            FilesTimestampDic.AddOrReplace(filePath, timestamp);

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        timestamp = string.Empty;
        return false;
    }

    private static readonly Dictionary<string, string> FilesTimestampDic = new();

    /// <summary>
    /// 程序集文件名检查
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string AssemblyName(this string assembly)
    {
        return assembly.EndsWith(".dll") ? assembly : assembly + ".dll";
    }
}