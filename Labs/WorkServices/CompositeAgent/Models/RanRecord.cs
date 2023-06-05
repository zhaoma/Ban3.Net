using Ban3.Labs.CompositeAgent.Enums;

namespace Ban3.Labs.CompositeAgent.Models;

public class RanRecord
{
    public string TaskId { get; set; } = string.Empty;

    public DateTime BeginTime { get; set; }

    public DateTime EndTime { get; set; }

    public RanResult Result { get; set; }
}