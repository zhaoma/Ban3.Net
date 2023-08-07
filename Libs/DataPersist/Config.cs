using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Models;

namespace Ban3.Infrastructures.DataPersist;

/// <summary>
/// 
/// </summary>
public class Config
{
    private static readonly Dictionary<string, EntityStrategy> StrategyDic = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entityType"></param>
    /// <returns></returns>
    public static EntityStrategy Strategy(Type entityType)
    {
        if (StrategyDic.TryGetValue(entityType.FullName, out var strategy))
        {
            return strategy;
        }

        strategy = new EntityStrategy(entityType);

        StrategyDic.AddOrReplace(entityType.FullName, strategy, false);

        return strategy;
    }
}