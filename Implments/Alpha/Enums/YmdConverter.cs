//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Models;

namespace Ban3.Implements.Alpha.Enums;

public class YmdConverter : DateTimeConverter
{
    public YmdConverter() : base("yyyyMMdd")
    {
    }
}
