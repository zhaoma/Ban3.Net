using System.Collections.Generic;

namespace Ban3.Infrastructures.PlatformInvoke.Entries;

public class AssemblyFile
{
    public string Name { get; set; }

    public string FileType { get; set; }

    public string FullPath { get; set; }

    public bool IsManaged { get; set; }

    public List<ReferencedAssembly> ReferencesOrDependencies { get; set; }

    public List<string[]> HighLevels { get; set; }

    public List<string[]> LowLevels { get; set; }
}