using Ban3.Infrastructures.SpringConfig.Entries;
using log4net;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Ban3.Infrastructures.Common.Extensions;
using System.Linq;
using Ban3.Infrastructures.Common;

namespace Ban3.Infrastructures.SpringConfig
{
    public static class Helper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

        private static readonly string RootFolder
            = Common.Config.AppConfiguration["SpringXmls:RootFolder"];

        private static readonly string FixMappingFile
            = Path.Combine(Config.LocalStorage.RootPath, "manualMapping.json");

        public static void Prepare()
        {
            var configs = RootFolder.GetFiles("*SpringConfig.xml");

            var result = new List<SpringXml>();

            var allAlias = new List<AliasObject>();
            var allDeclares = new List<Declare>();
            var mappings = FixMappingFile.ReadFileAs<Dictionary<string, string>>();

            foreach (var config in configs)
            {
                Logger.Debug(config);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(config.ReadFile());
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("sn", "http://www.springframework.net");

                var one = new SpringXml
                {
                    FileName = Path.GetFileName(config),
                    FilePath = config,
                    Imports = xmlDoc.SelectNodes("/sn:objects/sn:import", nsmgr).Nodes2Imports(config),
                    AliasList = xmlDoc.SelectNodes("/sn:objects/sn:alias", nsmgr).Nodes2Alias(),
                    Declares = xmlDoc.SelectNodes("/sn:objects/sn:object", nsmgr).Nodes2Declares()
                };

                allAlias.AddRange(one.AliasList);
                allDeclares.AddRange(one.Declares);

                result.Add(one);
            }

            FixDeclares(result, allAlias, allDeclares, mappings);

            allAlias.SetsFile()
                .WriteFile(allAlias.ObjToJson());

            allDeclares.SetsFile()
                .WriteFile(allDeclares.ObjToJson());

            result.SetsFile()
                .WriteFile(result.ObjToJson());

        }

        public static List<SpringXml> LoadConfigs()
            => typeof(SpringXml)
                .LocalFile()
                .ReadFileAs<List<SpringXml>>();

        public static List<AliasObject> LoadAlias()
            => typeof(AliasObject)
                .LocalFile()
                .ReadFileAs<List<AliasObject>>();

        public static List<Declare> LoadDeclares()
            => typeof(Declare)
                .LocalFile()
                .ReadFileAs<List<Declare>>();

        #region ExpandWithImports

        public static List<SpringXml> ExpandWithImports(this List<SpringXml> configs)
        {
            var all = LoadConfigs();

            var result = new List<SpringXml>();

            foreach (var config in configs)
            {
                result.AppendHierarchies( config.FilePath, all);
            }

            return result;
        }

        static void AppendHierarchies(
            this List<SpringXml> result,
            string currentFilePath,
            List<SpringXml> all)
        {
            if (result.Any(o => o.FilePath == currentFilePath)) return;

            var config = all.FindLast(o => o.FilePath == currentFilePath);
            if (config != null)
            {
                if (result.All(o => o.FilePath != currentFilePath))
                    result.Add(config);

                var imports = config.Imports == null || !config.Imports.Any()
                    ? null
                    : config.Imports.FindAll(o => result.All(x => x.FilePath != o));

                foreach (var import in config.Imports)
                {
                    result.AppendHierarchies( import, all);
                }
            }
        }

        #endregion

        #region private

        static List<AliasObject> Nodes2Alias(this XmlNodeList nodes)
        {
            var result = new List<AliasObject>();
            foreach (XmlNode node in nodes)
            {
                var oneAlias = new AliasObject
                    { Name = node.TryGetAttribute("name"), Alias = node.TryGetAttribute("alias") };
                if (!string.IsNullOrEmpty(oneAlias.Name) && !string.IsNullOrEmpty(oneAlias.Alias))
                    result.Add(oneAlias);
            }

            return result;
        }

        static List<string> Nodes2Imports(this XmlNodeList nodes, string filePath)
        {
            var result = new List<string>();

            foreach (XmlNode node in nodes)
            {
                var a = node.TryGetAttribute("resource");
                if (!string.IsNullOrEmpty(a))
                {
                    var xmlPath = Path.GetDirectoryName(filePath);
                    var importPath = Path.GetFullPath(Path.Combine(xmlPath, a));

                    if (!result.Contains(importPath))
                        result.Add(importPath);
                }
            }

            return result;
        }
        
        static List<Declare> Nodes2Declares(this XmlNodeList nodes)
        {
            var result = new List<Declare>();

            foreach (XmlNode node in nodes)
            {
                var one = new Declare();

                if (node.Name == "object")
                {
                    foreach (XmlAttribute objectAttributes in node.Attributes)
                    {
                        one.Type = node.TryGetAttribute("type");
                        one.Id = node.TryGetAttribute("id");
                        one.Parent = node.TryGetAttribute("parent");
                        one.Name = node.TryGetAttribute("Name");
                        one.FactoryObject = node.TryGetAttribute("factory-object");

                        if (!string.IsNullOrEmpty(one.Type))
                        {
                            var ts = one.Type.Split(',').Select(o => o.Trim()).ToArray();
                            if (ts.Length >= 2)
                            {
                                one.TypeName = ts[0];
                                one.AssemblyName = ts[ts.Length - 1];
                            }
                        }
                    }

                    if (node.HasChildNodes)
                    {
                        var args = new List<Argument>();

                        foreach (XmlNode arg in node.ChildNodes)
                        {
                            var oneArg = new Argument
                            {
                                Name = arg.TryGetAttribute("name")
                            };

                            if (arg.HasChildNodes)
                            {
                                oneArg.IsEnumerable = true;
                                oneArg.Refs = TryGetArgumentList(arg.LastChild.ChildNodes);
                            }
                            else
                            {
                                oneArg.Ref = arg.TryGetAttribute("ref");
                                oneArg.FactoryObject = arg.TryGetAttribute("factory-object");
                                oneArg.Value = arg.TryGetAttribute("value");
                            }

                            args.Add(oneArg);
                        }

                        one.Args = args;
                    }

                    result.Add(one);
                }
            }

            return result;
        }
        
        static List<string> TryGetArgumentList(this XmlNodeList nodeList)
        {
            var list = new List<string>();

            foreach (XmlNode argListItem in nodeList)
            {
                var val = argListItem.TryGetAttribute("object");
                if (!string.IsNullOrEmpty(val))
                {
                    list.Add(val);
                }
                else
                {
                    val = argListItem.TryGetAttribute("factory-object");
                }
            }

            return list;
        }

        static void FixDeclares(
            List<SpringXml> configs,
            List<AliasObject> alias,
            List<Declare> declares,
            Dictionary<string, string> mappings)
        {
            configs.AsParallel()
                .ForAll(o => o.FixDeclares(alias, declares, mappings));
        }

        static void FixDeclares(
            this SpringXml config,
            List<AliasObject> alias,
            List<Declare> declares,
            Dictionary<string, string> mappings)
        {
            config.Declares.AsParallel()
                .ForAll(o => o.FixDeclare(alias, declares, mappings));
        }

        static void FixDeclare(
            this Declare noAssemblyDeclare,
            List<AliasObject> alias,
            List<Declare> declares,
            Dictionary<string, string> mappings)
        {
            var assemblyName = string.Empty;

            if (!string.IsNullOrEmpty(noAssemblyDeclare.Type))
            {
                assemblyName = declares.FindAssemblyByObjectId(alias, mappings, noAssemblyDeclare.Type);
                if (!string.IsNullOrEmpty(assemblyName))
                    noAssemblyDeclare.AssemblyName = assemblyName;
            }

            if (!string.IsNullOrEmpty(noAssemblyDeclare.Parent))
            {
                assemblyName = declares.FindAssemblyByObjectId(alias, mappings, noAssemblyDeclare.Parent);
                if (!string.IsNullOrEmpty(assemblyName))
                    noAssemblyDeclare.AssemblyName = assemblyName;
            }

            if (!string.IsNullOrEmpty(noAssemblyDeclare.FactoryObject))
            {
                assemblyName = declares.FindAssemblyByObjectId(alias, mappings, noAssemblyDeclare.FactoryObject);
                if (!string.IsNullOrEmpty(assemblyName))
                    noAssemblyDeclare.AssemblyName = assemblyName;
            }

            if (string.IsNullOrEmpty(noAssemblyDeclare.AssemblyName) && noAssemblyDeclare.Args != null &&
                noAssemblyDeclare.Args.Any())
            {
                foreach (var arg in noAssemblyDeclare.Args)
                {
                    assemblyName = arg.GetAssemblyName();

                    if (string.IsNullOrEmpty(assemblyName) && arg.Refs != null && arg.Refs.Any())
                    {
                        foreach (var r in arg.Refs)
                        {
                            var tempName = declares.FindAssemblyByObjectId(alias, mappings, r);
                            if (!string.IsNullOrEmpty(tempName))
                            {
                                assemblyName = tempName;
                                break;
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(assemblyName))
                    noAssemblyDeclare.AssemblyName = assemblyName;
            }

            noAssemblyDeclare.GetAssemblies(alias, declares);
        }
        
        static string FindAssemblyByObjectId(
            this List<Declare> list,
            List<AliasObject> alias,
            Dictionary<string, string> mappings,
            string objectId)
        {
            var key = objectId;
            var foundAlias = alias.FindLast(o => o.Alias == objectId);

            if (foundAlias != null)
            {
                key = foundAlias.Name;
            }

            if (mappings.ContainsKey(key))
                return mappings[key];

            var declare = list.FindLast(o => o.Id == key);

            if (declare != null)
            {
                if (!string.IsNullOrEmpty(declare.AssemblyName))
                {
                    return declare.AssemblyName;
                }
                else
                {
                    if (!string.IsNullOrEmpty(declare.FactoryObject))
                    {
                        return FindAssemblyByObjectId(list, alias, mappings, declare.FactoryObject);
                    }
                }
            }

            return string.Empty;
        }
        
        public static List<string> GetAssemblies(
            this List<SpringXml> configs,
            bool getDeclares = true,
            bool getArguments = true)
        {
            var result = new List<string>();

            var allAlias = LoadAlias();
            var allDeclares = LoadDeclares();

            foreach (var c in configs)
            {
                var configAssemblies = c.Declares
                    .Where(o => !string.IsNullOrEmpty(o.AssemblyName))
                    .Select(o => o.AssemblyName)
                    .ToArray();

                if (getDeclares)
                    result = result.Union(configAssemblies).ToList();

                if (getArguments)
                    result = result.Union(c.GetAssemblies( allAlias, allDeclares)).ToList();
            }

            return result;
        }

        public static List<string> GetAssemblies(
            this SpringXml config,
            List<AliasObject> allAlias,
            List<Declare> allDeclares
        )
        {
            var result = new List<string>();

            if (config.Declares != null && config.Declares.Any())
            {
                foreach (var declare in config.Declares)
                {
                    result = result.Union(declare.GetAssemblies( allAlias, allDeclares)).ToList();
                }
            }

            return result;
        }

        static List<string> GetAssemblies(
            this Declare declare,
            List<AliasObject> allAlias,
            List<Declare> allDeclares
        )
        {
            var result = new List<string>();

            if (!string.IsNullOrEmpty(declare.AssemblyName))
                result = result.Union(new List<string> { declare.AssemblyName }).ToList();

            if (declare.Args != null && declare.Args.Any())
            {
                foreach (var arg in declare.Args)
                {
                    arg.AssemblyNames = arg.IsEnumerable
                        ? arg.Refs.Select(o => GetAssemblies(o, allAlias, allDeclares))
                            .Where(o => !string.IsNullOrEmpty(o)).ToList()
                        : new List<string> { GetAssemblies(arg.Ref, allAlias, allDeclares) };

                    result = result.Union(arg.AssemblyNames).ToList();
                }
            }

            return result;
        }

        static string GetAssemblies(
            string refer,
            List<AliasObject> allAlias,
            List<Declare> allDeclares
        )
        {
            var alias = allAlias.FindLast(o => o.Alias.TextEqual(refer));
            var key = alias == null ? refer : alias.Name;

            var declare = allDeclares.FindLast(o => o.Id.TextEqual(key));
            return declare != null ? declare.AssemblyName : string.Empty;
        }

        static bool TextEqual(this string a, string b)
        {
            return a.ToUpper() == b.Trim().Replace(" ", "").ToUpper();
        }

        static bool AssemblyEqual(this string a, string b)
        {
            return a.TextEqual(b)
                   || $"{a}.dll".TextEqual(b);
        }

        #endregion
        
        #region AllHighLevel Roads

        public static List<string[]> AllHighLevels(
            string configFilePath, List<SpringXml> all = null)
        {
            var list = new List<string[]>();
            all = all ?? LoadConfigs();

            var a = all.FindLast(o => o.FilePath == configFilePath);
            if (a == null)
                return new List<string[]>();

            var rds = HighLevels(all, a, list, new string[0]);
            foreach (var r in rds)
            {
                var oneRoad = new string[0];

                FetchHighLevels(oneRoad, r, all, list, 1);
            }

            return list;
        }

        static void FetchHighLevels(
            string[] result,
            string currentConfigFilePath,
            List<SpringXml> all,
            List<string[]> allRoads,
            int depth)
        {
            var assemblyFile = all.FindLast(o => o.FilePath == currentConfigFilePath);
            if (assemblyFile != null)
            {
                result = result.Redim(depth);
                result[depth - 1] = currentConfigFilePath;

                var rds = HighLevels(all, assemblyFile, allRoads, result);

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

        static List<string> HighLevels(
            List<SpringXml> configs,
            SpringXml configFile,
            List<string[]> allRoads,
            string[] result)
        {
            var masters = configs
                .FindAll(o => o.Imports
                        .Any(x => x.TextEqual(configFile.FilePath)))
                .Where(o =>
                    result.All(x => x != o.FilePath) &&
                    allRoads.All(x => x.All(y => y != o.FilePath))
                )
                .Select(o => o.FilePath)
                .ToList();

            return masters;
        }

        #endregion

        #region AllLowerLevels

        public static List<string[]> AllLowerLevels(List<SpringXml> configs, List<SpringXml> all = null)
        {
            var list = new List<string[]>();
            all = all ?? LoadConfigs();

            return configs.Select(o => AllLowerLevels(o.FilePath, all))
                 .UnionAll()
                 .ToList();
        }

        public static List<string[]> AllLowerLevels(
            string currentFilePath, List<SpringXml> all = null)
        {
            var list = new List<string[]>();

            all = all ?? LoadConfigs();

            var a = all.FindLast(o => o.FilePath == currentFilePath);
            if (a == null)
                return new List<string[]>();

            var rds = a.Imports;
            foreach (var r in rds)
            {
                var oneRoad = new string[0];

                FetchLowerLevels(oneRoad, r, all, list, 1);
            }

            return list;
        }

        static void FetchLowerLevels(
            string[] result,
            string currentFilePath,
            List<SpringXml> allConfigs,
            List<string[]> allRoads,
            int depth)
        {
            var config = allConfigs.FindLast(o => o.FilePath == currentFilePath);
            if (config != null)
            {
                result = result.Redim(depth);
                result[depth - 1] = currentFilePath;

                var imports = config.Imports == null || !config.Imports.Any()
                    ? null
                    : LowerLevels(config, allRoads, result);

                if (imports != null && imports.Any())
                {
                    foreach (var import in imports)
                    {
                        FetchLowerLevels(result, import, allConfigs, allRoads, depth + 1);
                    }
                }
                else
                {
                    allRoads.AddRoad(result);
                }

            }
        }

        static List<string> LowerLevels(SpringXml configFile, List<string[]> allRoads, string[] result)
        {
            var importConfigs = configFile.Imports
                .Where(o =>
                    result.All(x => x != o) &&
                    allRoads.All(x => x.All(y => y != o))
                )
                .ToList();

            return importConfigs;
        }

        static void AddRoad(this List<string[]> allRoads, string[] road)
        {
            //if (!allRoads.Any(x => string.Join(",", x) == string.Join(",", road)))
            allRoads.Add(road);
        }

        static IEnumerable<T> UnionAll<T>(this IEnumerable<IEnumerable<T>> values)
        {
            var result = new List<T>();
            foreach (var item in values)
            {
                result = result.Union(item).ToList();
            }

            return result;
        }

        #endregion
    }
}
