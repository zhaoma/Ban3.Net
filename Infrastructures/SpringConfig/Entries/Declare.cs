using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Infrastructures.SpringConfig.Entries;

public class Declare
{

    /// <summary>
    /// XML file name
    /// </summary>
    [JsonProperty("file")]
    public string File { get; set; }

    /// <summary>
    /// object id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("parent")]
    public string Parent { get; set; }

    [JsonProperty("type")] 
    public string Type { get; set; }

    [JsonProperty("typeName")] 
    public string TypeName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("factoryObject")]
    public string FactoryObject { get; set; }
    
    [JsonProperty("assemblyName")] 
    public string AssemblyName { get; set; }

    [JsonProperty("args", NullValueHandling = NullValueHandling.Ignore)]
    public List<Argument> Args { get; set; }

    public bool HasArg(string k)
    {
        if (Args == null || !Args.Any()) return false;

        return Args.Any(o => o.Exists(k));
    }
}