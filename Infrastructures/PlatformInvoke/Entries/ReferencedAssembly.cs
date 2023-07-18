//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/7 10:52
//  function:	ReferencedAssembly.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.PlatformInvoke.Entries;

/// <summary>
/// 引用或依赖的程序集
/// </summary>
public class ReferencedAssembly
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 版本
    /// </summary>
    public string Version { get; set; }

}
