using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// 
public class AnalyzedMethod
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;


    /// 
    [JsonProperty("isConstructor", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsConstructor { get; set; }

    /// <summary>
    /// ���η�
    /// </summary>
    [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? Modifier { get; set; }

    /// <summary>
    /// ����
    /// </summary>
    [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
    public List<AnalyzedArgument>? Arguments { get; set; }

    /// <summary>
    /// ����ֵ����
    /// </summary>
    [JsonProperty("returnType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ReturnType { get; set; }

    /// 
    public AnalyzedMethod()
    {
    }

    /// 
    public AnalyzedMethod(MethodInfo methodInfo)
    {
        Name = methodInfo.Name;
        IsConstructor = methodInfo.IsConstructor;
        Modifier = new List<string>();

        if (methodInfo.IsPrivate)
            Modifier.Add("private");

        if (methodInfo.IsPublic)
            Modifier.Add("public");

        if (methodInfo.IsAbstract)
            Modifier.Add("abstract");

        if (methodInfo.IsFamily)
            Modifier.Add("internal");

        if (methodInfo.IsGenericMethod)
            Modifier.Add("generic");

        if (methodInfo.IsFinal)
            Modifier.Add("final");

        if (methodInfo.IsStatic)
            Modifier.Add("static");

        if (methodInfo.IsVirtual)
            Modifier.Add("virtual");

        ReturnType = methodInfo.ReturnType.FullName;
    }
}