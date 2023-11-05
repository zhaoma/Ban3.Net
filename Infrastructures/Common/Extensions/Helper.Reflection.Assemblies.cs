﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 程序集扩展
/// </summary>
public static partial class Helper
{
    /// 
    public static Assembly? GetAssembly(this string dllPath)
    {
        try
        {
            byte[] assemblyBuffer = dllPath.ReadBytes()!;
            return Assembly.Load(assemblyBuffer);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    /// 获取dll引用(managed dll)
    public static AssemblyName[]? GetReferencedAssemblies(this string dllPath)
    {
        try
        {
            return dllPath
                .GetAssembly()?
                .GetReferencedAssemblies();
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    /// <summary>
    /// 从程序集获取资源
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="resourceName"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool GetResourceBytes(this Assembly assembly, string resourceName, out byte[]? result)
    {
        try
        {
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
            {
                var length = (int)stream.Length;
                result = new byte[length];

                return stream.Read(result, 0, length) > 0;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        result = null;
        return false;
    }
}