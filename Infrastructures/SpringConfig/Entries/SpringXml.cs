using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ban3.Infrastructures.SpringConfig.Entries;

public class SpringXml
{
    [JsonProperty("fileName")]
    public string FileName { get; set; }

    [JsonProperty("filePath")]
    public string FilePath { get; set; }

    /// <summary>
    /// path:file
    /// </summary>
    [JsonProperty("imports")]
    public List<string> Imports { get; set; }

    [JsonProperty("aliasPath")]
    public List<AliasObject> AliasList { get; set; }

    [JsonProperty("declares")]
    public List<Declare> Declares { get; set; }
}