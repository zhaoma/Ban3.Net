using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.PlatformInvoke.Entries;
using Ban3.Infrastructures.PlatformInvoke.Handles;
using Ban3.Infrastructures.PlatformInvoke.Request;
using log4net;

namespace Ban3.Infrastructures.PlatformInvoke;

public static class Helper
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    private static readonly string _dumpbinPath = Common.Config.AppConfiguration?["Assemblies:DumpbinPath"] + "";

    private static string _assembliesRootFolder = Common.Config.AppConfiguration?["Assemblies:RootFolder"] + "";
    private static string _assembliesPattern = Common.Config.AppConfiguration?["Assemblies:Pattern"] + "";

    public static bool Prepare()
    {
        try
        {
            var all = new List<AssemblyFile>();
            var dllFiles = _assembliesRootFolder
                .GetFiles(_assembliesPattern, false);

            var total = dllFiles.Length;
            var i = 0;

            dllFiles.ParallelExecute((file) =>
            {
                var one = new AssemblyFile
                {
                    FileType = Path.GetExtension(file),
                    FullPath = file,
                    Name = Path.GetFileName(file)
                };

                var request = new Request.ParseAssembly
                {
                    DllPath = file,
                    DumpbinPath = _dumpbinPath
                };

                var onesReferences = request.GetAssemblyReferenced();

                if (onesReferences != null)
                {
                    one.IsManaged = true;
                    one.ReferencesOrDependencies = onesReferences
                        .Select(o => new ReferencedAssembly { Name = o.Name })
                        .ToList();
                }
                else
                {
                    var onesDependencies = request.GetDependencies();

                    if (onesDependencies != null)
                    {
                        one.IsManaged = false;
                        one.ReferencesOrDependencies = onesDependencies
                            .Select(o => new ReferencedAssembly { Name = o.Name })
                            .ToList();
                    }
                }

                if (one.ReferencesOrDependencies != null && one.ReferencesOrDependencies.Any())
                    all.AppendToList(one);

                i++;
                Logger.Debug($"{i}:{total}[{one.IsManaged}]:->{one.Name}/{one.ReferencesOrDependencies?.Count}");
            }, 50);

            all.SetsFile()
                .WriteFile(all.ObjToJson());
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<AssemblyFile> Load()
    {
        return typeof(AssemblyFile)
            .LocalFile()
            .ReadFileAs<List<AssemblyFile>>();
    }


    #region Assembly HighLevel Roads

    public static List<string[]> AllHighLevels(
        string currentAssemblyFileName, List<AssemblyFile> all = null)
    {
        var list = new List<string[]>();

        all = all ?? Load();

        var a = all.FindLast(o => o.Name == currentAssemblyFileName);
        if (a == null)
            return new List<string[]>();

        var rds = HighLevels(all, a);
        foreach (var r in rds)
        {
            var oneRoad = new string[0];

            FetchHighLevels(oneRoad, r, all, list, 1);
        }

        return list;
    }

    static void FetchHighLevels(
        string[] result,
        string currentAssemblyFileName,
        List<AssemblyFile> all,
        List<string[]> allRoads,
        int depth)
    {
        var assemblyFile = all.FindLast(o => o.Name == currentAssemblyFileName);
        if (assemblyFile != null)
        {
            result = result.Redim(depth);
            result[depth - 1] = currentAssemblyFileName;

            var rds = HighLevels(all, assemblyFile)
                .FindAll(o =>
                    result.All(x => x != o)
                    && allRoads.All(x => x.All(y => y != o)))
                .ToList();

            if (rds != null && rds.Any())
            {
                foreach (var r in rds)
                {
                    FetchHighLevels(result, r, all, allRoads, depth + 1);
                }
            }
            else
            {
                allRoads.AddRoad(result);
            }
        }
    }

    static List<string> HighLevels(List<AssemblyFile> assemblies, AssemblyFile assemblyFile)
    {
        var ups = assemblies
            .FindAll(o => o.ReferencesOrDependencies
                    .Any(x => x.Name.AssemblyName().TextEqual(assemblyFile.Name)));

        return ups
            .Select(o => o.Name)
            .ToList();
    }

    #endregion

    #region Assembly LowerLevel Roads

    public static List<string[]> AllLowerLevels(
        string currentAssemblyFilePath,
        List<AssemblyFile> all = null)
    {
        var list = new List<string[]>();

        all = all ?? Load();

        var a = all.FindLast(o => o.Name ==Path.GetFileName( currentAssemblyFilePath));
        if (a == null)
            return new List<string[]>();

        var rds = LowerLevels(a);
        foreach (var r in rds)
        {
            var oneRoad = new string[0];

            FetchLowerLevels(oneRoad, r, all, list, 1);
        }

        return list;
    }

    static void FetchLowerLevels(
        string[] result,
        string currentAssemblyFileName,
        List<AssemblyFile> all,
        List<string[]> allRoads,
        int depth)
    {
        var assemblyFile = all.FindLast(o => o.Name == currentAssemblyFileName);
        if (assemblyFile != null)
        {
            result = result.Redim(depth);
            result[depth - 1] = currentAssemblyFileName;

            var rds = LowerLevels(assemblyFile)
                .FindAll(o => allRoads.All(x => x.All(y => y != o)))
                .ToList();

            if (rds != null && rds.Any())
            {
                foreach (var r in rds)
                {
                    FetchLowerLevels(result, r, all, allRoads, depth + 1);
                }
            }
            else
            {
                allRoads.AddRoad(result);
            }
        }
    }

    static List<string> LowerLevels(AssemblyFile assemblyFile)
    {
        var rds = assemblyFile.ReferencesOrDependencies.Select(o => o.Name.AssemblyName());

        return rds.Where(o => o.InLimitedScope()).ToList();
    }

    #endregion


    public static AssemblyName[] GetAssemblyReferenced(this Request.ParseAssembly request)
    {
        try
        {
            byte[] assemblyBuffer = request.DllPath.ReadBytes();
            Assembly assembly = Assembly.Load(assemblyBuffer);

            return assembly.GetReferencedAssemblies();
        }
        catch (Exception ex)
        {
            //Logger.Error(ex);
            Logger.Error($"{request.DllPath} NOT MANAGED");
        }

        return null;
    }

    public static AssemblyName[] GetDependencies(this Request.ParseAssembly request)
    {
        try
        {
            var processHandler =
                new ProcessHandler(request.DumpbinPath, request.DllPath.PrepareArgumentsForDependents());

            processHandler.Execute();

            if (processHandler.ExitCode == 0)
            {
                var ds = processHandler.Output.GetDependents();
                if (ds != null && ds.Any())
                    return ds.Select(o => new AssemblyName
                    {
                        Name = o
                    }).ToArray();
            }
        }
        catch (Exception ex)
        {
            //Logger.Error(ex);
            Logger.Error($"{request.DllPath} CANNOT GetDependencies");
        }

        return null;
    }

    static string[] PrepareArgumentsForDependents(this string assemblyPath)
    {
        return new[]
        {
            $"\"{assemblyPath}\"", "/DEPENDENTS"
        };
    }

    static List<string> GetDependents(this string content)
    {
        var result = new List<string>();
        var lines = content
            .Split('\n')
            .Select(o => o.Trim())
            .ToList();

        var found = false;
        for (int i = 0; i < lines.Count(); i++)
        {
            if (lines[i].Contains("following dependencies:"))
            {
                found = true;
                i += 2;
            }

            if (found)
            {
                if (!string.IsNullOrEmpty(lines[i]))
                    result.AppendToList(lines[i]);
                else
                    found = false;
            }
        }

        return result;
    }
    
    static void AddRoad(this List<string[]> allRoads, string[] road)
    {
        //if (!allRoads.Any(x => string.Join(",", x) == string.Join(",", road)))
        allRoads.Add(road);
    }


    static bool TextEqual(this string a, string b)
    {
        return a.ToUpper() == b.Trim().Replace(" ", "").ToUpper();
    }


    public static bool InLimitedScope(this string checkNamespace)
    {
        var limitPrefixes = new List<string> { "H.", "CT.", "MI." };
        return limitPrefixes.Any(x => checkNamespace.StartsWith(x));
    }
}

