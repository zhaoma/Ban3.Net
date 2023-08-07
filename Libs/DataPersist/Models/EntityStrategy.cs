
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Enums;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist.Models;

public class EntityStrategy
{
    public DB? DB { get; set; }

    public TableIsAttribute? Table { get; set; }

    public Dictionary<string, FieldIsAttribute>? Fields { get; set; }

    public bool Viable() => DB != null && Table != null && Fields != null;

    public EntityStrategy(){}

    public EntityStrategy(Type entityType)
    {
        Table = GetTable(entityType);
        Fields= GetFields(entityType);
        DB = Table != null ? GetDB(Table.DbName) : null;
    }

    static DB? GetDB(string key)
        => new DB
        {
            Database = (Common.Config.GetValue($"DBS:{key}") + "").StringToEnum<Database>(),
            ConnectionString = Common.Config.AppConfiguration?.GetConnectionString(key) + ""
        };

    static TableIsAttribute? GetTable(Type tp)
        => tp.GetAttributes<TableIsAttribute>()?.First();

    static Dictionary<string, FieldIsAttribute>? GetFields(Type tp)
    {
        var properties = tp.GetPublicProperties();

        if (properties == null) return null;

        var target = new Dictionary<string, FieldIsAttribute>();

        properties.ForEach(o =>
        {
            var propertyAttribute = o.GetPropertyAttributes<FieldIsAttribute>()?.First();
            if (propertyAttribute != null)
                target.AddOrReplace(o.Name, propertyAttribute, false);
        });
        
        return target;
    }
}