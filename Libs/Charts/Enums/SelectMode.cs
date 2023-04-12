using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// 选中模式，表示是否支持多个选中，默认关闭，
    /// 支持布尔值和字符串，字符串取值可选'single'表示单选，或者'multiple'表示多选。
    /// </summary>
    public enum SelectMode
    {
        /// 
        [Description("single"), EnumMember(Value = "single")]
        Single,

        /// 
        [Description("multiple"), EnumMember(Value = "multiple")]
        Multiple
    }
}
