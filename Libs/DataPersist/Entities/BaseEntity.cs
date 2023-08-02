using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.DataPersist.Entities;

/// <summary>
/// 
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual object KeyValue()
    {
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual string EqualCondition()
    {
        return string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual string TableName()
        => this.GetFirstAttribute<TableStrategyAttribute>()
            ?.TableName + "";
}