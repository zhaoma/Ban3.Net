using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Enums;
using Ban3.Infrastructures.DataPersist.Models;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist;

public class Config
{
    private static Dictionary<string, DB> DBDic = new Dictionary<string, DB>();

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

    private static Dictionary<string, TableIsAttribute> TableDic = new Dictionary<string, TableIsAttribute>();

    public static TableIsAttribute? Table<T>(T obj)
    {
        var key = typeof(T).FullName;
        if (TableDic.TryGetValue(key, out var table))
        {
            return table;
        }

        var target = obj!.GetFirstAttribute<TableIsAttribute>();
        if (target != null)
            TableDic.Add(key, target);

        return target;
    }

    private static Dictionary<string, List<FieldIsAttribute>> FieldsDic = new Dictionary<string, List<FieldIsAttribute>>();

    public static List<FieldIsAttribute>? Fields<T>(T obj)
    {
        var key = typeof(T).FullName;
        if (FieldsDic.TryGetValue(key, out var fields))
        {
            return fields;
        }

        var target = typeof(T).GetPublicProperties()
            .Select(o => o.GetFirstAttribute<FieldIsAttribute>())
            .Where(o => o != null)
            .Select(o => o!)
            .ToList();

        if (target != null)
            FieldsDic.Add(key, target);

        return target;
    }
}