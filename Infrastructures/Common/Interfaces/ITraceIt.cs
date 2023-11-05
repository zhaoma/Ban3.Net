// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Attributes;
using Rougamo;

namespace Ban3.Infrastructures.Common.Interfaces;

/// <summary>
/// 用Rougamo.Fody记录程序运行过程
/// </summary>
public interface ITraceIt:IRougamo<TracingItAttribute>
{
    
}