using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Models;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist;

/// <summary>
/// 
/// </summary>
public class Config
{
    private static readonly Dictionary<string, DB> DBDic = new ();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static DB DB(string key)
    {
        if (DBDic.TryGetValue(key, out var db))
        {
            return db;
        }

        var target = new DB
        {
            Database = (Common.Config.GetValue($"DBS:{key}") + "").StringToEnum<Enums.Database>(),
            ConnectionString = Common.Config.AppConfiguration?.GetConnectionString(key) + ""
        };

        DBDic.Add(key, target);
        return target;
    }

    private static readonly Dictionary<string, TableIsAttribute> TableDic = new ();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static TableIsAttribute? Table<T>(T obj)
    {
        var key = typeof(T).FullName;
        if (TableDic.TryGetValue(key, out var table))
        {
            return table;
        }

        var target = obj!.GetAttributes<TableIsAttribute>()?.First();
        if (target != null)
            TableDic.Add(key, target);

        return target;
    }

    private static readonly Dictionary<string, Dictionary<string,FieldIsAttribute>> FieldsDic = new ();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_"></param>
    /// <returns></returns>
    public static Dictionary<string, FieldIsAttribute>? Fields<T>(T _)
    {
        var key = typeof(T).FullName;

        if (FieldsDic.TryGetValue(key, out var fields))
        {
            return fields;
        }

        var properties = typeof(T).GetPublicProperties();

        if (properties == null) return null;

        var target = new Dictionary<string, FieldIsAttribute>();

        properties.ForEach(o =>
        {
            var propertyAttribute = o.GetPropertyAttributes<FieldIsAttribute>()?.First();
            if (propertyAttribute != null)
                target.Add(o.Name, propertyAttribute);
        });

        FieldsDic.Add(key, target);

        return target;
    }
}