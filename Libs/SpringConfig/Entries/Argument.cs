using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.SpringConfig.Entries;

public class Argument
{

    /// <summary>
    /// 参数名称
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 引用接口
    /// </summary>
    [JsonProperty("ref")]
    public string Ref { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("factoryObject")]
    public string FactoryObject { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    /// <summary>
    /// 是否为集合
    /// </summary>
    [JsonProperty("isEnumerable")]
    public bool IsEnumerable { get; set; }

    /// <summary>
    /// 列表参数
    /// </summary>
    [JsonProperty("refs")]
    public List<string> Refs { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public List<string> AssemblyNames { get; set; }

    public bool Exists(string k)
    {
        if (IsEnumerable && Refs != null)
            return Refs.Any(x => x.ToUpper().Contains(k.ToUpper()));

        return Ref.ToUpper().Contains(k.ToUpper());
    }

    public string GetAssemblyName()
    {
        if ((Name + "").ToUpper() == "TYPENAME")
        {
            var ts = (Value + "").Split(',').Select(o => o.Trim()).ToList();
            if (ts.Count() == 2)
                return ts[1];
        }

        if ((Name + "").ToUpper() == "STR")
        {
            return "System.Runtime";
        }


        if ((Name + "").ToUpper() == "LOGGER")
        {
            return Ref;
        }

        return String.Empty;
    }
}