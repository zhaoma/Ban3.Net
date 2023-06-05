namespace Ban3.Labs.CompositeAgent.Models;

public class ScheduledTask
{
    public string TaskId { get; set; } = string.Empty;

    public string TaskName { get; set; } = string.Empty;

    public string AssemblyName { get; set; } = string.Empty;

    public string MethodName { get; set; }=string.Empty;

    public object[]? Arguments { get; set; }

    public Enums.TaskFrequency Frequency { get; set; }
}