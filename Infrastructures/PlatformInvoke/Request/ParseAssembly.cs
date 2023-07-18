using System;
namespace Ban3.Infrastructures.PlatformInvoke.Request;

/// <summary>
/// 待处理程序集
/// </summary>
public class ParseAssembly
{
    /// <summary>
    /// dumpbin工具路径
    /// </summary>
    public string DumpbinPath { get; set; }

    /// <summary>
    /// 程序集完整路径
    /// </summary>
    public string DllPath { get; set; }

}

