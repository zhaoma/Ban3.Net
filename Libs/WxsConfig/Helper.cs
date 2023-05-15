using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.WxsConfig.Entries;
using log4net;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Ban3.Infrastructures.WxsConfig
{
    public static class Helper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

        private static readonly string RootFolder
            = Common.Config.AppConfiguration["WxsXmls:RootFolder"];

        public static bool Prepare()
        {
            try
            {
                var xmls = RootFolder.GetFiles("*.wxs");

                var list = new List<WxsXml>();
                foreach (var xml in xmls)
                {
                    Console.WriteLine(Path.GetFileName(xml));
                    list.Add(ParseWxsFile(xml));
                }

                list.SetsFile()
                    .WriteFile(list.ObjToJson());
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return false;
        }

        public static List<WxsXml> Load()
        {
            return typeof(WxsXml)
                .LocalFile()
                .ReadFileAs<List<WxsXml>>();
        }

        public static WxsXml ParseWxsFile(string filePath)
        {
            var result = new WxsXml
            {
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                Directories = new List<WxsDirectory>()
            };

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(filePath.ReadFile());
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("sn", "http://schemas.microsoft.com/wix/2006/wi");

            var allFiles = new List<WxsFile>();

            var nodes = xmlDoc.SelectNodes("/sn:Wix/sn:Fragment/sn:DirectoryRef/sn:Directory", nsmgr);

            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    var one = new WxsDirectory();
                    one.ParseDirectory(node, allFiles);

                    result.Directories.Add(one);
                }
            }

            result.Files = allFiles;
            return result;
        }

        static void ParseDirectory(this WxsDirectory directory, XmlNode node, List<WxsFile> allFiles)
        {
            if (node.Name == "Directory")
                directory.LongName = node.TryGetAttribute("LongName");

            foreach (XmlNode xmlNode in node.ChildNodes)
            {
                if (xmlNode.Name == "File")
                {
                    AddFile(directory, xmlNode);

                    allFiles.Add(new WxsFile
                    {
                        LongName = xmlNode.TryGetAttribute("LongName"),
                        Source = xmlNode.TryGetAttribute("Source")
                    });
                }
                else
                {
                    var child = new WxsDirectory();
                    child.ParseDirectory( xmlNode, allFiles);
                    directory.AddSubDirectory( child);
                }
            }
        }

        static void AddFile(this WxsDirectory directory, XmlNode node)
        {
            directory.Files ??= new List<WxsFile>();

            directory.Files.Add(new WxsFile
            {
                LongName = node.TryGetAttribute("LongName"),
                Source = node.TryGetAttribute("Source")
            });
        }

        static void AddSubDirectory(this WxsDirectory directory, WxsDirectory dir)
        {
            directory.SubDirectories ??= new List<WxsDirectory>();

            directory.SubDirectories.Add(dir);
        }

    }
}
