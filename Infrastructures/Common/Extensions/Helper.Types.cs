// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    /// 
    public static bool IsType(this object obj, Type type)
    {
        return obj.GetType() == type;
    }

    /// 
    public static T ToType<T>(this object value)
    {
        return (T)value;
    }

    /// 
    public static bool IsArray(this object obj)
    {
        return obj.IsType(typeof(Array));
    }

    /// 
    public static bool IsDBNull(this object obj)
    {
        return obj.IsType(typeof(DBNull));
    }
}