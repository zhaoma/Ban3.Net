using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Models;

namespace Ban3.Infrastructures.DataPersist;

/// <summary>
/// 配置，存储对象策略到字典
/// </summary>
public class Config
{
    private static readonly Dictionary<string, EntityStrategy> StrategyDic = new();

    /// <summary>
    /// 用类名获取策略(库申明，表申明，字段申明)
    /// </summary>
    /// <param name="entityType"></param>
    /// <returns></returns>
    public static EntityStrategy Strategy(Type entityType)
    {
        var key = entityType.FullName!;

        if (StrategyDic.TryGetValue(key, out var strategy))
        {
            return strategy;
        }

        strategy = new EntityStrategy(entityType);

        StrategyDic.AddOrReplace(key, strategy, false);

        return strategy;
    }
}