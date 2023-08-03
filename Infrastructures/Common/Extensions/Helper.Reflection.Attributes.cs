using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    /// 
    public static IEnumerable<T>? GetAttributes<T>(
        this object obj,
        bool includeInherited = true) where T : Attribute
    {
        var type = (obj as Type ?? obj.GetType());
        var attributes = type.GetCustomAttributes(typeof(T), includeInherited);

        return attributes.Length > 0 ? attributes.OfType<T>() : null;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="property"></param>
    /// <param name="includeInherited"></param>
    /// <returns></returns>
    public static IEnumerable<T>? GetPropertyAttributes<T>(
        this PropertyInfo property, bool includeInherited = true) where T : Attribute
    {
        var attributes= property.GetCustomAttributes(typeof(T), includeInherited);

        return attributes.Length > 0 ? attributes.OfType<T>() : null;
    }
}