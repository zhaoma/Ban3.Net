﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 文件相关扩展方法
/// </summary>
public static partial class Helper
{
    /// 
    public static string[] GetFiles(
        this string rootPath,
        string pattern,
        bool includeSubFolders = true )
        => rootPath.GetFilesByPattern( pattern, includeSubFolders );

    /// 
    public static string[] GetFilesByPattern( this string rootPath, string pattern, bool includeSubFolders = true )
    {
        var result = new List<string>();

        var patterns = pattern.Split( ';' );
        foreach( var p in patterns )
        {
            var temp = Directory.GetFiles( rootPath, p,
                                           includeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly );
            result = result.Union( temp ).ToList();
        }

        return result.ToArray();
    }

    /// 
    public static string[] GetDirectories(
        this string rootPath,
        string pattern,
        bool includeSubFolders = true )
        => Directory.GetDirectories
        (
            rootPath,
            pattern,
            includeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
        );

    /// 
    public static string DataFile<T>( this object id )
        => typeof( T ).LocalFile( $"{id}" );

    /// 
    public static string SetsFile<T>( this List<T> all, string func = "all" )
        => typeof( T ).LocalFile( func );

    /// 
    public static string LocalFile( this Type type, string func = "all", string ext = ".lr" )
    {
        var path = type.Name.DataPath();
        return Path.Combine( path, $"{func}{ext}" );
    }

    /// 
    public static string DataPath( this string resource )
    {
        var rootPath = Config.LocalStorage?.RootPath;

        if( string.IsNullOrEmpty( rootPath ) )
            rootPath = AppDomain.CurrentDomain.BaseDirectory;

        var fullPath = Path.Combine( rootPath, resource );

        if( Directory.Exists( fullPath ) )
            return fullPath;

        var fullPathSplit = resource.Split( '\\' );

        var temp = rootPath!;
        foreach( var s in fullPathSplit )
        {
            temp = string.IsNullOrEmpty( temp )
                ? s
                : Path.Combine( temp, s );

            temp = temp.Check();
        }

        return temp;
    }

    /// <summary>
    /// 当前工作目录
    /// </summary>
    /// <param name="addition"></param>
    /// <returns></returns>
    public static string WorkPath( this string addition )
        => Path.Combine( AppDomain.CurrentDomain.BaseDirectory, addition );

    /// 
    public static string Check( this string path )
    {
        if( !Directory.Exists( path ) )
        {
            Directory.CreateDirectory( path );
        }

        return path;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static T? ReadFileAs<T>( this string path, string charset = "utf-8" )
        =>
            path
               .ReadFile( charset )
               .JsonToObj<T>();

    /// <summary>
    /// 读文件(ReadToEnd)
    /// </summary>
    /// <param name="path"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static string ReadFile( this string path, string charset = "utf-8" )
    {
        string result = string.Empty;

        if( File.Exists( path ) && LockSlim.TryEnterReadLock( LockSlimTimeout ) )
        {
            try
            {
                var absoluteEncoding = Encoding.GetEncoding( charset );

                using var stream = new StreamReader( path, absoluteEncoding );

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
    public static List<string> ReadFile2Rows( this string path )
    {
        var result = new List<string>();

        if( File.Exists( path ) && LockSlim.TryEnterReadLock( LockSlimTimeout ) )
        {
            try
            {
                Encoding absoluteEncoding = new UTF8Encoding();

                using var reader = new StreamReader( path, absoluteEncoding );

                while( reader.ReadLine() is {} line )
                {
                    result.Add( line );
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
    public static byte[]? ReadBytes( this string path )
    {
        byte[]? result = null;

        if( File.Exists( path ) && LockSlim.TryEnterReadLock( LockSlimTimeout ) )
        {
            try
            {
                result = File.ReadAllBytes( path );
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
    public static string WriteRows2File( this string path, List<string> lines, string charset = "utf-8" )
    {
        var sb = new StringBuilder();
        foreach( var l in lines )
        {
            sb.AppendLine( l );
        }

        return path.WriteFile( sb.ToString(), charset );
    }

    /// <summary>
    /// 写字符串
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public static string WriteFile( this string path, string content, string charset = "utf-8" )
    {
        string result = string.Empty;

        if( LockSlim.TryEnterWriteLock( LockSlimTimeout ) )
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding( charset );

                using var stream = new StreamWriter( path, false, encoding );

                stream.Write( content );
                stream.Close();

                result = path;
            }
            catch( Exception ex )
            {
                Logger.Error( ex );
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
    public static string WriteBytes( this string path, byte[] bytes, string charset = "utf-8" )
    {
        string result = string.Empty;

        try
        {
            Encoding encoding = Encoding.GetEncoding( charset );

            var content = encoding.GetString( bytes );

            result = path.WriteFile( content, charset );
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
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
    public static bool SaveFileOnDemand<T>( this string filePath, T content, out string timestamp )
    {
        try
        {
            timestamp = content!.ObjToJson().MD5String();

            var foundTimestamp = FilesTimestampDic.TryGetValue( filePath, out var ts );
            if( foundTimestamp && ts != null && ts.Equals( timestamp ) ) return true;

            if( !foundTimestamp )
            {
                ts = filePath.ReadFile().MD5String();
                if( ts.Equals( timestamp ) )
                {
                    return true;
                }
            }

            filePath.WriteFile( content!.ObjToJson() );
            FilesTimestampDic.AddOrReplace( filePath, timestamp );

            return true;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        timestamp = string.Empty;
        return false;
    }

    /// <summary>
    /// 保存实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T SaveEntity<T>( this T entity, Func<T, string> key )
    {
        if( entity == null ) return entity;

        var filePath = typeof( T ).LocalFile( key( entity ) );
        filePath.SaveFileOnDemand( entity, out _ );

        return entity;
    }

    /// <summary>
    /// 用主键从文件反序列化实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T? LoadEntity<T>( this string key ) => typeof( T ).LocalFile( key ).ReadFileAs<T>();

    /// <summary>
    /// 保存实体列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static List<T>? SaveEntities<T>( this List<T>? entities, string key )
    {
        if( entities == null ) return entities;

        var filePath = typeof( T ).LocalFile( key );
        filePath.SaveFileOnDemand( entities, out _ );

        return entities;
    }

    /// <summary>
    /// 用主键从文件反序列化实体列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static List<T>? LoadEntities<T>( this string key ) => typeof( T ).LocalFile( key ).ReadFileAs<List<T>>();

    private static readonly Dictionary<string, string> FilesTimestampDic = new();

    /// <summary>
    /// 程序集文件名检查
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static string AssemblyName( this string assembly )
    {
        return assembly.EndsWith( ".dll" ) ? assembly : assembly + ".dll";
    }
}