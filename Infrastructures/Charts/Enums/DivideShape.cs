using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// divideShape决定在一对多或者多对一的动画中，当前系列的图形如何分裂成多个图形。
/// </summary>
public enum DivideShape
{
    /// <summary>
    /// 'split' 通过一定的算法将分割图形成为多个。
    /// </summary>
    [Description("split"), EnumMember(Value = "split")]
    Split,

    /// <summary>
    /// 'clone' 从当前图形克隆得到多个。
    /// </summary>
    [Description("clone"), EnumMember(Value = "clone")]
    Clone
}