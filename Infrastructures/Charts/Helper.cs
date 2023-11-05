// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Attributes;
using log4net;

namespace Ban3.Infrastructures.Charts;

/// <summary>
/// 
/// </summary>
[TracingIt]
public static partial class Helper
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));
}