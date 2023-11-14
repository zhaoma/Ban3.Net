// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Attributes;

using log4net;

namespace Ban3.Infrastructures.ServiceCentre.Applications;

/// <summary>
/// 实现的基类 
/// </summary>
[TracingIt]
public abstract class OneImplement
{
    protected readonly ILog Logger = LogManager.GetLogger( typeof( OneImplement ) );
}