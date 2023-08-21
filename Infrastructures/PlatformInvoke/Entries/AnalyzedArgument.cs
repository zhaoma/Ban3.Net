using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
#nullable enable
namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// ����
/// </summary>
public class AnalyzedArgument
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// ���η�
    /// </summary>
    [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? Modifier { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    public int Position { get; set; }

    /// <summary>
    /// ��������
    /// </summary>
    [JsonProperty("declaredType", NullValueHandling = NullValueHandling.Ignore)]
    public string DeclaredType { get; set; } = string.Empty;

    /// 
    public AnalyzedArgument(){}

    /// 
    public AnalyzedArgument(ParameterInfo parameterInfo)
    {
        Name = parameterInfo.Name;
        DeclaredType = parameterInfo.ParameterType.Name;
        Modifier = new();

        if (parameterInfo.IsIn)
            Modifier.Add("in");

        if (parameterInfo.IsOut)
            Modifier.Add("out");

        if (parameterInfo.IsRetval)
            Modifier.Add("retval");

        if (parameterInfo.IsOptional)
            Modifier.Add("optional");

        Position = parameterInfo.Position;
    }
}