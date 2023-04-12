using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    public enum Order
    {
        /// <summary>
        /// 根据系列声明, 升序排列。
        /// </summary>
        [Description("seriesAsc"), EnumMember(Value = "seriesAsc")]
        SeriesAsc,

        /// <summary>
        /// 根据系列声明, 降序排列。
        /// </summary>
        [Description("seriesDesc"), EnumMember(Value = "seriesDesc")]
        SeriesDesc,

        /// <summary>
        /// 根据数据值, 升序排列。
        /// </summary>
        [Description("valueAsc"), EnumMember(Value = "valueAsc")]
        ValueAsc,

        /// <summary>
        /// 根据数据值, 降序排列。
        /// </summary>
        [Description("valueDesc"), EnumMember(Value = "valueDesc")]
        ValueDesc,
    }
}
