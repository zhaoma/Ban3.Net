using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.PlatformInvoke.Entries;
using Ban3.Infrastructures.Common.Extensions;
using System.Reflection;

namespace Ban3.Infrastructures.PlatformInvoke;

public static partial class Helper
{
    public static bool Analyze(this AssemblyFile assemblyFile,out List<AnalyzedClass> result)
    {
        result=new ();
        try
        {
            var assemblyBuffer = assemblyFile.FullPath.ReadBytes();
            var assembly = Assembly.Load(assemblyBuffer);
            
            var types=assembly.GetExportedTypes();
            for (var i=0;i<types.Length;i++)
            {
                var currentType = types[i];

                var c = new AnalyzedClass(currentType);

                if (currentType.Analyze(out var ms))
                {
                    c.Methods=ms;
                }

                result.Add(c);
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static bool Analyze(this Type type, out List<AnalyzedMethod> methods)
    {
        methods=new ();
        try
        {
            var ms=type.GetMethods();
            foreach (var methodInfo in ms)
            {
                var m = new AnalyzedMethod(methodInfo);
                if (methodInfo.Analyze(out var args))
                {
                    m.Arguments = args;
                }
                methods.Add(m);
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static bool Analyze(this MethodInfo method, out List<AnalyzedArgument> argumentList)
    {
        argumentList = new();

        try
        {
            argumentList = method.GetParameters()?
                .Select(o => new AnalyzedArgument(o))
                .ToList();

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }
}