/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（文件）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 文件相关扩展方法
    /// </summary>
    public static partial class Helper
    {
        /// 
        public static string[] GetFiles(
	        this string rootPath, 
	        string pattern, 
	        bool includeSubFolders = true)
            => Directory.GetFiles
	            (
                    rootPath,
                    pattern,
                    includeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
                );

        /// 
        public static string[] GetDirectories(
	        this string rootPath, 
	        string pattern,
            bool includeSubFolders = true)
            => Directory.GetDirectories
	            (
                    rootPath, 
		            pattern,
                    includeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
                );

        /// 
        public static string DataFile<T>(this object id)
            => typeof(T).LocalFile($"{id}");

        /// 
        public static string SetsFile<T>(this List<T> all, string func = "all")
	        => typeof(T).LocalFile(func);

        /// 
	    public static string LocalFile(this Type type,string func="all")
        {
            var path = type.Name.DataPath();
            return Path.Combine(path, $"{func}.lr");
        }

        /// 
        public static string DataPath(this string resource)
        {
            var rootPath = Config.LocalStorage.RootPath;

            if (string.IsNullOrEmpty(rootPath))
                rootPath = Environment.CurrentDirectory;

            var fullPath = Path.Combine(rootPath, resource);

            if (Directory.Exists(fullPath))
                return fullPath;

            var fullPathSplit = resource.Split('\\');

            var temp = rootPath;
            foreach (var s in fullPathSplit)
            {
                temp = string.IsNullOrEmpty(temp)
                   ? s
                   : Path.Combine(temp, s);

                temp = temp.Check();
            }

            return temp;
        }

        /// 
        public static string WorkPath(this string addition)
            => Path.Combine(Environment.CurrentDirectory, addition);

        /// 
        public static string Check(this string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}