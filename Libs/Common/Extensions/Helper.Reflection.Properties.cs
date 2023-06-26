using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    /// 
    public static List<PropertyInfo>? GetPublicProperties(this Type tp)
    {
        try
        {
            return tp
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToList();
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    /// 
    public static PropertyInfo? GetProperty(this object obj, string propertyName)
    {
        var type = obj.GetType();
        return type.GetProperty(propertyName);
    }

    ///
    public static T? GetPropertyValue<T>(this object obj, string propertyName, T defaultValue)
    {
        var property = obj.GetProperty(propertyName);

        if (property != null)
        {
            var value = property.GetValue(obj, null);
            return (value is T result ? result : defaultValue);
        }

        return default(T);
    }

    ///
    public static void SetPropertyValue(this object obj, string propertyName, object value)
    {
        var property = obj.GetProperty(propertyName);

        if (property != null)
        {
            property.SetValue(obj, value, null);
        }
    }
}