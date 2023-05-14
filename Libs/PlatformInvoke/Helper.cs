using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.PlatformInvoke.Handles;
using log4net;

namespace Ban3.Infrastructures.PlatformInvoke
{
    public static class Helper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

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
                Logger.Error(ex);
            }

            return null;
        }

        public static AssemblyName[] GetDependencies(this Request.ParseAssembly request)
        {
            try
            {
                var processHandler = new ProcessHandler(request.DumpbinPath, request.DllPath.PrepareArgumentsForDependents());

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
                Logger.Error(ex);
            }

            return null;
        }

        static string[] PrepareArgumentsForDependents(this string assemblyPath)
        {
            return new[]
            {
                $"\"{assemblyPath }\"","/DEPENDENTS"
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
    }
}

