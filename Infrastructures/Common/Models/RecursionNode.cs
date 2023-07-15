/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            递归节点
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 递归节点
/// </summary>
public class RecursionNode
{
    /// ctor
    public RecursionNode()
    {
    }

    /// <summary>
    /// key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 上级key
    /// </summary>
    public int ParentId { get; set; }
}