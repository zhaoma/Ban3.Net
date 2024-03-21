//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    /// 
    public static List<PropertyInfo>? GetPublicProperties( this Type tp, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance )
    {
        try
        {
            return tp
                  .GetProperties( bindingFlags )
                  .ToList();
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return null;
    }

    /// 
    public static PropertyInfo? GetProperty( this object obj, string propertyName )
    {
        var type = obj.GetType();
        return type.GetProperty( propertyName );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public static object? GetPropertyValue( this object obj, string propertyName )
        => obj.GetProperty( propertyName )?.GetValue( obj, null );

    ///
    public static T? GetPropertyValue<T>( this object obj, string propertyName, T defaultValue )
    {
        var value = obj.GetPropertyValue( propertyName );
        return ( value is T result ? result : defaultValue );
    }

    ///
    public static void SetPropertyValue( this object obj, string propertyName, object value )
    {
        var property = obj.GetProperty( propertyName );

        if( property != null )
        {
            property.SetValue( obj, value, null );
        }
    }
}