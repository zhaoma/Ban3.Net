namespace Ban3.Infrastructures.DataPersist.Enums;

/// <summary>
/// 记录操作类型
/// </summary>
public enum Operate
{
    /// 
    Create,
    /// 
    Update,
    /// 
    UpdateByCondition,
    /// 
    Retrieve,
    /// 
    RetrieveByCondition,
    /// 
    Delete,
    /// 
    DeleteByCondition,
    /// 
    Sql
}