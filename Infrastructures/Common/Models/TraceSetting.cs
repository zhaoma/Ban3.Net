using Rougamo;

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 跟踪设置
/// </summary>
public class TraceSetting
{
    /// <summary>
    /// 记录时间
    /// </summary>
    public bool Timing { get; set; }

    /// <summary>
    /// 记录参数
    /// </summary>
    public bool LoggingArguments { get; set; }

    /// <summary>
    /// 绑定对象
    /// </summary>
    public AccessFlags BindFlags { get; set; }
}