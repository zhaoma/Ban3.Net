using Rougamo;

namespace Ban3.Infrastructures.Common.Models;

public class TraceSetting
{
    public bool Timing { get; set; }

    public bool LoggingArguments { get; set; }

    public AccessFlags BindFlags { get; set; }
}