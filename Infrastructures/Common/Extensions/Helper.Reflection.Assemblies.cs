using System;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

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
    
}