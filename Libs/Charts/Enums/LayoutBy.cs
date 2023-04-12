using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// 当使用 dataset 时，seriesLayoutBy 指定了 dataset 中用行还是列对应到系列上，也就是说，
    /// 系列“排布”到 dataset 的行还是列上。
    /// </summary>
    public enum LayoutBy
    {
        /// <summary>
        /// 'column'：默认，dataset 的列对应于系列，从而 dataset 中每一列是一个维度（dimension）。
        /// </summary>
        [Description("column"), EnumMember(Value = "column")]
        Column,

        /// <summary>
        /// 'row'：dataset 的行对应于系列，从而 dataset 中每一行是一个维度（dimension）。
        /// </summary>
        [Description("row"), EnumMember(Value = "row")]
        Row
    }
}
