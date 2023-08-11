using System;
using System.Collections.Generic;
using Newtonsoft.Json;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// 对象
/// </summary>
public class AnalyzedClass
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("fullName", NullValueHandling = NullValueHandling.Ignore)]
    public string? FullName { get; set; }

    [JsonProperty("namespace", NullValueHandling = NullValueHandling.Ignore)]
    public string? Namespace { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 修饰符
    /// </summary>
    [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? Modifier { get; set; } 
    
    /// <summary>
    /// 方法
    /// </summary>
    [JsonProperty("methods", NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedMethod>? Methods { get; set; }

    public AnalyzedClass(){}

    public AnalyzedClass(Type currentType)
    {
        FullName = currentType.FullName;
        Name = currentType.Name;
        Namespace=currentType.Namespace;
        Modifier = new List<string>();
        
        if (currentType.IsPublic)
            Modifier.Add("public");

        if(currentType.IsNotPublic)
            Modifier.Add("private");

        if(currentType.IsInterface)
            Modifier.Add("interface");

        if(currentType.IsClass)
            Modifier.Add("class");

        if(currentType.IsAbstract)
            Modifier.Add("abstract");

        if(currentType.IsSealed)
            Modifier.Add("sealed");

        if(currentType.IsPointer)
            Modifier.Add("unsafe");

        if (currentType.IsNested)
        {
            Modifier.Add("nested");

            if(currentType.IsNestedPrivate) Modifier.Add("private");

            if(currentType.IsNestedPublic) Modifier.Add("public");

            if(currentType.IsNestedFamily) Modifier.Add("protected");
        }
        
        if(currentType.IsVisible)
            Modifier.Add("internal");
        
    }
    
}