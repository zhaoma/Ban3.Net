/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（文件）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 文件相关扩展方法
    /// </summary>
    public static partial class Helper
    {
        /// 
        public static string ReadFile(this string path, string charset = "utf-8")
        {
            string result = string.Empty;

            if (File.Exists(path) && LockSlim.TryEnterReadLock(LockSlimTimeout))
            {
                try
                {
                    Encoding absoluteEncoding = Encoding.GetEncoding(charset);

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

        /// 
        public static List<string> ReadFile2Rows(this string path)
        {
            var result = new List<string>();

            if (File.Exists(path) && LockSlim.TryEnterReadLock(LockSlimTimeout))
            {
                try
                {
                    Encoding absoluteEncoding = new UTF8Encoding();

                    using var reader = new StreamReader(path, absoluteEncoding);

                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
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

        /// 
        public static byte[] ReadBytes(this string path)
        {
            byte[] result=null;

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

        /// 
        public static string WriteRows2File(this string path, List<string> lines, string charset = "utf-8")
        {
            var sb = new StringBuilder();
            foreach (var l in lines)
            {
                sb.AppendLine(l);
            }
            return path.WriteFile(sb.ToString(), charset);
        }

        /// 
        public static string WriteFile(this string path, string content, string charset = "utf-8")
        {
            string result=string.Empty;

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
                    _logger.Error(ex);
                }
                finally
                {
                    LockSlim.ExitWriteLock();
                }
            }

            return result;
        }

        /// 
        public static string WriteBytes(this string path, byte[] bytes, string charset = "utf-8")
        {
            string result = string.Empty;

            try
            {
                Encoding encoding = Encoding.GetEncoding(charset);

                var content=encoding.GetString(bytes);

                result = path.WriteFile(content,charset);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return result;
        }

        /// 
        public static bool FileNeedUpdate(this string filePath, int minutes)
        {
            if (!File.Exists(filePath)) return true;

            var fileInfo = new FileInfo(filePath);

            return DateTime.Now.Subtract(fileInfo.LastWriteTime)
                 .TotalMinutes > minutes;
        }

        /// 
        public static bool FileNeedUpdate<T>(this string filePath, T content)
        {
            if (!File.Exists(filePath)) filePath.WriteFile(content!.ObjToJson());

            var exists = filePath.ReadFile();

            return exists.MD5String() != content!.ObjToJson().MD5String();
        }

        /// 
        public static T WriteFileAfterMinutes<T>(this string filePath, int minutes, Func<T> func)
        {
            if (filePath.FileNeedUpdate(minutes))
            {
                var result= func();

                if (filePath.FileNeedUpdate(result!.ObjToJson()))
                    filePath.WriteFile(result!.ObjToJson());

                return result;
            }

            return filePath.ReadFile().JsonToObj<T>();
        }
    }
}